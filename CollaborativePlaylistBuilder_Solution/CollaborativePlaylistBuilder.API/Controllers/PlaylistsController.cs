using Microsoft.AspNetCore.Mvc;
using CollaborativePlaylistBuilder.API.Models;
using CollaborativePlaylistBuilder.API.Commands;
using CollaborativePlaylistBuilder.API.DTOs;
using Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CollaborativePlaylistBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private static List<Playlist> playlists = new List<Playlist>();
        private static int playlistIdCounter = 1;
        private static int songIdCounter = 1;

        [HttpPost]
        public IActionResult CreatePlaylist([FromBody] CreatePlaylistDto dto)
        {
            var playlist = new Playlist
            {
                Id = playlistIdCounter++,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                IsCollaborative = dto.IsCollaborative
            };
            playlists.Add(playlist);
            return Ok(playlist);
        }

        [HttpGet]
        public IActionResult GetPlaylists() => Ok(playlists);

        [HttpPut("{id}/add")]
        public IActionResult AddSong(int id, [FromBody] AddSongDto dto)
        {
            var playlist = playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null) return NotFound();

            var song = new Song
            {
                Id = songIdCounter++,
                Title = dto.Title,
                Artist = dto.Artist,
                Genre = dto.Genre,
                DurationSeconds = dto.DurationSeconds
            };

            ICommand command = new AddSongCommand(playlist, song);
            command.Execute();

            return Ok(playlist);
        }

        [HttpPut("{id}/invite")]
        public IActionResult InviteCollaborator(int id, [FromBody] InviteCollaboratorDto dto)
        {
            var playlist = playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null) return NotFound();

            playlist.Collaborators.Add(dto.UserId);
            return Ok(playlist);
        }

        [HttpPost("{id}/vote")]
        public IActionResult VoteSong(int id, [FromBody] VoteDto dto)
        {
            var playlist = playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null) return NotFound();

            var song = playlist.Songs.FirstOrDefault(s => s.Id == dto.SongId);
            if (song == null) return NotFound();

            ICommand command = new VoteSongCommand(song, dto.IsUpvote);
            command.Execute();

            return Ok(song);
        }

        [HttpGet("{id}/rankings")]
        public IActionResult GetRankings(int id)
        {
            var playlist = playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null) return NotFound();

            var rankings = playlist.Songs.OrderByDescending(s => s.Votes).ToList();
            return Ok(rankings);
        }
    }
}