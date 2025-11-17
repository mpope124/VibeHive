using System.Windows.Forms;

namespace VibeHiveDEV422Midterm
{
    partial class Form1
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
            this.musicRentalServiceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.albumInventoryMenuButton = new System.Windows.Forms.Button();
            this.playlistBuilderMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // musicRentalServiceButton
            // 
            this.musicRentalServiceButton.Location = new System.Drawing.Point(82, 167);
            this.musicRentalServiceButton.Name = "musicRentalServiceButton";
            this.musicRentalServiceButton.Size = new System.Drawing.Size(206, 23);
            this.musicRentalServiceButton.TabIndex = 0;
            this.musicRentalServiceButton.Text = "Music Rental Service Menu";
            this.musicRentalServiceButton.UseVisualStyleBackColor = true;
            this.musicRentalServiceButton.Click += new System.EventHandler(this.musicRentalServiceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 135);
            this.label1.TabIndex = 1;
            this.label1.Text = "VibeHive";
            // 
            // albumInventoryMenuButton
            // 
            this.albumInventoryMenuButton.Location = new System.Drawing.Point(82, 196);
            this.albumInventoryMenuButton.Name = "albumInventoryMenuButton";
            this.albumInventoryMenuButton.Size = new System.Drawing.Size(206, 23);
            this.albumInventoryMenuButton.TabIndex = 2;
            this.albumInventoryMenuButton.Text = "Album Inventory Menu";
            this.albumInventoryMenuButton.UseVisualStyleBackColor = true;
            this.albumInventoryMenuButton.Click += new System.EventHandler(this.albumInventoryMenuButton_Click);
            // 
            // playlistBuilderMenuButton
            // 
            this.playlistBuilderMenuButton.Location = new System.Drawing.Point(82, 225);
            this.playlistBuilderMenuButton.Name = "playlistBuilderMenuButton";
            this.playlistBuilderMenuButton.Size = new System.Drawing.Size(206, 23);
            this.playlistBuilderMenuButton.TabIndex = 3;
            this.playlistBuilderMenuButton.Text = "Playlist Builder Menu";
            this.playlistBuilderMenuButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.playlistBuilderMenuButton);
            this.Controls.Add(this.albumInventoryMenuButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.musicRentalServiceButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button musicRentalServiceButton;
        private Label label1;
        private Button albumInventoryMenuButton;
        private Button playlistBuilderMenuButton;
    }
}

