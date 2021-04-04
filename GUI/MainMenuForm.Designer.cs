namespace GUI
{
    partial class MainMenuForm
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
            this.m_LabelMainMenu = new System.Windows.Forms.Label();
            this.m_ButtonPlayOffline = new System.Windows.Forms.Button();
            this.m_ButtonPlayOnline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_LabelMainMenu
            // 
            this.m_LabelMainMenu.AutoSize = true;
            this.m_LabelMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LabelMainMenu.Location = new System.Drawing.Point(303, 35);
            this.m_LabelMainMenu.Name = "m_LabelMainMenu";
            this.m_LabelMainMenu.Size = new System.Drawing.Size(216, 46);
            this.m_LabelMainMenu.TabIndex = 0;
            this.m_LabelMainMenu.Text = "Main Menu";
            // 
            // m_ButtonPlayOffline
            // 
            this.m_ButtonPlayOffline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonPlayOffline.Location = new System.Drawing.Point(198, 142);
            this.m_ButtonPlayOffline.Name = "m_ButtonPlayOffline";
            this.m_ButtonPlayOffline.Size = new System.Drawing.Size(433, 86);
            this.m_ButtonPlayOffline.TabIndex = 1;
            this.m_ButtonPlayOffline.Text = "Play Offline";
            this.m_ButtonPlayOffline.UseVisualStyleBackColor = true;
            this.m_ButtonPlayOffline.Click += new System.EventHandler(this.m_ButtonPlayOffline_Click);
            // 
            // m_ButtonPlayOnline
            // 
            this.m_ButtonPlayOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonPlayOnline.Location = new System.Drawing.Point(198, 269);
            this.m_ButtonPlayOnline.Name = "m_ButtonPlayOnline";
            this.m_ButtonPlayOnline.Size = new System.Drawing.Size(433, 86);
            this.m_ButtonPlayOnline.TabIndex = 2;
            this.m_ButtonPlayOnline.Text = "Play Online";
            this.m_ButtonPlayOnline.UseVisualStyleBackColor = true;
            this.m_ButtonPlayOnline.Click += new System.EventHandler(this.m_ButtonPlayOnline_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_ButtonPlayOnline);
            this.Controls.Add(this.m_ButtonPlayOffline);
            this.Controls.Add(this.m_LabelMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelMainMenu;
        private System.Windows.Forms.Button m_ButtonPlayOffline;
        private System.Windows.Forms.Button m_ButtonPlayOnline;
    }
}