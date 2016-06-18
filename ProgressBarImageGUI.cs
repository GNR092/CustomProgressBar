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
    public partial class ProgressBarImageGUI : UserControl
    {
        public ProgressBarImageGUI()
        {
            InitializeComponent();
        }
        public enum DownloadState
        {
            Setup,Check,Ready
        }
        protected double percent = 0.0f;
        [Category("Download Bar Properties")]
        [DefaultValue(true)]
        public double Valor
        {
            get{ return percent;}
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
        protected DownloadState downloadState = DownloadState.Setup;
        [Category("Download Bar Properties")]
        public DownloadState BarState
        {
            get { return downloadState; }
            set
            {
                downloadState = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            switch (downloadState)
            {
                case DownloadState.Setup:
                    g.DrawImage(Properties.Resources.TerrariaProgressBa_Bar, 25, 38, (int)((Valor / 100) * 569), 20);
                    g.DrawImage(Properties.Resources.Outer_Corrupt, 0, 0);
                    break;
                case DownloadState.Check:
                    g.DrawImage(Properties.Resources.progressbar, 25, 38, (int)((Valor / 100) * 569), 20);
                    g.DrawImage(Properties.Resources.Outer_Corrupt, 0, 0);
                    break;
                case DownloadState.Ready:
                    g.DrawImage(Properties.Resources.TerrariaProgressBa_Bar, 25, 38);
                    g.DrawImage(Properties.Resources.Outer_Corrupt, 0, 0);
                    break;
            }
        }
    }
}
