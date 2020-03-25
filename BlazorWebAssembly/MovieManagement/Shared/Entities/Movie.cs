using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte[] Image { get; set; }

        public List<PersonMovie> PersonMovies { get; set; }
    }
}
