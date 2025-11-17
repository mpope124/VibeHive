using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
