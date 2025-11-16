using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace VibeHiveDEV422Midterm
{
    public partial class MusicRentalServiceForm : Form
    {
        private readonly HttpClient _httpClient;

        public MusicRentalServiceForm()
        {
            InitializeComponent();

            _httpClient = new HttpClient

            {
                BaseAddress = new Uri("https://localhost:7251/")
            };
        }



        private void backToHomeButton_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void backToHomeButton_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private async void listAlbumButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Call GET /api/music
                var response = await _httpClient.GetAsync("api/music");
                response.EnsureSuccessStatusCode();

                // Read JSON as string
                var json = await response.Content.ReadAsStringAsync();

                // Deserialize JSON to List<Music> using Newtonsoft.Json
                var albums = JsonConvert.DeserializeObject<List<Music>>(json);

                if (albums == null)
                {
                    MessageBox.Show("No albums found from the API.");
                    return;
                }

                // Bind to DataGridView
                listAlbumDataGridView.DataSource = null;
                listAlbumDataGridView.DataSource = albums;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error calling API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private async void addAlbumButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Reading and validate inputs.
                string title = albumTitleTextBox.Text.Trim();
                string artist = albumArtistTextBox.Text.Trim();
                string genre = albumGenreTextBox.Text.Trim();
                string albumYear = albumYearTextBox.Text.Trim();

                //checking to make sure each space is filled and correct
                if (string.IsNullOrWhiteSpace(title) ||
                    string.IsNullOrWhiteSpace(artist) ||
                    string.IsNullOrWhiteSpace(genre) ||
                    string.IsNullOrWhiteSpace(albumYear))
                {
                    MessageBox.Show("Please fill in Title, Artist, Genre, and Year.");
                    return;
                }

                if (!int.TryParse(albumYear, out int year))
                {
                    MessageBox.Show("Year must be a valid number.");
                    return;
                }

                // Creating a Music object to serialize
                var newAlbum = new Music
                {
                    Title = title,
                    Artist = artist,
                    Genre = genre,
                    Year = year,
                    Available = true
                };

                // Serialize to JSON
                var json = JsonConvert.SerializeObject(newAlbum);

                // Create HTTP content
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // POST to /api/music
                var response = await _httpClient.PostAsync("api/music", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to add album. Status: {response.StatusCode}\n{errorText}");
                    return;
                }

                MessageBox.Show("Album added successfully!");

                // Clearing input fields
                albumTitleTextBox.Text = "";
                albumArtistTextBox.Text = "";
                albumGenreTextBox.Text = "";
                albumYearTextBox.Text = "";
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error calling API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private async void rentAlbumButton_Click(object sender, EventArgs e)
        {
            try
            {
                // looking for a selected row
                if (listAlbumDataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an album to rent from the data table.");
                    return;
                }

                var selectedRow = listAlbumDataGridView.SelectedRows[0];
                var selectedAlbum = selectedRow.DataBoundItem as Music;

                if (selectedAlbum == null)
                {
                    MessageBox.Show("You have not selected an album.");
                    return;
                }

                if (!selectedAlbum.Available)
                {
                    MessageBox.Show("This album is not available for rent.");
                    return;
                }

                // Read the User ID
                string userIdText = userIdTextBox.Text.Trim();
                if (!int.TryParse(userIdText, out int userId))
                {
                    MessageBox.Show("User ID must be a valid number.");
                    return;
                }

                //  Build a rental request object
                var rentalRequest = new Rental
                {
                    UserId = userId,
                    AlbumId = selectedAlbum.Id
                };

                // Serialize to JSON
                var json = JsonConvert.SerializeObject(rentalRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 5. POST /api/rentals
                var response = await _httpClient.PostAsync("api/rentals", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to rent album. Status: {response.StatusCode}\n{errorText}");
                    return;
                }

                MessageBox.Show("Album rented successfully!");

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error calling API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private async void viewActiveRentalsButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Call GET /api/rentals
                var response = await _httpClient.GetAsync("api/rentals");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                // Deserialize JSON
                var rentals = JsonConvert.DeserializeObject<List<Rental>>(json);

                if (rentals == null || rentals.Count == 0)
                {
                    MessageBox.Show("No active rentals found.");
                    rentalsDataGridView.DataSource = null;
                    return;
                }

                // Bind to rentalsDataGridView
                rentalsDataGridView.DataSource = null;
                rentalsDataGridView.DataSource = rentals;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error calling API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private async void returnAlbumButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Make sure a rental is selected in the dataGridView
                if (rentalsDataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a rental to return.");
                    return;
                }

                var selectedRow = rentalsDataGridView.SelectedRows[0];
                var selectedRental = selectedRow.DataBoundItem as Rental;

                if (selectedRental == null)
                {
                    MessageBox.Show("Could not determine the selected rental.");
                    return;
                }

                // Call POST /api/rentals/{id}/return
                string url = $"api/rentals/{selectedRental.Id}/return";
                var response = await _httpClient.PostAsync(url, null);

                if (!response.IsSuccessStatusCode)
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to return rental. Status: {response.StatusCode}\n{errorText}");
                    return;
                }

                MessageBox.Show("Rental returned successfully!");

                // Refresh rentals and albums so UI updates
                // Refresh active rentals grid
                viewActiveRentalsButton_Click(sender, e);

                // Refresh albums grid
                listAlbumButton_Click(sender, e);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error calling API: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }
    }
}
