namespace GUI
{
    partial class ChatForm
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
            this.m_TextBoxInput = new System.Windows.Forms.TextBox();
            this.m_ButtonSend = new System.Windows.Forms.Button();
            this.m_TextBoxChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_TextBoxInput
            // 
            this.m_TextBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxInput.Location = new System.Drawing.Point(24, 348);
            this.m_TextBoxInput.Multiline = true;
            this.m_TextBoxInput.Name = "m_TextBoxInput";
            this.m_TextBoxInput.Size = new System.Drawing.Size(631, 39);
            this.m_TextBoxInput.TabIndex = 1;
            // 
            // m_ButtonSend
            // 
            this.m_ButtonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonSend.Location = new System.Drawing.Point(688, 348);
            this.m_ButtonSend.Name = "m_ButtonSend";
            this.m_ButtonSend.Size = new System.Drawing.Size(85, 39);
            this.m_ButtonSend.TabIndex = 2;
            this.m_ButtonSend.Text = "Send";
            this.m_ButtonSend.UseVisualStyleBackColor = true;
            this.m_ButtonSend.Click += new System.EventHandler(this.m_ButtonSend_Click);
            // 
            // m_TextBoxChat
            // 
            this.m_TextBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxChat.Location = new System.Drawing.Point(24, 49);
            this.m_TextBoxChat.Multiline = true;
            this.m_TextBoxChat.Name = "m_TextBoxChat";
            this.m_TextBoxChat.ReadOnly = true;
            this.m_TextBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_TextBoxChat.Size = new System.Drawing.Size(749, 267);
            this.m_TextBoxChat.TabIndex = 0;
            this.m_TextBoxChat.TabStop = false;
            this.m_TextBoxChat.WordWrap = false;
            // 
            // ChatForm
            // 
            this.AcceptButton = this.m_ButtonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 416);
            this.Controls.Add(this.m_ButtonSend);
            this.Controls.Add(this.m_TextBoxInput);
            this.Controls.Add(this.m_TextBoxChat);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Controls.SetChildIndex(this.m_TextBoxChat, 0);
            this.Controls.SetChildIndex(this.m_TextBoxInput, 0);
            this.Controls.SetChildIndex(this.m_ButtonSend, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox m_TextBoxInput;
        private System.Windows.Forms.Button m_ButtonSend;
        private System.Windows.Forms.TextBox m_TextBoxChat;
    }
}