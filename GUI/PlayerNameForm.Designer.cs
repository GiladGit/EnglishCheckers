namespace GUI
{
    partial class PlayerNameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_LabelPlayerName = new System.Windows.Forms.Label();
            this.m_TextBoxPlayerName = new System.Windows.Forms.TextBox();
            this.m_ButtonOK = new System.Windows.Forms.Button();
            this.m_TextBoxHostIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(157, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Info";
            // 
            // m_LabelPlayerName
            // 
            this.m_LabelPlayerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_LabelPlayerName.AutoSize = true;
            this.m_LabelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LabelPlayerName.Location = new System.Drawing.Point(22, 77);
            this.m_LabelPlayerName.Name = "m_LabelPlayerName";
            this.m_LabelPlayerName.Size = new System.Drawing.Size(97, 18);
            this.m_LabelPlayerName.TabIndex = 2;
            this.m_LabelPlayerName.Text = "Player Name:";
            // 
            // m_TextBoxPlayerName
            // 
            this.m_TextBoxPlayerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_TextBoxPlayerName.Location = new System.Drawing.Point(144, 75);
            this.m_TextBoxPlayerName.Name = "m_TextBoxPlayerName";
            this.m_TextBoxPlayerName.Size = new System.Drawing.Size(170, 20);
            this.m_TextBoxPlayerName.TabIndex = 4;
            // 
            // m_ButtonOK
            // 
            this.m_ButtonOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_ButtonOK.Location = new System.Drawing.Point(363, 86);
            this.m_ButtonOK.Name = "m_ButtonOK";
            this.m_ButtonOK.Size = new System.Drawing.Size(73, 58);
            this.m_ButtonOK.TabIndex = 9;
            this.m_ButtonOK.Text = "OK";
            this.m_ButtonOK.UseVisualStyleBackColor = true;
            this.m_ButtonOK.Click += new System.EventHandler(this.m_ButtonOK_Click);
            // 
            // m_TextBoxHostIP
            // 
            this.m_TextBoxHostIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_TextBoxHostIP.Location = new System.Drawing.Point(144, 133);
            this.m_TextBoxHostIP.Name = "m_TextBoxHostIP";
            this.m_TextBoxHostIP.Size = new System.Drawing.Size(170, 20);
            this.m_TextBoxHostIP.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(36, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Host IP:";
            // 
            // PlayerNameForm
            // 
            this.AcceptButton = this.m_ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 194);
            this.Controls.Add(this.m_TextBoxHostIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_ButtonOK);
            this.Controls.Add(this.m_TextBoxPlayerName);
            this.Controls.Add(this.m_LabelPlayerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PlayerNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_LabelPlayerName, 0);
            this.Controls.SetChildIndex(this.m_TextBoxPlayerName, 0);
            this.Controls.SetChildIndex(this.m_ButtonOK, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_TextBoxHostIP, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_LabelPlayerName;
        private System.Windows.Forms.TextBox m_TextBoxPlayerName;
        private System.Windows.Forms.Button m_ButtonOK;
        private System.Windows.Forms.TextBox m_TextBoxHostIP;
        private System.Windows.Forms.Label label2;
    }
}