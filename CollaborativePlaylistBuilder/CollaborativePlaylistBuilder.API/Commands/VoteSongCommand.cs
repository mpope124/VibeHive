using Shared.Interfaces;
using CollaborativePlaylistBuilder.API.Models;

namespace CollaborativePlaylistBuilder.API.Commands
{
    public class VoteSongCommand : ICommand
    {
        private readonly Song _song;
        private readonly bool _upvote;

        public VoteSongCommand(Song song, bool upvote)
        {
            _song = song;
            _upvote = upvote;
        }

        public void Execute() => _song.Votes += _upvote ? 1 : -1;
    }
}