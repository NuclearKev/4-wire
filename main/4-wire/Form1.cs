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

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var smallCurrent = new List<double>();
            var medCurrent = new List<double>();
            var largeCurrent = new List<double>();
            var noPressure = new List<double>();
            var lightPressure = new List<double>();
            var medPressure = new List<double>();
            var heavyPressure = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                smallCurrent.Add((double)dataGridView1.Rows[i].Cells[5].Value);
                medCurrent.Add((double)dataGridView1.Rows[i].Cells[6].Value);
                largeCurrent.Add((double)dataGridView1.Rows[i].Cells[7].Value);

                noPressure.Add((double)dataGridView1.Rows[i].Cells[0].Value);
                lightPressure.Add((double)dataGridView1.Rows[i].Cells[1].Value);
                medPressure.Add((double)dataGridView1.Rows[i].Cells[2].Value);
                heavyPressure.Add((double)dataGridView1.Rows[i].Cells[3].Value);
            }

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
                column = 6;
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
            device.Write("MEAS:CUR?");
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
