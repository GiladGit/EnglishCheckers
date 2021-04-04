using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class GameForm
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
            this.m_ButtonExit = new System.Windows.Forms.Button();
            this.m_ButtonQuit = new System.Windows.Forms.Button();
            this.m_PlayerNameUp = new System.Windows.Forms.Label();
            this.m_PlayerNameDown = new System.Windows.Forms.Label();
            this.m_PlayerUpScore = new System.Windows.Forms.Label();
            this.m_PlayerDownScore = new System.Windows.Forms.Label();
            this.m_TableLayoutPanelBoard = new System.Windows.Forms.TableLayoutPanel();
            this.m_ButtonNewRound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonExit
            // 
            this.m_ButtonExit.Location = new System.Drawing.Point(-1, -2);
            this.m_ButtonExit.Name = "m_ButtonExit";
            this.m_ButtonExit.Size = new System.Drawing.Size(99, 69);
            this.m_ButtonExit.TabIndex = 0;
            this.m_ButtonExit.Text = "&Exit Game";
            this.m_ButtonExit.UseVisualStyleBackColor = true;
            this.m_ButtonExit.Click += new System.EventHandler(this.m_ButtonExit_Click);
            // 
            // m_ButtonQuit
            // 
            this.m_ButtonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_ButtonQuit.Location = new System.Drawing.Point(-1, 381);
            this.m_ButtonQuit.Name = "m_ButtonQuit";
            this.m_ButtonQuit.Size = new System.Drawing.Size(99, 69);
            this.m_ButtonQuit.TabIndex = 2;
            this.m_ButtonQuit.Text = "&Quit";
            this.m_ButtonQuit.UseVisualStyleBackColor = true;
            this.m_ButtonQuit.Click += new System.EventHandler(this.m_ButtonQuit_Click);
            // 
            // m_PlayerNameUp
            // 
            this.m_PlayerNameUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_PlayerNameUp.AutoSize = true;
            this.m_PlayerNameUp.Location = new System.Drawing.Point(331, 26);
            this.m_PlayerNameUp.Name = "m_PlayerNameUp";
            this.m_PlayerNameUp.Size = new System.Drawing.Size(50, 13);
            this.m_PlayerNameUp.TabIndex = 4;
            this.m_PlayerNameUp.Text = "PlayerUp";
            // 
            // m_PlayerNameDown
            // 
            this.m_PlayerNameDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_PlayerNameDown.AutoSize = true;
            this.m_PlayerNameDown.Location = new System.Drawing.Point(331, 409);
            this.m_PlayerNameDown.Name = "m_PlayerNameDown";
            this.m_PlayerNameDown.Size = new System.Drawing.Size(64, 13);
            this.m_PlayerNameDown.TabIndex = 5;
            this.m_PlayerNameDown.Text = "PlayerDown";
            // 
            // m_PlayerUpScore
            // 
            this.m_PlayerUpScore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_PlayerUpScore.AutoSize = true;
            this.m_PlayerUpScore.Location = new System.Drawing.Point(401, 26);
            this.m_PlayerUpScore.Name = "m_PlayerUpScore";
            this.m_PlayerUpScore.Size = new System.Drawing.Size(13, 13);
            this.m_PlayerUpScore.TabIndex = 6;
            this.m_PlayerUpScore.Text = "0";
            // 
            // m_PlayerDownScore
            // 
            this.m_PlayerDownScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_PlayerDownScore.AutoSize = true;
            this.m_PlayerDownScore.Location = new System.Drawing.Point(410, 409);
            this.m_PlayerDownScore.Name = "m_PlayerDownScore";
            this.m_PlayerDownScore.Size = new System.Drawing.Size(13, 13);
            this.m_PlayerDownScore.TabIndex = 7;
            this.m_PlayerDownScore.Text = "0";
            // 
            // m_TableLayoutPanelBoard
            // 
            this.m_TableLayoutPanelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TableLayoutPanelBoard.ColumnCount = 1;
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelBoard.Location = new System.Drawing.Point(-1, 66);
            this.m_TableLayoutPanelBoard.Name = "m_TableLayoutPanelBoard";
            this.m_TableLayoutPanelBoard.RowCount = 1;
            this.m_TableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.m_TableLayoutPanelBoard.Size = new System.Drawing.Size(803, 315);
            this.m_TableLayoutPanelBoard.TabIndex = 3;
            // 
            // m_ButtonNewRound
            // 
            this.m_ButtonNewRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonNewRound.Location = new System.Drawing.Point(703, 381);
            this.m_ButtonNewRound.Name = "m_ButtonNewRound";
            this.m_ButtonNewRound.Size = new System.Drawing.Size(99, 69);
            this.m_ButtonNewRound.TabIndex = 1;
            this.m_ButtonNewRound.Text = "&New Round";
            this.m_ButtonNewRound.UseVisualStyleBackColor = true;
            this.m_ButtonNewRound.Click += new System.EventHandler(this.m_ButtonNewRound_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_ButtonNewRound);
            this.Controls.Add(this.m_ButtonQuit);
            this.Controls.Add(this.m_PlayerDownScore);
            this.Controls.Add(this.m_PlayerUpScore);
            this.Controls.Add(this.m_PlayerNameDown);
            this.Controls.Add(this.m_PlayerNameUp);
            this.Controls.Add(this.m_TableLayoutPanelBoard);
            this.Controls.Add(this.m_ButtonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ButtonExit;
        private System.Windows.Forms.Button m_ButtonQuit;
        private System.Windows.Forms.Label m_PlayerNameUp;
        private System.Windows.Forms.Label m_PlayerNameDown;
        private System.Windows.Forms.Label m_PlayerUpScore;
        private System.Windows.Forms.Label m_PlayerDownScore;
        private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanelBoard;
        private Button m_ButtonNewRound;

        private void InitializeComponentExtras()
        {
            m_TableLayoutPanelBoard.ColumnCount = BoardSize;
            m_TableLayoutPanelBoard.RowCount = BoardSize;
            m_TableLayoutPanelBoard.Controls.Clear();
            m_TableLayoutPanelBoard.ColumnStyles.Clear();
            m_TableLayoutPanelBoard.RowStyles.Clear();

            SlotButton button;
            for (int row = 0; row < BoardSize; row++)
            {
                m_TableLayoutPanelBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / (float)BoardSize));
                m_TableLayoutPanelBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / (float)BoardSize));

                for (int col = 0; col < BoardSize; col++)
                {
                    button = new SlotButton((byte)row, (byte)col);
                    button.Click += slotButton_Click;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0); 
                    m_TableLayoutPanelBoard.Controls.Add(button);
                }
            }
        }


    }
}