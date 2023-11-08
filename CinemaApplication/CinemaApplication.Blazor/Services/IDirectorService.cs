using CinemaApplication.Contract;

namespace CinemaApplication.Blazor.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>?> GetAllDirectorAsync();
        Task<Director?> GetDirectorByIdAsync(int id);
        Task AddDirectorAsync(Director director);
        Task DeleteDirectorAsync(int id);
        Task DeleteDirectorWithMoviesAsync(int id);
        Task UpdatDirectorAsync(int id, Director director);
    }
}
