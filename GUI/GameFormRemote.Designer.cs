namespace GUI
{
    partial class GameFormRemote
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
            this.m_ButtonChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonChat
            // 
            this.m_ButtonChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonChat.Location = new System.Drawing.Point(703, -1);
            this.m_ButtonChat.Name = "m_ButtonChat";
            this.m_ButtonChat.Size = new System.Drawing.Size(99, 69);
            this.m_ButtonChat.TabIndex = 8;
            this.m_ButtonChat.Text = "&Chat";
            this.m_ButtonChat.UseVisualStyleBackColor = true;
            this.m_ButtonChat.Click += new System.EventHandler(this.m_ButtonChat_Click);
            // 
            // GameFormRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_ButtonChat);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "GameFormRemote";
            this.Text = "";
            this.Controls.SetChildIndex(this.m_ButtonChat, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonChat;
    }
}