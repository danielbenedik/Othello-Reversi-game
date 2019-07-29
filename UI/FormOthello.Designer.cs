namespace Ex05_OtheloFormsApp
{
    partial class FormOthelloSetting
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.BoardSize = new System.Windows.Forms.Button();
            this.AgainstFriend = new System.Windows.Forms.Button();
            this.AgainstComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.Location = new System.Drawing.Point(12, 22);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(352, 42);
            this.BoardSize.TabIndex = 300;
            this.BoardSize.Text = "Board Size: 6x6 (click to increase)";
            this.BoardSize.UseVisualStyleBackColor = true;
            this.BoardSize.Click += new System.EventHandler(this.BoardSize_Click);
            // 
            // AgainstFriend
            // 
            this.AgainstFriend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AgainstFriend.Location = new System.Drawing.Point(192, 88);
            this.AgainstFriend.Name = "AgainstFriend";
            this.AgainstFriend.Size = new System.Drawing.Size(174, 42);
            this.AgainstFriend.TabIndex = 200;
            this.AgainstFriend.Text = "Play against your friend";
            this.AgainstFriend.UseVisualStyleBackColor = true;
            this.AgainstFriend.Click += new System.EventHandler(this.AgainstFriend_Click);
            // 
            // AgainstComputer
            // 
            this.AgainstComputer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AgainstComputer.Location = new System.Drawing.Point(12, 88);
            this.AgainstComputer.Name = "AgainstComputer";
            this.AgainstComputer.Size = new System.Drawing.Size(174, 42);
            this.AgainstComputer.TabIndex = 100;
            this.AgainstComputer.Text = "Play against the computer";
            this.AgainstComputer.UseVisualStyleBackColor = true;
            this.AgainstComputer.Click += new System.EventHandler(this.AgainstComputer_Click);
            // 
            // FormOthelloSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 152);
            this.Controls.Add(this.AgainstComputer);
            this.Controls.Add(this.AgainstFriend);
            this.Controls.Add(this.BoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOthelloSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.Load += new System.EventHandler(this.FormOthelloSettings);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BoardSize;
        private System.Windows.Forms.Button AgainstFriend;
        private System.Windows.Forms.Button AgainstComputer;
    }
}