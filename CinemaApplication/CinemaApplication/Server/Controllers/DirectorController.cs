using CinemaApplication.Server.Data;
using CinemaApplication.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    /// <summary>
    /// Controller for managing director-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : CinemaControllerBase<Director>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorController"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The database context.</param>
        public DirectorController(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
        /// <summary>
        /// Deletes a director and their associated movies by director ID.
        /// </summary>
        /// <param name="directorId">The ID of the director to delete.</param>
        /// <returns>An asynchronous task that returns an IActionResult indicating the result of the operation.</returns>
        [HttpDelete("with-movies/{directorId}")]
        public async Task<IActionResult> GetByDirectorId(int directorId)
        {
            Director director = await _applicationDbContext.Directors.FindAsync(directorId);

            if (director == null)
            {
                return NotFound();
            }

            List<Movie> movies = await _applicationDbContext.Movies.ToListAsync();
            movies = movies?.Where(x => x.DirectorId == directorId).ToList();
            _applicationDbContext.Movies.RemoveRange(movies);
            _applicationDbContext.Directors.Remove(director);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
