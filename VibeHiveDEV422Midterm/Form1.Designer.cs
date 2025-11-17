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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // musicRentalServiceButton
            // 
            this.musicRentalServiceButton.Location = new System.Drawing.Point(176, 219);
            this.musicRentalServiceButton.Margin = new System.Windows.Forms.Padding(2);
            this.musicRentalServiceButton.Name = "musicRentalServiceButton";
            this.musicRentalServiceButton.Size = new System.Drawing.Size(154, 19);
            this.musicRentalServiceButton.TabIndex = 0;
            this.musicRentalServiceButton.Text = "Music Rental Service Menu";
            this.musicRentalServiceButton.UseVisualStyleBackColor = true;
            this.musicRentalServiceButton.Click += new System.EventHandler(this.musicRentalServiceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 108);
            this.label1.TabIndex = 1;
            this.label1.Text = "VibeHive";
            // 
            // albumInventoryMenuButton
            // 
            this.albumInventoryMenuButton.Location = new System.Drawing.Point(289, 242);
            this.albumInventoryMenuButton.Margin = new System.Windows.Forms.Padding(2);
            this.albumInventoryMenuButton.Name = "albumInventoryMenuButton";
            this.albumInventoryMenuButton.Size = new System.Drawing.Size(154, 19);
            this.albumInventoryMenuButton.TabIndex = 2;
            this.albumInventoryMenuButton.Text = "Album Inventory Menu";
            this.albumInventoryMenuButton.UseVisualStyleBackColor = true;
            this.albumInventoryMenuButton.Click += new System.EventHandler(this.albumInventoryMenuButton_Click);
            // 
            // playlistBuilderMenuButton
            // 
            this.playlistBuilderMenuButton.Location = new System.Drawing.Point(387, 265);
            this.playlistBuilderMenuButton.Margin = new System.Windows.Forms.Padding(2);
            this.playlistBuilderMenuButton.Name = "playlistBuilderMenuButton";
            this.playlistBuilderMenuButton.Size = new System.Drawing.Size(154, 19);
            this.playlistBuilderMenuButton.TabIndex = 3;
            this.playlistBuilderMenuButton.Text = "Playlist Builder Menu";
            this.playlistBuilderMenuButton.UseVisualStyleBackColor = true;
            this.playlistBuilderMenuButton.Click += new System.EventHandler(this.playlistBuilderMenuButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(579, 307);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Professor: Uzman Rizi Bellevue College Fall 2025 Midterm Assignement";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(579, 320);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Students: Peter-Paul Troendle, Michael Pope, Nicholas Jones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 581);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playlistBuilderMenuButton);
            this.Controls.Add(this.albumInventoryMenuButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.musicRentalServiceButton);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private Label label2;
        private Label label3;
    }
}

