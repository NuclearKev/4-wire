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
        DMM dmm = new DMM(1);
        List<float> dmmRes;

        public Form1()
        {
            InitializeComponent();

            dmmRes = new List<float>();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            for (int i = 0; i < 20; i++) //5 minutes
            {
                dmmRes.Add(dmm.measure4Wire());

                textBox1.Text += dmmRes[i] + ", ";

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
        public float measure4Wire()
        {
            device.Write("MEAS:FRES?");
            var str = device.ReadString(); //reads value from DMM
            float f = 0.0F;

            /* If it cannot parse the str then try and measure again */
            try
            {
                f = float.Parse(str);
            }
            catch
            {
                //weird error look at dmm
                f = this.measure4Wire();
            }
            return f;
        }
    }
}
