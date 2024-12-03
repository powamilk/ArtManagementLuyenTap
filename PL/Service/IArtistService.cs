using DAL.Entities;

namespace PL.Service
{
    public interface IArtistService
    {
        Task AddAsync(Artist artist);
        Task DeleteAsync(int id);
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task UpdateAsync(int id, Artist artist);
    }
}
