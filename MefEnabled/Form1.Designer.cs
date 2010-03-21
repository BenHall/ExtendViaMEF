namespace MefEnabled
{
    partial class Form1
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
            this.dataPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.takeActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceLoggedMessageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataPanel.Location = new System.Drawing.Point(0, 82);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(511, 245);
            this.dataPanel.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeActionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(511, 29);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // takeActionToolStripMenuItem
            // 
            this.takeActionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceLoggedMessageToolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.takeActionToolStripMenuItem.Name = "takeActionToolStripMenuItem";
            this.takeActionToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.takeActionToolStripMenuItem.Text = "Take Action";
            // 
            // forceLoggedMessageToolStripMenuItem1
            // 
            this.forceLoggedMessageToolStripMenuItem1.Name = "forceLoggedMessageToolStripMenuItem1";
            this.forceLoggedMessageToolStripMenuItem1.Size = new System.Drawing.Size(239, 26);
            this.forceLoggedMessageToolStripMenuItem1.Text = "Force Logged Message";
            this.forceLoggedMessageToolStripMenuItem1.Click += new System.EventHandler(this.forceLoggedMessageToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 29);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(511, 40);
            this.topPanel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 327);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataPanel);
            this.Name = "Form1";
            this.Text = "Cheap clone of a certain application...";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ToolStripMenuItem takeActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceLoggedMessageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}