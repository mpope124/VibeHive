using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Net.Client;
using Grpc.Core;
using AlbumServiceApi.Protos;

namespace VibeHiveDEV422Midterm
{
    public partial class AlbumInventoryForm : Form
    {
        //for a grpc channle to comm w/ server
        private readonly GrpcChannel _channel;

        //for client inst to interact w/ album service
        private readonly AlbumService.AlbumServiceClient _client;

        public AlbumInventoryForm()
        {
            InitializeComponent();

            _channel = GrpcChannel.ForAddress("https://localhost:7296");
            _client = new AlbumService.AlbumServiceClient(_channel);

            //setting the default album availability to true
            chk_Available.Checked = true;
        }

        //bing albums to datagrid view (for form's datagridaview)
        private async Task LoadDataGridWithAlbums()
        {
            try
            {
                var albums = new List<Album>();

                //grpc call for the whole stream
                var callAlbumStream = _client.ListAlbums(new ListAlbumsRequest());

                //read each item/album form the stream
                //new codeblock/workaround
                while (await callAlbumStream.ResponseStream.MoveNext())
                {
                    var album = callAlbumStream.ResponseStream.Current;
                    albums.Add(album);
                }
                //vvv old code block just in case
                //this is not compatible, I'm not 100% sure how to fix without changing project to higher version of c#
                //await foreach (var album in callAlbumStream.ResponseStream.ReadAllAsync())
                //{
                //    albums.Add(album);
                //}

                //our data source for datagrid view
                dataGridView_Albums.DataSource = albums;
            } catch (Grpc.Core.RpcException ex) //catch rpc expection
            {
                MessageBox.Show($"Client: grpc error trying to list albums: {ex.Status.StatusCode} - {ex.Status.Detail}");
            } catch (Exception ex) //catch non-rpc errors/jhust general errors
            {
                MessageBox.Show($"Client: non-grpc error trying to list albums: {ex.Message}");
            }
        }

        //add album
        private async void btn_AddAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                var title = txb_AlbumTitle.Text;
                var artists = txb_AlbumArtists.Text;
                var genre = txb_AlbumGenre.Text;
                var yearT = txb_AlbumYear.Text;

                int.TryParse(yearT, out var year);
                //set available to true by default hwen adding a new album
                chk_Available.Checked = true;
                var available = chk_Available.Checked;

                //album detail into list
                var addResponse = await _client.AddAlbumAsync(new AddAlbumRequest
                {
                    Album = new Album
                    {
                        Title = title,
                        Artists = artists,
                        Genre = genre,
                        Year = year,
                        Available = available
                    }
                });

                MessageBox.Show($"Client: Successfully created album with ID of: {addResponse.Album.Id}");

                txb_AlbumId.Text = addResponse.Album.Id;
                //clear album fields after add album success
                ClearAlbumFields();
                await LoadDataGridWithAlbums();
            } catch (Grpc.Core.RpcException ex)
            {
                MessageBox.Show($"Client: grpc error trying to add album: {ex.Status.StatusCode} - {ex.Status.Detail}");
            } catch (Exception ex)
            {
                MessageBox.Show($"Client: non-grpc error trying to add albums: {ex.Message}");
            }
        }

        //update album
        private async void btn_UpdateAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for album id
                if (string.IsNullOrEmpty(txb_AlbumId.Text))
                {
                    MessageBox.Show("Must choose an album");
                    return;
                }

                var id = txb_AlbumId.Text;
                var title = txb_AlbumTitle.Text;
                var artists = txb_AlbumArtists.Text;
                var genre = txb_AlbumGenre.Text;
                var yearT = txb_AlbumYear.Text;

                int.TryParse(yearT, out var year);
                var available = chk_Available.Checked;

                var updateResponse = await _client.UpdateAlbumAsync(new UpdateAlbumRequest
                {
                    Album = new Album
                    {
                        Id = id,
                        Title = title,
                        Artists = artists,
                        Genre = genre,
                        Year = year,
                        Available = available
                    }
                });

                //show update details on update succcessful
                MessageBox.Show($"Client: Successfully updated album! New Details:\n" +
                    $"ID: {updateResponse.Album.Id}\n" +
                    $"Title: {updateResponse.Album.Title}\n" +
                    $"Artist(s): {updateResponse.Album.Artists}\n" +
                    $"Genre: {updateResponse.Album.Genre}\n" +
                    $"Year: {updateResponse.Album.Year}\n" +
                    $"Availablle: {updateResponse.Album.Available}");
                    
                    //clear album fields after update
                    ClearAlbumFields();

                //refresh the gridvidw
                await LoadDataGridWithAlbums();
            } catch (Grpc.Core.RpcException ex)
            {
                MessageBox.Show($"Client: grpc error trying to update album: {ex.Status.StatusCode} - {ex.Status.Detail}");
            } catch (Exception ex)
            {
                MessageBox.Show($"Client: non-grpc error trying to update albums: {ex.Message}");
            }
        }

        //delete album
        private async void btn_DeleteAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txb_AlbumId.Text))
                {
                    MessageBox.Show("Must choose an album or input an album's ID to delete it");
                    return;
                }

                var id = txb_AlbumId.Text;

                var deleteResponse = await _client.DeleteAlbumAsync(new AlbumId { Id = id });

                MessageBox.Show($"Client: Successfully deleted album! Details of the deleted album:\n" +
                    $"ID: {deleteResponse.Album.Id}\n" +
                    $"Title: {deleteResponse.Album.Title}\n" +
                    $"Artist(s): {deleteResponse.Album.Artists}\n" +
                    $"Genre: {deleteResponse.Album.Genre}\n" +
                    $"Year: {deleteResponse.Album.Year}\n" +
                    $"Availablle: {deleteResponse.Album.Available}");

                //wipe out the dtext fields after successful deletion
                //txb_AlbumId.Clear();
                //txb_AlbumTitle.Clear();
                //txb_AlbumArtists.Clear();
                //txb_AlbumGenre.Clear();
                //txb_AlbumYear.Clear();
                //chk_Available.Checked = false;
                ClearAlbumFields(); //new helper func to concisele clear the txb fields


                //refresh the ableum list
                await LoadDataGridWithAlbums();
            }
            catch (Grpc.Core.RpcException ex)
            {
                MessageBox.Show($"Client: grpc error trying to delete album: {ex.Status.StatusCode} - {ex.Status.Detail}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Client: non-grpc error trying to delete albums: {ex.Message}");
            }
        }

        //list all albums
        private async void btn_ListAllAlbums_Click(object sender, EventArgs e)
        {
            await LoadDataGridWithAlbums();
        }

        //hook for the datagridview allbums
        private void dataGridView_Albums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bind data to grid view
            if (e.RowIndex < 0) return;
            var album = dataGridView_Albums.Rows[e.RowIndex].DataBoundItem as Album;

            //validation justin case
            if (album == null) return;

            //pop fields w/ the album's data if success
            txb_AlbumId.Text = album.Id;
            txb_AlbumTitle.Text = album.Title;
            txb_AlbumArtists.Text = album.Artists;
            txb_AlbumGenre.Text = album.Genre;
            txb_AlbumYear.Text = album.Year.ToString();
            chk_Available.Checked = album.Available;
        }

        //clear all the fields for better UI vis and also accidental data entry avoidance/QOL
        private void ClearAlbumFields()
        {
            txb_AlbumId.Clear();
            txb_AlbumTitle.Clear();
            txb_AlbumArtists.Clear();
            txb_AlbumGenre.Clear();
            txb_AlbumYear.Clear();
            chk_Available.Checked = false;
        }

        private void dataGridView_Albums_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
