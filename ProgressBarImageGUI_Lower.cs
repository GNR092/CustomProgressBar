using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomProgressBar
{
    public partial class ProgressBarImageGUI_Lower : UserControl
    {
        public ProgressBarImageGUI_Lower()
        {
            InitializeComponent();
        }
        protected double percent = 0.0f;
        public double Valor
        {
            get { return percent; }
            set
            {
                if (value < 0)
                    value = 0;
                else
                    if (value > 100)
                        value = 100;
                percent = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawImage(Properties.Resources.ProgresBar_Bar, 14, 0, (int)((Valor / 100) * 506), 8);
            g.DrawImage(Properties.Resources.Outer_Lower, 0, 0);
        }
    }
}
