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
    public partial class ProgressBarImage_new : UserControl
    {
        public ProgressBarImage_new()
        {
            InitializeComponent();
        }
        protected double percent = 0.0f;
        [Category("GNR092")]
        [DefaultValue(true)]
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
            g.DrawImage(Properties.Resources.TerrariaProgressBa_Bar, 0, 0, (int)((Valor / 100) * Width), Height);
        }
    }
}
