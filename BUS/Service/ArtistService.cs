using DAL.Entities;
using DAL.Repo;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _artistRepository.GetAllAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
                throw new KeyNotFoundException($"Nghệ sĩ với ID {id} không tồn tại.");
            return artist;
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _artistRepository.AddAsync(artist);
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            var existingArtist = await _artistRepository.GetByIdAsync(artist.ArtistId);
            if (existingArtist == null)
                throw new KeyNotFoundException($"Nghệ sĩ với ID {artist.ArtistId} không tồn tại.");
            await _artistRepository.UpdateAsync(artist);
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
                throw new KeyNotFoundException($"Nghệ sĩ với ID {id} không tồn tại.");
            await _artistRepository.DeleteAsync(id);
        }
    }
}
