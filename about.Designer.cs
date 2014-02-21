namespace ModSync
{
    partial class about
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.la_about_desc1 = new System.Windows.Forms.Label();
            this.la_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_close = new System.Windows.Forms.Button();
            this.la_verdesc = new System.Windows.Forms.Label();
            this.la_support = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // la_about_desc1
            // 
            this.la_about_desc1.AutoSize = true;
            this.la_about_desc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_about_desc1.Location = new System.Drawing.Point(14, 9);
            this.la_about_desc1.Name = "la_about_desc1";
            this.la_about_desc1.Size = new System.Drawing.Size(270, 20);
            this.la_about_desc1.TabIndex = 0;
            this.la_about_desc1.Text = "23. Luftlandekompanie ModSync";
            // 
            // la_version
            // 
            this.la_version.AutoSize = true;
            this.la_version.Location = new System.Drawing.Point(150, 42);
            this.la_version.Name = "la_version";
            this.la_version.Size = new System.Drawing.Size(31, 13);
            this.la_version.TabIndex = 1;
            this.la_version.Text = "0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Copyright 23-luftlandekompanie.de";
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(112, 121);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 3;
            this.bt_close.Text = "&Schließen";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // la_verdesc
            // 
            this.la_verdesc.AutoSize = true;
            this.la_verdesc.Location = new System.Drawing.Point(109, 42);
            this.la_verdesc.Name = "la_verdesc";
            this.la_verdesc.Size = new System.Drawing.Size(42, 13);
            this.la_verdesc.TabIndex = 4;
            this.la_verdesc.Text = "Version";
            // 
            // la_support
            // 
            this.la_support.AutoSize = true;
            this.la_support.Location = new System.Drawing.Point(71, 95);
            this.la_support.Name = "la_support";
            this.la_support.Size = new System.Drawing.Size(157, 13);
            this.la_support.TabIndex = 5;
            this.la_support.Text = "stuffy@stuffyserv.net für Fragen";
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 148);
            this.Controls.Add(this.la_support);
            this.Controls.Add(this.la_verdesc);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.la_version);
            this.Controls.Add(this.la_about_desc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "about";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Über";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label la_about_desc1;
        private System.Windows.Forms.Label la_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Label la_verdesc;
        private System.Windows.Forms.Label la_support;
    }
}