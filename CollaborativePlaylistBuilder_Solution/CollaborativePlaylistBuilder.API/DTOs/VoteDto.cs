namespace CollaborativePlaylistBuilder.API.DTOs
{
    public class VoteDto
    {
        // The id of the song within the playlist to apply the vote to.
        public int SongId { get; set; }

        // True for upvote, false for downvote. Default to upvote.
        public bool IsUpvote { get; set; } = true;

        // Optional: id of the user casting the vote.
        public int? VoterId { get; set; }
    }
}