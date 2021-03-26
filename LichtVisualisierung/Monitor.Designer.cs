namespace Visualisierung
{
    partial class Monitor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.lblMonitor = new System.Windows.Forms.Label();
            this.btnCloseMonitor = new System.Windows.Forms.Button();
            this.txtMonitor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMonitor
            // 
            this.lblMonitor.Location = new System.Drawing.Point(371, 327);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(318, 170);
            this.lblMonitor.TabIndex = 0;
            this.lblMonitor.Text = "label";
            // 
            // btnCloseMonitor
            // 
            this.btnCloseMonitor.Location = new System.Drawing.Point(244, 327);
            this.btnCloseMonitor.Name = "btnCloseMonitor";
            this.btnCloseMonitor.Size = new System.Drawing.Size(89, 37);
            this.btnCloseMonitor.TabIndex = 1;
            this.btnCloseMonitor.Text = "beenden";
            this.btnCloseMonitor.UseVisualStyleBackColor = true;
            this.btnCloseMonitor.Click += new System.EventHandler(this.btnCloseMonitor_Click);
            // 
            // txtMonitor
            // 
            this.txtMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonitor.Location = new System.Drawing.Point(12, 12);
            this.txtMonitor.Multiline = true;
            this.txtMonitor.Name = "txtMonitor";
            this.txtMonitor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMonitor.Size = new System.Drawing.Size(560, 231);
            this.txtMonitor.TabIndex = 2;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 256);
            this.Controls.Add(this.txtMonitor);
            this.Controls.Add(this.btnCloseMonitor);
            this.Controls.Add(this.lblMonitor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 295);
            this.MinimumSize = new System.Drawing.Size(600, 295);
            this.Name = "Monitor";
            this.Text = "Übetragungsmonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Button btnCloseMonitor;
        public System.Windows.Forms.TextBox txtMonitor;
    }
}