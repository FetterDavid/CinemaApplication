using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Contract
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        [NotMapped] //nem mentjük az adatbázisba
        public List<Movie>? DirectedMovies { get; set; }
    }
}
