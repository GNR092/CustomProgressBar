/*
 * Usuario: GNR092
 * Fecha: 08/02/2016
 * Hora: 07:02 p.m.
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomProgressBar
{
	/// <summary>
	/// Description of ProgressBarSimple.
	/// </summary>
	public partial class ProgressBarSimple : UserControl
	{
		public ProgressBarSimple()
		{
			InitializeComponent();
			ForeColor = SystemColors.Highlight;
		}
		
		protected double percent;
		public double Valor
		{
			get{return percent;}
			set
			{
				if(value < 0) value = 0;
				if(value >100) value = 100;
				percent = value;
				Invalidate();
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Brush b = new SolidBrush(ForeColor);
			var lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.Horizontal);
			int width = (int)((percent / 100)*Width);
			e.Graphics.FillRectangle(b, 0, 0, width, Height);
			e.Graphics.FillRectangle(lb, 0, 0, width, Height);
			b.Dispose();
			lb.Dispose();
		}
		
	}
}
