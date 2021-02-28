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

namespace CoronaProject
{
    public class mybutton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int IsInfected { get; set; }
        public int IsVaccine { get; set; }

        public int IsAlive { get; set; }

        public double infactionRatio { get; set; }

        public int ClickCountStat { get; set; }
    }
}
