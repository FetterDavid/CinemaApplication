using CinemaApplication.Server.Data;
using CinemaApplication.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : CinemaControllerBase<Director>
    {
        public DirectorController(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

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
