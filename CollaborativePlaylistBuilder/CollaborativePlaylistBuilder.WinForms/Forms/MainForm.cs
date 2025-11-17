using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaborativePlaylistBuilder.WinForms
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        // ✅ Correct API base URL
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:40341") };

        // Designer controls
        private GroupBox grpPlaylist;
        private Label lblPlaylistName;
        private TextBox txtPlaylistName;
        private CheckBox chkCollaborative;
        private Button btnCreatePlaylist;
        private ComboBox cmbPlaylists;

        private GroupBox grpSongs;
        private Label lblSongTitle;
        private Label lblSongArtist;
        private Label lblSongGenre;
        private TextBox txtSongTitle;
        private TextBox txtSongArtist;
        private TextBox txtSongGenre;
        private Button btnAddSong;
        private DataGridView dgvSongs;

        private GroupBox grpCollaboration;
        private Label lblInviteUser;
        private TextBox txtInviteUser;
        private Button btnInvite;

        private GroupBox grpVoting;
        private Button btnVote;
        private Button btnRankings;
        private DataGridView dgvRankings;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpPlaylist = new GroupBox();
            lblPlaylistName = new Label();
            txtPlaylistName = new TextBox();
            chkCollaborative = new CheckBox();
            btnCreatePlaylist = new Button();
            cmbPlaylists = new ComboBox();
            grpSongs = new GroupBox();
            lblSongTitle = new Label();
            txtSongTitle = new TextBox();
            lblSongArtist = new Label();
            txtSongArtist = new TextBox();
            lblSongGenre = new Label();
            txtSongGenre = new TextBox();
            btnAddSong = new Button();
            dgvSongs = new DataGridView();
            grpCollaboration = new GroupBox();
            lblInviteUser = new Label();
            txtInviteUser = new TextBox();
            btnInvite = new Button();
            grpVoting = new GroupBox();
            btnVote = new Button();
            btnRankings = new Button();
            dgvRankings = new DataGridView();
            grpPlaylist.SuspendLayout();
            grpSongs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            grpCollaboration.SuspendLayout();
            grpVoting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRankings).BeginInit();
            SuspendLayout();
            // 
            // grpPlaylist
            // 
            grpPlaylist.Controls.Add(lblPlaylistName);
            grpPlaylist.Controls.Add(txtPlaylistName);
            grpPlaylist.Controls.Add(chkCollaborative);
            grpPlaylist.Controls.Add(btnCreatePlaylist);
            grpPlaylist.Controls.Add(cmbPlaylists);
            grpPlaylist.Location = new System.Drawing.Point(12, 12);
            grpPlaylist.Name = "grpPlaylist";
            grpPlaylist.Size = new System.Drawing.Size(350, 150);
            grpPlaylist.TabIndex = 0;
            grpPlaylist.TabStop = false;
            grpPlaylist.Text = "Playlist";
            // 
            // lblPlaylistName
            // 
            lblPlaylistName.Location = new System.Drawing.Point(10, 25);
            lblPlaylistName.Name = "lblPlaylistName";
            lblPlaylistName.Size = new System.Drawing.Size(100, 23);
            lblPlaylistName.TabIndex = 0;
            lblPlaylistName.Text = "Name:";
            // 
            // txtPlaylistName
            // 
            txtPlaylistName.Location = new System.Drawing.Point(70, 22);
            txtPlaylistName.Name = "txtPlaylistName";
            txtPlaylistName.RightToLeft = RightToLeft.No;
            txtPlaylistName.Size = new System.Drawing.Size(150, 23);
            txtPlaylistName.TabIndex = 1;
            txtPlaylistName.TextAlign = HorizontalAlignment.Center;
            txtPlaylistName.TextChanged += txtPlaylistName_TextChanged;
            // 
            // chkCollaborative
            // 
            chkCollaborative.Location = new System.Drawing.Point(10, 55);
            chkCollaborative.Name = "chkCollaborative";
            chkCollaborative.Size = new System.Drawing.Size(104, 24);
            chkCollaborative.TabIndex = 2;
            chkCollaborative.Text = "Collaborative";
            // 
            // btnCreatePlaylist
            // 
            btnCreatePlaylist.Location = new System.Drawing.Point(10, 85);
            btnCreatePlaylist.Name = "btnCreatePlaylist";
            btnCreatePlaylist.Size = new System.Drawing.Size(150, 30);
            btnCreatePlaylist.TabIndex = 3;
            btnCreatePlaylist.Text = "Create Playlist";
            btnCreatePlaylist.Click += btnCreatePlaylist_Click;
            // 
            // cmbPlaylists
            // 
            cmbPlaylists.Location = new System.Drawing.Point(170, 85);
            cmbPlaylists.Name = "cmbPlaylists";
            cmbPlaylists.Size = new System.Drawing.Size(150, 23);
            cmbPlaylists.TabIndex = 4;
            // 
            // grpSongs
            // 
            grpSongs.Controls.Add(lblSongTitle);
            grpSongs.Controls.Add(txtSongTitle);
            grpSongs.Controls.Add(lblSongArtist);
            grpSongs.Controls.Add(txtSongArtist);
            grpSongs.Controls.Add(lblSongGenre);
            grpSongs.Controls.Add(txtSongGenre);
            grpSongs.Controls.Add(btnAddSong);
            grpSongs.Controls.Add(dgvSongs);
            grpSongs.Location = new System.Drawing.Point(12, 170);
            grpSongs.Name = "grpSongs";
            grpSongs.Size = new System.Drawing.Size(500, 250);
            grpSongs.TabIndex = 1;
            grpSongs.TabStop = false;
            grpSongs.Text = "Songs";
            // 
            // lblSongTitle
            // 
            lblSongTitle.Location = new System.Drawing.Point(6, 19);
            lblSongTitle.Name = "lblSongTitle";
            lblSongTitle.Size = new System.Drawing.Size(100, 23);
            lblSongTitle.TabIndex = 0;
            lblSongTitle.Text = "Title:";
            // 
            // txtSongTitle
            // 
            txtSongTitle.Location = new System.Drawing.Point(10, 45);
            txtSongTitle.Name = "txtSongTitle";
            txtSongTitle.RightToLeft = RightToLeft.No;
            txtSongTitle.Size = new System.Drawing.Size(120, 23);
            txtSongTitle.TabIndex = 1;
            txtSongTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSongArtist
            // 
            lblSongArtist.Location = new System.Drawing.Point(136, 19);
            lblSongArtist.Name = "lblSongArtist";
            lblSongArtist.Size = new System.Drawing.Size(100, 23);
            lblSongArtist.TabIndex = 2;
            lblSongArtist.Text = "Artist:";
            // 
            // txtSongArtist
            // 
            txtSongArtist.Location = new System.Drawing.Point(136, 45);
            txtSongArtist.Name = "txtSongArtist";
            txtSongArtist.RightToLeft = RightToLeft.No;
            txtSongArtist.Size = new System.Drawing.Size(120, 23);
            txtSongArtist.TabIndex = 3;
            txtSongArtist.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSongGenre
            // 
            lblSongGenre.Location = new System.Drawing.Point(250, 19);
            lblSongGenre.Name = "lblSongGenre";
            lblSongGenre.Size = new System.Drawing.Size(100, 23);
            lblSongGenre.TabIndex = 4;
            lblSongGenre.Text = "Genre:";
            // 
            // txtSongGenre
            // 
            txtSongGenre.Location = new System.Drawing.Point(262, 45);
            txtSongGenre.Name = "txtSongGenre";
            txtSongGenre.RightToLeft = RightToLeft.No;
            txtSongGenre.Size = new System.Drawing.Size(115, 23);
            txtSongGenre.TabIndex = 5;
            txtSongGenre.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddSong
            // 
            btnAddSong.Location = new System.Drawing.Point(383, 45);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new System.Drawing.Size(107, 30);
            btnAddSong.TabIndex = 6;
            btnAddSong.Text = "Add Song";
            btnAddSong.Click += btnAddSong_Click;
            // 
            // dgvSongs
            // 
            dgvSongs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSongs.Location = new System.Drawing.Point(10, 95);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.Size = new System.Drawing.Size(480, 140);
            dgvSongs.TabIndex = 7;
            // 
            // grpCollaboration
            // 
            grpCollaboration.Controls.Add(lblInviteUser);
            grpCollaboration.Controls.Add(txtInviteUser);
            grpCollaboration.Controls.Add(btnInvite);
            grpCollaboration.Location = new System.Drawing.Point(370, 12);
            grpCollaboration.Name = "grpCollaboration";
            grpCollaboration.Size = new System.Drawing.Size(250, 150);
            grpCollaboration.TabIndex = 2;
            grpCollaboration.TabStop = false;
            grpCollaboration.Text = "Collaboration";
            // 
            // lblInviteUser
            // 
            lblInviteUser.Location = new System.Drawing.Point(10, 25);
            lblInviteUser.Name = "lblInviteUser";
            lblInviteUser.Size = new System.Drawing.Size(100, 23);
            lblInviteUser.TabIndex = 0;
            lblInviteUser.Text = "User ID:";
            // 
            // txtInviteUser
            // 
            txtInviteUser.Location = new System.Drawing.Point(70, 22);
            txtInviteUser.Name = "txtInviteUser";
            txtInviteUser.RightToLeft = RightToLeft.No;
            txtInviteUser.Size = new System.Drawing.Size(150, 23);
            txtInviteUser.TabIndex = 1;
            txtInviteUser.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInvite
            // 
            btnInvite.Location = new System.Drawing.Point(10, 55);
            btnInvite.Name = "btnInvite";
            btnInvite.Size = new System.Drawing.Size(150, 30);
            btnInvite.TabIndex = 2;
            btnInvite.Text = "Invite User";
            btnInvite.Click += btnInvite_Click;
            // 
            // grpVoting
            // 
            grpVoting.Controls.Add(btnVote);
            grpVoting.Controls.Add(btnRankings);
            grpVoting.Controls.Add(dgvRankings);
            grpVoting.Location = new System.Drawing.Point(520, 170);
            grpVoting.Name = "grpVoting";
            grpVoting.Size = new System.Drawing.Size(350, 250);
            grpVoting.TabIndex = 3;
            grpVoting.TabStop = false;
            grpVoting.Text = "Voting";
            // 
            // btnVote
            // 
            btnVote.Location = new System.Drawing.Point(10, 25);
            btnVote.Name = "btnVote";
            btnVote.Size = new System.Drawing.Size(150, 30);
            btnVote.TabIndex = 0;
            btnVote.Text = "Vote Song";
            btnVote.Click += btnVote_Click;
            // 
            // btnRankings
            // 
            btnRankings.Location = new System.Drawing.Point(170, 25);
            btnRankings.Name = "btnRankings";
            btnRankings.Size = new System.Drawing.Size(150, 30);
            btnRankings.TabIndex = 1;
            btnRankings.Text = "Show Rankings";
            btnRankings.Click += btnRankings_Click;
            // 
            // dgvRankings
            // 
            dgvRankings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRankings.Location = new System.Drawing.Point(10, 65);
            dgvRankings.Name = "dgvRankings";
            dgvRankings.Size = new System.Drawing.Size(330, 170);
            dgvRankings.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(900, 450);
            Controls.Add(grpPlaylist);
            Controls.Add(grpSongs);
            Controls.Add(grpCollaboration);
            Controls.Add(grpVoting);
            Name = "MainForm";
            Text = "Collaborative Playlist Builder";
            Load += MainForm_Load;
            grpPlaylist.ResumeLayout(false);
            grpPlaylist.PerformLayout();
            grpSongs.ResumeLayout(false);
            grpSongs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            grpCollaboration.ResumeLayout(false);
            grpCollaboration.PerformLayout();
            grpVoting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRankings).EndInit();
            ResumeLayout(false);
        }

        // ✅ Logic for API integration with error handling
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadPlaylists();
        }

        private async void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                var playlistName = txtPlaylistName.Text;
                var isCollaborative = chkCollaborative.Checked;

                var response = await _httpClient.PostAsJsonAsync("/api/playlists", new
                {
                    name = playlistName,
                    isCollaborative = isCollaborative,
                    createdBy = 1 // ✅ integer ID
                });

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Playlist created successfully!");
                    await LoadPlaylists();
                }
                else
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error creating playlist:\n{errorDetails}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void btnAddSong_Click(object sender, EventArgs e)
        {
            if (cmbPlaylists.SelectedItem == null)
            {
                MessageBox.Show("Select a playlist first.");
                return;
            }

            var playlistId = ((Playlist)cmbPlaylists.SelectedItem).Id;

            try
            {
                var song = new
                {
                    title = txtSongTitle.Text,
                    artist = txtSongArtist.Text,
                    genre = txtSongGenre.Text
                };

                var response = await _httpClient.PutAsJsonAsync($"/api/playlists/{playlistId}/add", song);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Song added successfully!");
                    await LoadSongs(playlistId);
                }
                else
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error adding song:\n{errorDetails}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void btnInvite_Click(object sender, EventArgs e)
        {
            if (cmbPlaylists.SelectedItem == null)
            {
                MessageBox.Show("Select a playlist first.");
                return;
            }

            var playlistId = ((Playlist)cmbPlaylists.SelectedItem).Id;
            var userId = txtInviteUser.Text;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/playlists/{playlistId}/invite", new { userId });

                MessageBox.Show(response.IsSuccessStatusCode ? "User invited!" : "Error inviting user.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void btnVote_Click(object sender, EventArgs e)
        {
            if (cmbPlaylists.SelectedItem == null || dgvSongs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a playlist and a song first.");
                return;
            }

            var playlistId = ((Playlist)cmbPlaylists.SelectedItem).Id;
            var songId = ((Song)dgvSongs.SelectedRows[0].DataBoundItem).Id;

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/playlists/{playlistId}/vote", new { songId });

                MessageBox.Show(response.IsSuccessStatusCode ? "Vote recorded!" : "Error voting.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void btnRankings_Click(object sender, EventArgs e)
        {
            if (cmbPlaylists.SelectedItem == null)
            {
                MessageBox.Show("Select a playlist first.");
                return;
            }

            var playlistId = ((Playlist)cmbPlaylists.SelectedItem).Id;

            try
            {
                var rankings = await _httpClient.GetFromJsonAsync<List<Song>>($"/api/playlists/{playlistId}/rankings");
                dgvRankings.DataSource = rankings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async Task LoadPlaylists()
        {
            try
            {
                var playlists = await _httpClient.GetFromJsonAsync<List<Playlist>>("/api/playlists");
                cmbPlaylists.DataSource = playlists;
                cmbPlaylists.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot load playlists: {ex.Message}");
            }
        }

        private async Task LoadSongs(int playlistId)
        {
            try
            {
                var playlists = await _httpClient.GetFromJsonAsync<List<Playlist>>("/api/playlists");
                var playlist = playlists.Find(p => p.Id == playlistId);
                dgvSongs.DataSource = playlist?.Songs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot load songs: {ex.Message}");
            }
        }

        private void txtPlaylistName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // Models
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCollaborative { get; set; }
        public List<Song> Songs { get; set; }
    }

    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Votes { get; set; }
    }
}