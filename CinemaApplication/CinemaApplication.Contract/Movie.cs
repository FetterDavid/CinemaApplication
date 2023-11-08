using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Contract
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [Required]
        public int DirectorId { get; set; }
        [Required, MaxLength(256)]
        public string Title { get; set; }
        public string? Category { get; set; }
        [Range(1800,2023)]
        public int PublicationYear { get; set; }
        [NotMapped] //nem mentjük az adatbázisba
        public string DirectorName { get; set; } = "";
    }
}
