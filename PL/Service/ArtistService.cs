using DAL.Entities;

namespace PL.Service
{
    public class ArtistService : IArtistService
    {
        private readonly HttpClient _httpClient;

        public ArtistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7157/api/");
        }

        public async Task AddAsync(Artist artist)
        {
            var response = await _httpClient.PostAsJsonAsync("artists", artist);
            var error = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error adding artist: {error}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"artists/{id}");
            var error = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error deleting artist: {error}");
            }
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("artists");
            var artists = await response.Content.ReadFromJsonAsync<IEnumerable<Artist>>();
            return artists ?? new List<Artist>();
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"artists/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Artist>();
            }
            else
            {
                throw new Exception("Artist not found.");
            }
        }

        public async Task UpdateAsync(int id, Artist artist)
        {
            var response = await _httpClient.PutAsJsonAsync($"artists/{id}", artist);
            var error = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error updating artist: {error}");
            }
        }
    }
}
