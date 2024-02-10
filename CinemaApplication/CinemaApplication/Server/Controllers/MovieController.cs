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
    public class MovieController : CinemaControllerBase<Movie>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorController"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The database context.</param>
        public MovieController(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
        /// <summary>
        /// Deletes a director and their associated movies by director ID.
        /// </summary>
        /// <param name="directorId">The ID of the director to delete.</param>
        /// <returns>An asynchronous task that returns an IActionResult indicating the result of the operation.</returns>
        [HttpGet("by-director/{directorId}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByDirectorId(int directorId)
        {
            List<Movie>? movies = await _applicationDbContext.Movies.ToListAsync();
            movies = movies?.Where(x => x.DirectorId == directorId).ToList();
            if (movies == null || movies.Count() == 0)
            {
                return Ok(new List<Movie>());
            }
            return Ok(movies);
        }
    }
}
