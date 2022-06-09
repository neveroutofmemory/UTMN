
namespace TicTacToe
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameFieldPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameFieldPicBox
            // 
            this.gameFieldPicBox.Location = new System.Drawing.Point(12, 12);
            this.gameFieldPicBox.Name = "gameFieldPicBox";
            this.gameFieldPicBox.Size = new System.Drawing.Size(480, 461);
            this.gameFieldPicBox.TabIndex = 0;
            this.gameFieldPicBox.TabStop = false;
            this.gameFieldPicBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameFieldPicBox_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(504, 485);
            this.Controls.Add(this.gameFieldPicBox);
            this.Enabled = false;
            this.Name = "MainForm";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Tic Tac Toe";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameFieldPicBox;
    }
}

