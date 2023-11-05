﻿using System;
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
        [Required]
        public string Title { get; set; }
        public string Category { get; set; }
        public int PublicationYear { get; set; }
    }
}