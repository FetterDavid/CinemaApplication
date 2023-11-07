using CinemaApplication.Contract;
using System;

namespace CinemaApplication.Blazor.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>?> GetAllMovieAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>?> GetMovieByDirectorIdAsync(int directorId);
        Task AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
        Task UpdateMovieAsync(int id, Movie movie);
    }
}
