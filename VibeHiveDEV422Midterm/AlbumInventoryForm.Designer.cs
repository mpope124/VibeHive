namespace VibeHiveDEV422Midterm
{
    partial class AlbumInventoryForm
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
            this.txb_AlbumId = new System.Windows.Forms.TextBox();
            this.txb_AlbumTitle = new System.Windows.Forms.TextBox();
            this.txb_AlbumArtists = new System.Windows.Forms.TextBox();
            this.txb_AlbumGenre = new System.Windows.Forms.TextBox();
            this.txb_AlbumYear = new System.Windows.Forms.TextBox();
            this.chk_Available = new System.Windows.Forms.CheckBox();
            this.btn_AddAlbum = new System.Windows.Forms.Button();
            this.btn_UpdateAlbum = new System.Windows.Forms.Button();
            this.btn_DeleteAlbum = new System.Windows.Forms.Button();
            this.btn_ListAllAlbums = new System.Windows.Forms.Button();
            this.dataGridView_Albums = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_artists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_availability = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albums)).BeginInit();
            this.SuspendLayout();
            // 
            // txb_AlbumId
            // 
            this.txb_AlbumId.Location = new System.Drawing.Point(37, 71);
            this.txb_AlbumId.Name = "txb_AlbumId";
            this.txb_AlbumId.ReadOnly = true;
            this.txb_AlbumId.Size = new System.Drawing.Size(230, 20);
            this.txb_AlbumId.TabIndex = 99;
            this.txb_AlbumId.TabStop = false;
            // 
            // txb_AlbumTitle
            // 
            this.txb_AlbumTitle.Location = new System.Drawing.Point(273, 70);
            this.txb_AlbumTitle.Name = "txb_AlbumTitle";
            this.txb_AlbumTitle.Size = new System.Drawing.Size(100, 20);
            this.txb_AlbumTitle.TabIndex = 1;
            // 
            // txb_AlbumArtists
            // 
            this.txb_AlbumArtists.Location = new System.Drawing.Point(379, 70);
            this.txb_AlbumArtists.Name = "txb_AlbumArtists";
            this.txb_AlbumArtists.Size = new System.Drawing.Size(100, 20);
            this.txb_AlbumArtists.TabIndex = 2;
            // 
            // txb_AlbumGenre
            // 
            this.txb_AlbumGenre.Location = new System.Drawing.Point(485, 70);
            this.txb_AlbumGenre.Name = "txb_AlbumGenre";
            this.txb_AlbumGenre.Size = new System.Drawing.Size(100, 20);
            this.txb_AlbumGenre.TabIndex = 3;
            // 
            // txb_AlbumYear
            // 
            this.txb_AlbumYear.Location = new System.Drawing.Point(591, 70);
            this.txb_AlbumYear.Name = "txb_AlbumYear";
            this.txb_AlbumYear.Size = new System.Drawing.Size(100, 20);
            this.txb_AlbumYear.TabIndex = 4;
            // 
            // chk_Available
            // 
            this.chk_Available.AutoSize = true;
            this.chk_Available.Location = new System.Drawing.Point(697, 73);
            this.chk_Available.Name = "chk_Available";
            this.chk_Available.Size = new System.Drawing.Size(83, 17);
            this.chk_Available.TabIndex = 5;
            this.chk_Available.Text = "AVAILABLE";
            this.chk_Available.UseVisualStyleBackColor = true;
            // 
            // btn_AddAlbum
            // 
            this.btn_AddAlbum.Location = new System.Drawing.Point(273, 112);
            this.btn_AddAlbum.Name = "btn_AddAlbum";
            this.btn_AddAlbum.Size = new System.Drawing.Size(100, 23);
            this.btn_AddAlbum.TabIndex = 6;
            this.btn_AddAlbum.Text = "Add Album";
            this.btn_AddAlbum.UseVisualStyleBackColor = true;
            this.btn_AddAlbum.Click += new System.EventHandler(this.btn_AddAlbum_Click);
            // 
            // btn_UpdateAlbum
            // 
            this.btn_UpdateAlbum.Location = new System.Drawing.Point(379, 112);
            this.btn_UpdateAlbum.Name = "btn_UpdateAlbum";
            this.btn_UpdateAlbum.Size = new System.Drawing.Size(100, 23);
            this.btn_UpdateAlbum.TabIndex = 7;
            this.btn_UpdateAlbum.Text = "Update Album";
            this.btn_UpdateAlbum.UseVisualStyleBackColor = true;
            this.btn_UpdateAlbum.Click += new System.EventHandler(this.btn_UpdateAlbum_Click);
            // 
            // btn_DeleteAlbum
            // 
            this.btn_DeleteAlbum.Location = new System.Drawing.Point(485, 112);
            this.btn_DeleteAlbum.Name = "btn_DeleteAlbum";
            this.btn_DeleteAlbum.Size = new System.Drawing.Size(100, 23);
            this.btn_DeleteAlbum.TabIndex = 8;
            this.btn_DeleteAlbum.Text = "Delete Album";
            this.btn_DeleteAlbum.UseVisualStyleBackColor = true;
            this.btn_DeleteAlbum.Click += new System.EventHandler(this.btn_DeleteAlbum_Click);
            // 
            // btn_ListAllAlbums
            // 
            this.btn_ListAllAlbums.Location = new System.Drawing.Point(591, 112);
            this.btn_ListAllAlbums.Name = "btn_ListAllAlbums";
            this.btn_ListAllAlbums.Size = new System.Drawing.Size(100, 23);
            this.btn_ListAllAlbums.TabIndex = 9;
            this.btn_ListAllAlbums.Text = "List All Albums";
            this.btn_ListAllAlbums.UseVisualStyleBackColor = true;
            this.btn_ListAllAlbums.Click += new System.EventHandler(this.btn_ListAllAlbums_Click);
            // 
            // dataGridView_Albums
            // 
            this.dataGridView_Albums.AllowUserToAddRows = false;
            this.dataGridView_Albums.AllowUserToDeleteRows = false;
            this.dataGridView_Albums.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Albums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Albums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_title,
            this.col_artists,
            this.col_genre,
            this.col_year,
            this.col_availability});
            this.dataGridView_Albums.Location = new System.Drawing.Point(37, 167);
            this.dataGridView_Albums.Name = "dataGridView_Albums";
            this.dataGridView_Albums.ReadOnly = true;
            this.dataGridView_Albums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Albums.Size = new System.Drawing.Size(732, 241);
            this.dataGridView_Albums.TabIndex = 7;
            this.dataGridView_Albums.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Albums_CellClick);
            this.dataGridView_Albums.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Albums_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Album ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Artist(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Year";
            // 
            // col_id
            // 
            this.col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_id.DataPropertyName = "Id";
            this.col_id.HeaderText = "ID";
            this.col_id.MinimumWidth = 250;
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Width = 250;
            // 
            // col_title
            // 
            this.col_title.DataPropertyName = "Title";
            this.col_title.HeaderText = "Title";
            this.col_title.Name = "col_title";
            this.col_title.ReadOnly = true;
            // 
            // col_artists
            // 
            this.col_artists.DataPropertyName = "Artists";
            this.col_artists.HeaderText = "Artist(s)";
            this.col_artists.Name = "col_artists";
            this.col_artists.ReadOnly = true;
            // 
            // col_genre
            // 
            this.col_genre.DataPropertyName = "Genre";
            this.col_genre.HeaderText = "Genre(s)";
            this.col_genre.Name = "col_genre";
            this.col_genre.ReadOnly = true;
            // 
            // col_year
            // 
            this.col_year.DataPropertyName = "Year";
            this.col_year.HeaderText = "Year";
            this.col_year.Name = "col_year";
            this.col_year.ReadOnly = true;
            // 
            // col_availability
            // 
            this.col_availability.DataPropertyName = "Available";
            this.col_availability.HeaderText = "Availability";
            this.col_availability.Name = "col_availability";
            this.col_availability.ReadOnly = true;
            this.col_availability.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_availability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AlbumInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Albums);
            this.Controls.Add(this.btn_ListAllAlbums);
            this.Controls.Add(this.btn_DeleteAlbum);
            this.Controls.Add(this.btn_UpdateAlbum);
            this.Controls.Add(this.btn_AddAlbum);
            this.Controls.Add(this.chk_Available);
            this.Controls.Add(this.txb_AlbumYear);
            this.Controls.Add(this.txb_AlbumGenre);
            this.Controls.Add(this.txb_AlbumArtists);
            this.Controls.Add(this.txb_AlbumTitle);
            this.Controls.Add(this.txb_AlbumId);
            this.Name = "AlbumInventoryForm";
            this.Text = "AlbumInventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_AlbumId;
        private System.Windows.Forms.TextBox txb_AlbumTitle;
        private System.Windows.Forms.TextBox txb_AlbumArtists;
        private System.Windows.Forms.TextBox txb_AlbumGenre;
        private System.Windows.Forms.TextBox txb_AlbumYear;
        private System.Windows.Forms.CheckBox chk_Available;
        private System.Windows.Forms.Button btn_AddAlbum;
        private System.Windows.Forms.Button btn_UpdateAlbum;
        private System.Windows.Forms.Button btn_DeleteAlbum;
        private System.Windows.Forms.Button btn_ListAllAlbums;
        private System.Windows.Forms.DataGridView dataGridView_Albums;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_artists;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_year;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_availability;
    }
}