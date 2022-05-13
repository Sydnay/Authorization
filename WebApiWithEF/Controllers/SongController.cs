using Authorization.Dtos;
using Authorization.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private readonly PlaylistContext repository;
        public SongController(PlaylistContext repository)
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

            await repository.Songs.AddAsync(song);
            await repository.SaveChangesAsync();

            return Ok(song);
        }
        [HttpGet("songs")]
        public async Task<ActionResult<List<Song>>> GetAllSongs()
        {
            return await repository.Songs.ToListAsync();
        }
        [HttpPut("updatesongname")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateSong(Guid id, UpdateSongDto songDto)
        {
            var song = await repository.Songs.FirstOrDefaultAsync(song => song.Id == id);
            if (song is null)
                return BadRequest("Song doesn't found");

            song.Name = songDto.Name;
            song.Singer = songDto.Singer;

            repository.Songs.Update(song);
            await repository.SaveChangesAsync();

            return Ok(song);
        }
        [HttpDelete("deletesong")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSong(Guid id)
        {
            var song = await repository.Songs.FirstOrDefaultAsync(song => song.Id == id);
            if (song is null)
                return BadRequest("Song doesn't found");

            repository.Songs.Remove(song);
            await repository.SaveChangesAsync();

            return Ok(song.Name);
        }
    }
}
