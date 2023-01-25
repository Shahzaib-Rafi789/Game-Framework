
namespace Consumer
{
    partial class GameOver
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
            this.TryAgain = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TryAgain
            // 
            this.TryAgain.Location = new System.Drawing.Point(383, 369);
            this.TryAgain.Name = "TryAgain";
            this.TryAgain.Size = new System.Drawing.Size(75, 23);
            this.TryAgain.TabIndex = 0;
            this.TryAgain.Text = "Try Again";
            this.TryAgain.UseVisualStyleBackColor = true;
            this.TryAgain.Click += new System.EventHandler(this.TryAgain_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(474, 369);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Consumer.Properties.Resources.Game_Over;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.TryAgain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TryAgain;
        private System.Windows.Forms.Button Exit;
    }
}