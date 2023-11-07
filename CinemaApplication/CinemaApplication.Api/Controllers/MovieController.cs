using CinemaApplication.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : CinemaControllerBase<Movie>
    {
        public MovieController(CinemaContext cinemaContext) : base(cinemaContext) { }

        [HttpGet("by-director/{directorId}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByDirectorId(int directorId)
        {
            List<Movie>? movies = await _cinemaContext.Movies.ToListAsync();
            movies = movies?.Where(x => x.DirectorId == directorId).ToList();
            if (movies == null || movies.Count() == 0)
            {
                return Ok(new List<Movie>());
            }
            return Ok(movies);
        }
    }
}
