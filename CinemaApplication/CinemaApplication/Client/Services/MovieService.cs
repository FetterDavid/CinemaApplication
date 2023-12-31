﻿
using CinemaApplication.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace CinemaApplication.Client.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMovieAsync(Movie movie) => await _httpClient.PostAsJsonAsync($"Movie", movie);

        public async Task DeleteMovieAsync(int id) => await _httpClient.DeleteAsync($"Movie/{id}");

        public async Task<IEnumerable<Movie>?> GetAllMovieAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("Movie");

        public async Task<IEnumerable<Movie>?> GetMovieByDirectorIdAsync(int directorId) => await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>($"Movie/by-director/{directorId}");

        public async Task<Movie?> GetMovieByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Movie?>($"Movie/{id}");

        public async Task UpdateMovieAsync(int id, Movie movie) => await _httpClient.PutAsJsonAsync($"Movie/{id}", movie);
    }
}
