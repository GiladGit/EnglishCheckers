namespace GUI
{
    partial class PlayOnlineForm
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
            this.m_ButtonHostGame = new System.Windows.Forms.Button();
            this.m_ButtonJoinGame = new System.Windows.Forms.Button();
            this.m_LabelPlayOnline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_ButtonHostGame
            // 
            this.m_ButtonHostGame.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_ButtonHostGame.Location = new System.Drawing.Point(187, 140);
            this.m_ButtonHostGame.Name = "m_ButtonHostGame";
            this.m_ButtonHostGame.Size = new System.Drawing.Size(433, 86);
            this.m_ButtonHostGame.TabIndex = 2;
            this.m_ButtonHostGame.Text = "&Host Game";
            this.m_ButtonHostGame.UseVisualStyleBackColor = true;
            this.m_ButtonHostGame.Click += new System.EventHandler(this.m_ButtonHostGame_Click);
            // 
            // m_ButtonJoinGame
            // 
            this.m_ButtonJoinGame.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_ButtonJoinGame.Location = new System.Drawing.Point(187, 264);
            this.m_ButtonJoinGame.Name = "m_ButtonJoinGame";
            this.m_ButtonJoinGame.Size = new System.Drawing.Size(433, 86);
            this.m_ButtonJoinGame.TabIndex = 3;
            this.m_ButtonJoinGame.Text = "&Join Game";
            this.m_ButtonJoinGame.UseVisualStyleBackColor = true;
            this.m_ButtonJoinGame.Click += new System.EventHandler(this.m_ButtonJoinGame_Click);
            // 
            // m_LabelPlayOnline
            // 
            this.m_LabelPlayOnline.AutoSize = true;
            this.m_LabelPlayOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_LabelPlayOnline.Location = new System.Drawing.Point(298, 38);
            this.m_LabelPlayOnline.Name = "m_LabelPlayOnline";
            this.m_LabelPlayOnline.Size = new System.Drawing.Size(224, 46);
            this.m_LabelPlayOnline.TabIndex = 4;
            this.m_LabelPlayOnline.Text = "Play Online";
            // 
            // PlayOnlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_LabelPlayOnline);
            this.Controls.Add(this.m_ButtonJoinGame);
            this.Controls.Add(this.m_ButtonHostGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PlayOnlineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.m_ButtonHostGame, 0);
            this.Controls.SetChildIndex(this.m_ButtonJoinGame, 0);
            this.Controls.SetChildIndex(this.m_LabelPlayOnline, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonHostGame;
        private System.Windows.Forms.Button m_ButtonJoinGame;
        private System.Windows.Forms.Label m_LabelPlayOnline;
    }
}