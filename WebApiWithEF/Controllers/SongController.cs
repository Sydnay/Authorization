using Authorization.Dtos;
using Authorization.Entities;
using Authorization.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private readonly SongRepository repository;
        public SongController(SongRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddSong(CreateSongDto request)
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Singer = request.Singer,
                CreatedOn = DateTime.Now,
            };

            await repository.AddSong(song);

            return Ok(song);
        }
        [HttpGet("songs")]
        public async Task<ActionResult<List<Song>>> GetAllSongs()
        {
            return await repository.GetAllSongs();
        }
        [HttpPut("updatesongname")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateSong(Guid id, UpdateSongDto songDto)
        {
            var song = await repository.GetSong(id);
            if (song is null)
                return BadRequest("Song doesn't found");

            await repository.UpdateSong(song, songDto);

            return Ok(song);
        }
        [HttpDelete("deletesong")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSong(Guid id)
        {
            var song = await repository.GetSong(id);
            if (song is null)
                return BadRequest("Song doesn't found");

            await repository.DeleteSong(song);

            return Ok(song.Name);
        }
    }
}
