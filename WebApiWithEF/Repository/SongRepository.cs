using Authorization.Dtos;
using Authorization.Entities;

namespace Authorization.Repository
{
    public class SongRepository
    {
        private PlaylistContext repository;
        public SongRepository(PlaylistContext repository)
        {
            this.repository = repository;
        }
        public async Task AddSong(Song song)
        {
            await repository.Songs.AddAsync(song);
            await repository.SaveChangesAsync();
        }
        public async Task<List<Song>> GetAllSongs()
        {
            return await repository.Songs.ToListAsync();
        }
        public async Task<Song> GetSong(Guid id)
        {
            return await repository.Songs.FirstOrDefaultAsync(song => song.Id == id);
        }
        public async Task UpdateSong(Song song, UpdateSongDto songDto)
        {
            song.Name = songDto.Name;
            song.Singer = songDto.Singer;

            repository.Songs.Update(song);
            await repository.SaveChangesAsync();
        }
        public async Task DeleteSong(Song song)
        {
            repository.Songs.Remove(song);
            await repository.SaveChangesAsync();
        }
    }
}
