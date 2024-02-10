using CinemaApplication.Shared;
using System.Net.Http.Json;

namespace CinemaApplication.Client.Services
{
    /// <summary>
    /// Service for managing directors within the client application.
    /// </summary>
    public class DirectorService : IDirectorService
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance of the DirectorService with a specified HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient used for HTTP requests.</param>
        public DirectorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Adds a new director asynchronously.
        /// </summary>
        /// <param name="director">The director to add.</param>
        public async Task AddDirectorAsync(Director director) => await _httpClient.PostAsJsonAsync($"Director", director);
        /// <summary>
        /// Deletes a director by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the director to delete.</param>
        public async Task DeleteDirectorAsync(int id) => await _httpClient.DeleteAsync($"Director/{id}");
        /// <summary>
        /// Deletes a director and their associated movies by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the director to delete.</param>
        public async Task DeleteDirectorWithMoviesAsync(int id) => await _httpClient.DeleteAsync($"Director/with-movies/{id}");
        /// <summary>
        /// Gets all directors asynchronously.
        /// </summary>
        /// <returns>A collection of directors.</returns>
        public async Task<IEnumerable<Director>?> GetAllDirectorAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Director>>("Director");
        /// <summary>
        /// Gets a director by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the director to retrieve.</param>
        /// <returns>The director with the specified ID.</returns>
        public async Task<Director?> GetDirectorByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Director?>($"Director/{id}");
        /// <summary>
        /// Updates a director by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the director to update.</param>
        /// <param name="director">The updated director information.</param>
        public async Task UpdatDirectorAsync(int id, Director director) => await _httpClient.PutAsJsonAsync($"Director/{id}", director);
    }
}
