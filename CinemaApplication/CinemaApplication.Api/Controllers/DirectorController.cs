using CinemaApplication.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : CinemaControllerBase<Director>
    {
        public DirectorController(CinemaContext cinemaContext) : base(cinemaContext) { }

        [HttpDelete("with-movies/{directorId}")]
        public async Task<IActionResult> GetByDirectorId(int directorId)
        {
            Director director = await _cinemaContext.Directors.FindAsync(directorId);

            if (director == null)
            {
                return NotFound();
            }

            List<Movie> movies = await _cinemaContext.Movies.ToListAsync();
            movies = movies?.Where(x => x.DirectorId == directorId).ToList();
            _cinemaContext.Movies.RemoveRange(movies);
            _cinemaContext.Directors.Remove(director);
            await _cinemaContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
