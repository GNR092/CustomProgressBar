using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomProgressBar
{
    public partial class ProgressBarUI : ProgressBar
    {
        private SolidBrush BaseBrush;
        private LinearGradientBrush BackgroudBrush;
        private LinearGradientBrush ForegroudBrush;
        private LinearGradientBrush HueBrush;
        private Pen Line;

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.InitBrushes();
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.InitBrushes();
                this.Invalidate();
            }
        }

        public ProgressBarUI()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.ForeColor = Color.Green;
            this.BackColor = Color.DarkGreen;
            this.BaseBrush = new SolidBrush(Color.FromArgb(251, 251, 251));
            this.Line = new Pen(Color.FromArgb(80, Color.White));
        }
        public void InitBrushes()
        {
            Rectangle progressRect = this.GetProgressRect();
            Rectangle rect = new Rectangle(1, 1, progressRect.Width, (int)Math.Round(Math.Truncate((double)progressRect.Height * 0.45)));
            ColorBlend colorBlend1 = new ColorBlend();
            colorBlend1.Positions = new float[3]
      {
        0.0f,
        0.55f,
        1f
      };
            colorBlend1.Colors = new Color[3]
      {
        this.BackColor,
        this.ForeColor,
        this.BackColor
      };
            this.BackgroudBrush = new LinearGradientBrush(progressRect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
            this.BackgroudBrush.InterpolationColors = colorBlend1;
            ColorBlend colorBlend2 = new ColorBlend();
            colorBlend2.Positions = new float[4]
      {
        0.0f,
        0.35f,
        0.65f,
        1f
      };
            colorBlend2.Colors = new Color[4]
      {
        Color.FromArgb(200, this.ForeColor),
        Color.FromArgb(100, this.BackColor),
        Color.FromArgb(100, this.BackColor),
        Color.FromArgb(200, this.ForeColor)
      };
            this.ForegroudBrush = new LinearGradientBrush(progressRect, this.ForeColor, this.BackColor, LinearGradientMode.Horizontal);
            this.ForegroudBrush.InterpolationColors = colorBlend2;
            this.ForegroudBrush.GammaCorrection = true;
            ColorBlend colorBlend3 = new ColorBlend();
            colorBlend3.Positions = new float[3] { 0.0f, 0.3f, 1f };
            colorBlend3.Colors = new Color[3]
      {
        Color.FromArgb(120, Color.White),
        Color.FromArgb(110, Color.White),
        Color.FromArgb(80, Color.White)
      };
            this.HueBrush = new LinearGradientBrush(rect, Color.White, Color.White, LinearGradientMode.Vertical);
            this.HueBrush.InterpolationColors = colorBlend3;
            this.HueBrush.GammaCorrection = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle progressRect = this.GetProgressRect();
            Rectangle rect = new Rectangle(1, 1, progressRect.Width, (int)Math.Round(Math.Truncate((double)progressRect.Height * 0.45)));
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rectangle);
            Size size = new Size(-2, -2);
            rectangle.Inflate(size);
            e.Graphics.FillRectangle((Brush)this.BaseBrush, rectangle);
            e.Graphics.FillRectangle((Brush)this.BackgroudBrush, progressRect);
            e.Graphics.FillRectangle((Brush)this.ForegroudBrush, progressRect);
            e.Graphics.DrawLine(this.Line, 1, 1, 1, progressRect.Height);
            e.Graphics.DrawLine(this.Line, progressRect.Width, 1, progressRect.Width, progressRect.Height);
            e.Graphics.FillRectangle((Brush)this.HueBrush, rect);
        }

        public Rectangle GetProgressRect()
        {
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            Size size = new Size(-1, -1);
            rectangle.Inflate(size);
            rectangle.Width = (int)((double)rectangle.Width * ((double)this.Value / (double)this.Maximum));
            if (rectangle.Width == 0)
                rectangle.Width = 1;
            return rectangle;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.InitBrushes();
        }
    }
}
