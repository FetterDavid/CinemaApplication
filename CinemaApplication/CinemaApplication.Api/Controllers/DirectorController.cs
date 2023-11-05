using CinemaApplication.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : CinemaControllerBase<Director>
    {
        public DirectorController(CinemaContext cinemaContext) : base(cinemaContext) { }
    }
}
