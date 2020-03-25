using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Shared.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<PersonMovie> FavoritMovies { get; set; }
    }
}
