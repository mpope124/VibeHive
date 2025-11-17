using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VibeHiveDEV422Midterm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void musicRentalServiceButton_Click(object sender, EventArgs e)
        {
            MusicRentalServiceForm musicRentalServiceForm = new MusicRentalServiceForm();
            musicRentalServiceForm.Show();
            this.Hide();
        }

        private void albumInventoryMenuButton_Click(object sender, EventArgs e)
        {
            AlbumInventoryForm albumInventoryForm = new AlbumInventoryForm();
            albumInventoryForm.Show();
            this.Hide();
        }

        private void playlistBuilderMenuButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Start VibeHive
                //string vibeHiveExe = @"..\..\..\VibeHiveDEV422Midterm\bin\Debug\VibeHiveDEV422Midterm.exe";
                //Process.Start(vibeHiveExe);

                // Start Playlist Builder
                string playlistExe = @"..\..\..\CollaborativePlaylistBuilder\CollaborativePlaylistBuilder.WinForms\bin\Debug\net8.0-windows\CollaborativePlaylistBuilder.WinForms.exe";
                Process.Start(playlistExe);

                this.Close(); // Optional: close current form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start apps: {ex.Message}");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
