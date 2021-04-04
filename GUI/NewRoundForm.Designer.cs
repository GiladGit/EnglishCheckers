namespace GUI
{
    partial class NewRoundForm
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
            this.m_GroupBoxBoardSize = new System.Windows.Forms.GroupBox();
            this.m_RadioButton10 = new System.Windows.Forms.RadioButton();
            this.m_RadioButton8 = new System.Windows.Forms.RadioButton();
            this.m_RadioButton6 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_ButtonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_GroupBoxBoardSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_GroupBoxBoardSize
            // 
            this.m_GroupBoxBoardSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_GroupBoxBoardSize.Controls.Add(this.m_RadioButton10);
            this.m_GroupBoxBoardSize.Controls.Add(this.m_RadioButton8);
            this.m_GroupBoxBoardSize.Controls.Add(this.m_RadioButton6);
            this.m_GroupBoxBoardSize.Location = new System.Drawing.Point(116, 46);
            this.m_GroupBoxBoardSize.Name = "m_GroupBoxBoardSize";
            this.m_GroupBoxBoardSize.Size = new System.Drawing.Size(206, 43);
            this.m_GroupBoxBoardSize.TabIndex = 13;
            this.m_GroupBoxBoardSize.TabStop = false;
            // 
            // m_RadioButton10
            // 
            this.m_RadioButton10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_RadioButton10.AutoSize = true;
            this.m_RadioButton10.Location = new System.Drawing.Point(153, 16);
            this.m_RadioButton10.Name = "m_RadioButton10";
            this.m_RadioButton10.Size = new System.Drawing.Size(37, 17);
            this.m_RadioButton10.TabIndex = 7;
            this.m_RadioButton10.TabStop = true;
            this.m_RadioButton10.Text = "10";
            this.m_RadioButton10.UseVisualStyleBackColor = true;
            this.m_RadioButton10.CheckedChanged += new System.EventHandler(this.m_RadioButton10_CheckedChanged);
            // 
            // m_RadioButton8
            // 
            this.m_RadioButton8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_RadioButton8.AutoSize = true;
            this.m_RadioButton8.Location = new System.Drawing.Point(85, 16);
            this.m_RadioButton8.Name = "m_RadioButton8";
            this.m_RadioButton8.Size = new System.Drawing.Size(31, 17);
            this.m_RadioButton8.TabIndex = 6;
            this.m_RadioButton8.TabStop = true;
            this.m_RadioButton8.Text = "8";
            this.m_RadioButton8.UseVisualStyleBackColor = true;
            this.m_RadioButton8.CheckedChanged += new System.EventHandler(this.m_RadioButton8_CheckedChanged);
            // 
            // m_RadioButton6
            // 
            this.m_RadioButton6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_RadioButton6.AutoSize = true;
            this.m_RadioButton6.Location = new System.Drawing.Point(20, 16);
            this.m_RadioButton6.Name = "m_RadioButton6";
            this.m_RadioButton6.Size = new System.Drawing.Size(31, 17);
            this.m_RadioButton6.TabIndex = 5;
            this.m_RadioButton6.TabStop = true;
            this.m_RadioButton6.Text = "6";
            this.m_RadioButton6.UseVisualStyleBackColor = true;
            this.m_RadioButton6.CheckedChanged += new System.EventHandler(this.m_RadioButton6_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Board Size:";
            // 
            // m_ButtonOK
            // 
            this.m_ButtonOK.Location = new System.Drawing.Point(387, 46);
            this.m_ButtonOK.Name = "m_ButtonOK";
            this.m_ButtonOK.Size = new System.Drawing.Size(60, 42);
            this.m_ButtonOK.TabIndex = 14;
            this.m_ButtonOK.Text = "OK";
            this.m_ButtonOK.UseVisualStyleBackColor = true;
            this.m_ButtonOK.Click += new System.EventHandler(this.m_ButtonOK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(165, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "New Round";
            // 
            // NewRoundForm
            // 
            this.AcceptButton = this.m_ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_ButtonOK);
            this.Controls.Add(this.m_GroupBoxBoardSize);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewRoundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_GroupBoxBoardSize, 0);
            this.Controls.SetChildIndex(this.m_ButtonOK, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.m_GroupBoxBoardSize.ResumeLayout(false);
            this.m_GroupBoxBoardSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox m_GroupBoxBoardSize;
        private System.Windows.Forms.RadioButton m_RadioButton10;
        private System.Windows.Forms.RadioButton m_RadioButton8;
        private System.Windows.Forms.RadioButton m_RadioButton6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_ButtonOK;
        private System.Windows.Forms.Label label1;
    }
}