namespace CustomProgressBar
{
    partial class ProgressBarImage
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PB_bar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_bar
            // 
            this.PB_bar.BackgroundImage = global::CustomProgressBar.Properties.Resources.TerrariaProgressBa_Bar;
            this.PB_bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_bar.Location = new System.Drawing.Point(0, 0);
            this.PB_bar.Name = "PB_bar";
            this.PB_bar.Size = new System.Drawing.Size(569, 20);
            this.PB_bar.TabIndex = 0;
            this.PB_bar.TabStop = false;
            // 
            // ProgressBarImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            this.Controls.Add(this.PB_bar);
            this.Name = "ProgressBarImage";
            this.Size = new System.Drawing.Size(571, 22);
            ((System.ComponentModel.ISupportInitialize)(this.PB_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_bar;
    }
}
