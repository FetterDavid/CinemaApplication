using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Shared
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Range(1800, 2023)]
        public int YearOfBirth { get; set; }
        [MaxLength(64)]
        public string? Nationality { get; set; }
        [NotMapped] //nem mentjük az adatbázisba
        public List<Movie>? DirectedMovies { get; set; }
    }
}
