using CinemaApplication.Contract;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
    }
}
