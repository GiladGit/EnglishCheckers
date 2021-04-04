namespace GUI
{
    partial class GameInfoOfflineForm
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
            this.m_RadioButtonPvP = new System.Windows.Forms.RadioButton();
            this.m_RadioButtonPvPC = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_TextboxWhiteName = new System.Windows.Forms.TextBox();
            this.m_TextboxBlackName = new System.Windows.Forms.TextBox();
            this.m_ButtonPlay = new System.Windows.Forms.Button();
            this.m_RadioButtonPCvPC = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_RadioButtonPvP
            // 
            this.m_RadioButtonPvP.AutoSize = true;
            this.m_RadioButtonPvP.Checked = true;
            this.m_RadioButtonPvP.Location = new System.Drawing.Point(7, 27);
            this.m_RadioButtonPvP.Name = "m_RadioButtonPvP";
            this.m_RadioButtonPvP.Size = new System.Drawing.Size(100, 17);
            this.m_RadioButtonPvP.TabIndex = 1;
            this.m_RadioButtonPvP.TabStop = true;
            this.m_RadioButtonPvP.Text = "Player vs Player";
            this.m_RadioButtonPvP.UseVisualStyleBackColor = true;
            this.m_RadioButtonPvP.CheckedChanged += new System.EventHandler(this.m_RadioButtonPvP_CheckedChanged);
            // 
            // m_RadioButtonPvPC
            // 
            this.m_RadioButtonPvPC.AutoSize = true;
            this.m_RadioButtonPvPC.Location = new System.Drawing.Point(7, 62);
            this.m_RadioButtonPvPC.Name = "m_RadioButtonPvPC";
            this.m_RadioButtonPvPC.Size = new System.Drawing.Size(85, 17);
            this.m_RadioButtonPvPC.TabIndex = 2;
            this.m_RadioButtonPvPC.Text = "Player vs PC";
            this.m_RadioButtonPvPC.UseVisualStyleBackColor = true;
            this.m_RadioButtonPvPC.CheckedChanged += new System.EventHandler(this.m_RadioButtonPvPC_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "White Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Black Player Name:";
            // 
            // m_TextboxWhiteName
            // 
            this.m_TextboxWhiteName.Location = new System.Drawing.Point(136, 213);
            this.m_TextboxWhiteName.Name = "m_TextboxWhiteName";
            this.m_TextboxWhiteName.Size = new System.Drawing.Size(98, 20);
            this.m_TextboxWhiteName.TabIndex = 5;
            // 
            // m_TextboxBlackName
            // 
            this.m_TextboxBlackName.Location = new System.Drawing.Point(136, 261);
            this.m_TextboxBlackName.Name = "m_TextboxBlackName";
            this.m_TextboxBlackName.Size = new System.Drawing.Size(98, 20);
            this.m_TextboxBlackName.TabIndex = 6;
            // 
            // m_ButtonPlay
            // 
            this.m_ButtonPlay.Location = new System.Drawing.Point(289, 232);
            this.m_ButtonPlay.Name = "m_ButtonPlay";
            this.m_ButtonPlay.Size = new System.Drawing.Size(82, 42);
            this.m_ButtonPlay.TabIndex = 7;
            this.m_ButtonPlay.Text = "Play!";
            this.m_ButtonPlay.UseVisualStyleBackColor = true;
            this.m_ButtonPlay.Click += new System.EventHandler(this.m_ButtonPlay_Click);
            // 
            // m_RadioButtonPCvPC
            // 
            this.m_RadioButtonPCvPC.AutoSize = true;
            this.m_RadioButtonPCvPC.Location = new System.Drawing.Point(7, 97);
            this.m_RadioButtonPCvPC.Name = "m_RadioButtonPCvPC";
            this.m_RadioButtonPCvPC.Size = new System.Drawing.Size(70, 17);
            this.m_RadioButtonPCvPC.TabIndex = 8;
            this.m_RadioButtonPCvPC.TabStop = true;
            this.m_RadioButtonPCvPC.Text = "PC vs PC";
            this.m_RadioButtonPCvPC.UseVisualStyleBackColor = true;
            this.m_RadioButtonPCvPC.CheckedChanged += new System.EventHandler(this.m_RadioButtonPCvPC_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_RadioButtonPCvPC);
            this.groupBox1.Controls.Add(this.m_RadioButtonPvPC);
            this.groupBox1.Controls.Add(this.m_RadioButtonPvP);
            this.groupBox1.Location = new System.Drawing.Point(21, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 127);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Mode:";
            // 
            // GameInfoOfflineForm
            // 
            this.AcceptButton = this.m_ButtonPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_ButtonPlay);
            this.Controls.Add(this.m_TextboxBlackName);
            this.Controls.Add(this.m_TextboxWhiteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameInfoOfflineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_TextboxWhiteName, 0);
            this.Controls.SetChildIndex(this.m_TextboxBlackName, 0);
            this.Controls.SetChildIndex(this.m_ButtonPlay, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton m_RadioButtonPvP;
        private System.Windows.Forms.RadioButton m_RadioButtonPvPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_TextboxWhiteName;
        private System.Windows.Forms.TextBox m_TextboxBlackName;
        private System.Windows.Forms.Button m_ButtonPlay;
        private System.Windows.Forms.RadioButton m_RadioButtonPCvPC;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}