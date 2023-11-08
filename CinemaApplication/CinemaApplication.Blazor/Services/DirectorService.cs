using CinemaApplication.Contract;
using System.Net.Http;
using System.Net.Http.Json;

namespace CinemaApplication.Blazor.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly HttpClient _httpClient;

        public DirectorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddDirectorAsync(Director director) => await _httpClient.PostAsJsonAsync($"Director", director);

        public async Task DeleteDirectorAsync(int id) => await _httpClient.DeleteAsync($"Director/{id}");

        public async Task DeleteDirectorWithMoviesAsync(int id) => await _httpClient.DeleteAsync($"Director/with-movies/{id}");

        public async Task<IEnumerable<Director>?> GetAllDirectorAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Director>>("Director");

        public async Task<Director?> GetDirectorByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Director?>($"Director/{id}");

        public async Task UpdatDirectorAsync(int id, Director director) => await _httpClient.PutAsJsonAsync($"Director/{id}", director);
    }
}
