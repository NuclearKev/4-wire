/*Copyright (C) 2016  Kevin Bloom <kdb5@pct.edu>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published 
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NI = NationalInstruments.NI4882;

namespace _4_wire
{
    public partial class Form1 : Form
    {
        DMM dmm1 = new DMM(1); //used for 4-wire and voltage
        DMM dmm2 = new DMM(2); //used for current
        List<double> dmm1Res; //4-wire resistances
        List<double> dmm2Res; 
        List<double> dmmVolt;
        List<double> dmmCurrent;

        public Form1()
        {
            InitializeComponent();

            dmm1Res = new List<double>();
            dmm2Res = new List<double>();
            dmmVolt = new List<double>();
            dmmCurrent = new List<double>();

            for (int i = 0; i < 20; i++)
            {
                this.dataGridView1.Rows.Add();
            }
        }

        /* This is written EXTREMELY poorly.. I know. 
         * However, I don't know how to upload more than 1 row of data at a time */
        private void uploadButton_Click(object sender, EventArgs e)
        {
            var smallCurrent = new List<double>();
            var medCurrent = new List<double>();
            var largeCurrent = new List<double>();
            var noPressure = new List<double>();
            var lightPressure = new List<double>();
            var medPressure = new List<double>();
            var heavyPressure = new List<double>();
            char id = Convert.ToChar(IDTextBox1.Text);
            
            /* Grab data from spreadsheet and place in lists */
            for (int i = 0; i < 10; i++)
            {
                noPressure.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
                lightPressure.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
                medPressure.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                heavyPressure.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
            }

            for (int i = 0; i < 20; i++)
            {
                smallCurrent.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value));
                medCurrent.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value));
                largeCurrent.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value));
            }

            uploadData(10, noPressure, id, "2-wire", "NP");
            uploadData(10, lightPressure, id, "2-wire", "LP");
            uploadData(10, medPressure, id, "2-wire", "MP");
            uploadData(10, heavyPressure, id, "2-wire", "HP");
            uploadData(20, dmm1Res, id, "4-wire", " ");
            uploadData(20, smallCurrent, id, "4-wire", "SC");
            uploadData(20, medCurrent, id, "4-wire", "MC");
            uploadData(20, largeCurrent, id, "4-wire", "LC");
        }

        private void wire4Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++) //5 minutes
            {
                dmm1Res.Add(dmm1.measure4Wire());

                this.dataGridView1.Rows[i].Cells[4].Value = dmm1Res[i];

                Thread.Sleep(15000);
            } 
        }

        private void powerSupplyButtons_Click(object sender, EventArgs e)
        {
            double currentFlag = dmm2.measureCurrent();
            int column;

            if (currentFlag > .0005 && currentFlag < .001)
            {
                column = 6;
            }
            else if (currentFlag > .005 && currentFlag < .010)
            {
                column = 7;
            }
            else if (currentFlag > .9 && currentFlag < 1.1)
            {
                column = 8;
            }
            else
            {
                column = 10;
            }

            Thread.Sleep(5000); //give it some time to relax

            for (int i = 0; i < 20; i++) //5 minutes
            {
                dmmVolt.Add(dmm1.measureVolt());
                dmmCurrent.Add(dmm2.measureCurrent()); //measure again so we get the most recent current
                dmm2Res.Add(dmmVolt[i] / dmmCurrent[i]);

                this.dataGridView1.Rows[i].Cells[column].Value = dmm1Res[i];

                Thread.Sleep(15000);
            } 
        }

        public void uploadData(int n, List<double> resData, char groupID, string type, string info)
        {
            for (int i = 0; i < n; i++)
            {
                EET321_Lab4DataContext res = new EET321_Lab4DataContext();
                EET321_Lab4Table data = new EET321_Lab4Table();

                data.GroupID = groupID;  
                data.DateTime = DateTime.Now;
                data.Resistance = (float)resData[i];
                data.Type = type;
                data.Info = info;

                res.EET321_Lab4Tables.InsertOnSubmit(data);
                res.SubmitChanges();
            }
        }
    }

    /* Thanks Jonny */
    class DMM
    {
        NI.Device device;
        //Initialize the DMM with an address
        public DMM(byte addr)
        {
            device = new NI.Device(0, addr);
        }

        //Does exactly what you think it should
        public double measure4Wire()
        {
            device.Write("MEAS:FRES?");
            var str = device.ReadString(); //reads value from DMM
            double d = 0.0;

            /* If it cannot parse the str then try and measure again */
            try
            {
                d = double.Parse(str);
            }
            catch
            {
                //weird error look at dmm
                d = this.measure4Wire();
            }
            return d;
        }

        public double measureVolt()
        {
            device.Write("MEAS:VOLT?");
            var str = device.ReadString(); //reads value from DMM
            double d = 0.0;

            /* If it cannot parse the str then try and measure again */
            try
            {
                d = double.Parse(str);
            }
            catch
            {
                //weird error look at dmm
                d = this.measure4Wire();
            }
            return d;
        }

        public double measureCurrent()
        {
            device.Write("MEAS:CURR?");
            var str = device.ReadString(); //reads value from DMM
            double d = 0.0;

            /* If it cannot parse the str then try and measure again */
            try
            {
                d = double.Parse(str);
            }
            catch
            {
                //weird error look at dmm
                d = this.measure4Wire();
            }
            return d;
        }
    }
}
