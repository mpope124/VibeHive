using Grpc.Core;
using System.Collections.Concurrent;
using AlbumServiceApi.Protos;
using System.Net;

namespace AlbumServiceApi.Services
{
    public class AlbumApi : AlbumService.AlbumServiceBase
    {
        //dictionary
        private static readonly ConcurrentDictionary<string, Album> albums = new();

        //Add albuum
        public override Task<AddAlbumResponse> AddAlbum(AddAlbumRequest request, ServerCallContext context)
        {
            var newAlbum = request.Album;

            //generate album id
            var albumId = Guid.NewGuid().ToString();
            var album = new Album
            {
                Id = albumId,
                Title = newAlbum.Title,
                Artists = newAlbum.Artists,
                Genre = newAlbum.Genre,
                Year = newAlbum.Year,
                Available = newAlbum.Available,
            };

            if (albums.TryAdd(albumId, album))
            {
                return Task.FromResult(new AddAlbumResponse { Album = album });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Internal, "Failed to add new album :("));
            }
  
        }

        //get album by id
        public override Task<GetAlbumResponse> GetAlbum(AlbumId request, ServerCallContext context)
        {
            if (albums.TryGetValue(request.Id, out var album))
            {
                return Task.FromResult(new GetAlbumResponse { Album = album });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"No album with ID of {request.Id} was found :("));
            }
        }

        //update the album
        public override Task<UpdateAlbumResponse> UpdateAlbum(UpdateAlbumRequest request, ServerCallContext context)
        {
            var updateAlbum = request.Album;

            //updaye album details
            albums[updateAlbum.Id] = new Album
            {
                Id = updateAlbum.Id,
                Title = updateAlbum.Title,
                Artists = updateAlbum.Artists,
                Genre = updateAlbum.Genre,
                Year = updateAlbum.Year,
                Available = updateAlbum.Available
            };

            return Task.FromResult(new UpdateAlbumResponse { Album = albums[updateAlbum.Id]});
        }

        //delete an album (by id)
        public override Task<DeleteAlbumResponse> DeleteAlbum(AlbumId request, ServerCallContext context)
        {
            if (albums.TryRemove(request.Id, out var albumToRemove))
            {
                return Task.FromResult(new DeleteAlbumResponse
                {
                    Album = albumToRemove
                });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Album not found by ID: {request.Id}"));
            }
        }

        //list out all the albums
        public override async Task ListAlbums(ListAlbumsRequest request, IServerStreamWriter<Album> responseStream, ServerCallContext context)
        {
            if (albums.IsEmpty)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No albums are currently in the catalogue :("));
            }
            
            
            foreach (var album in albums.Values)
            {
                await responseStream.WriteAsync(album);
            }
        }
    }
}
