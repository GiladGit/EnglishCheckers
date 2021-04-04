namespace GUI
{
    partial class BaseBackButtonForm
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
            this.m_ButtonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonBack
            // 
            this.m_ButtonBack.Location = new System.Drawing.Point(2, 2);
            this.m_ButtonBack.Name = "m_ButtonBack";
            this.m_ButtonBack.Size = new System.Drawing.Size(39, 35);
            this.m_ButtonBack.TabIndex = 0;
            this.m_ButtonBack.TabStop = false;
            this.m_ButtonBack.Text = "<-";
            this.m_ButtonBack.UseVisualStyleBackColor = true;
            this.m_ButtonBack.Click += new System.EventHandler(this.m_ButtonBack_Click);
            // 
            // BaseBackButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_ButtonBack);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseBackButtonForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonBack;
    }
}