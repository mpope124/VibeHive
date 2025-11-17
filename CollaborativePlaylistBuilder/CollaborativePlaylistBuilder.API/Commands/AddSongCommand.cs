using Shared.Interfaces;
using CollaborativePlaylistBuilder.API.Models;

namespace CollaborativePlaylistBuilder.API.Commands
{
    public class AddSongCommand : ICommand
    {
        private readonly Playlist _playlist;
        private readonly Song _song;

        public AddSongCommand(Playlist playlist, Song song)
        {
            _playlist = playlist;
            _song = song;
        }

        public void Execute() => _playlist.Songs.Add(_song);
    }
}