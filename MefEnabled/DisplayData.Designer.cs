namespace MefEnabled
{
    partial class DisplayData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.data = new System.Windows.Forms.TextBox();
            this.generatorName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.data.Location = new System.Drawing.Point(0, 29);
            this.data.Multiline = true;
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(610, 292);
            this.data.TabIndex = 5;
            // 
            // generatorName
            // 
            this.generatorName.AutoSize = true;
            this.generatorName.Location = new System.Drawing.Point(3, 3);
            this.generatorName.Name = "generatorName";
            this.generatorName.Size = new System.Drawing.Size(0, 13);
            this.generatorName.TabIndex = 4;
            // 
            // DisplayData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.data);
            this.Controls.Add(this.generatorName);
            this.Name = "DisplayData";
            this.Size = new System.Drawing.Size(610, 321);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Label generatorName;
    }
}