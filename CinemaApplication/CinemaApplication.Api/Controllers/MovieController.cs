using CinemaApplication.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : CinemaControllerBase<Movie>
    {
        public MovieController(CinemaContext cinemaContext) : base(cinemaContext) { }
    }
}
