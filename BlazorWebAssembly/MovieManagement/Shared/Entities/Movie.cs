using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieManagement.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public byte[] Image { get; set; }

        public List<PersonMovie> PersonMovies { get; set; }

        public List<MovieGenre> MovieGenre { get; set; }
    }
}
