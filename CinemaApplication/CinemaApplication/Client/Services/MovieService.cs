
using CinemaApplication.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace CinemaApplication.Client.Services
{
    /// <summary>
    /// Service for managing movies within the client application.
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance of the MovieService with a specified HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient used for HTTP requests.</param>
        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Adds a new movie asynchronously.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        public async Task AddMovieAsync(Movie movie) => await _httpClient.PostAsJsonAsync($"Movie", movie);
        /// <summary>
        /// Deletes a movie by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        public async Task DeleteMovieAsync(int id) => await _httpClient.DeleteAsync($"Movie/{id}");
        /// <summary>
        /// Gets all movies asynchronously.
        /// </summary>
        /// <returns>A collection of movies.</returns>
        public async Task<IEnumerable<Movie>?> GetAllMovieAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("Movie");
        /// <summary>
        /// Gets movies by director ID asynchronously.
        /// </summary>
        /// <param name="directorId">The ID of the director.</param>
        /// <returns>A collection of movies associated with the specified director.</returns>
        public async Task<IEnumerable<Movie>?> GetMovieByDirectorIdAsync(int directorId) => await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>($"Movie/by-director/{directorId}");
        /// <summary>
        /// Gets a movie by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID.</returns>
        public async Task<Movie?> GetMovieByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Movie?>($"Movie/{id}");
        /// <summary>
        /// Updates a movie by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie information.</param>
        public async Task UpdateMovieAsync(int id, Movie movie) => await _httpClient.PutAsJsonAsync($"Movie/{id}", movie);
    }
}
