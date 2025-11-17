using System.Collections.Generic;

namespace CollaborativePlaylistBuilder.API.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Song> Songs { get; set; } = new List<Song>();
        public int CreatedBy { get; set; }
        public bool IsCollaborative { get; set; }
        public List<int> Collaborators { get; set; } = new List<int>();
    }
}