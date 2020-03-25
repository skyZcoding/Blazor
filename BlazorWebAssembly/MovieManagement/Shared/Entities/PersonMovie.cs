using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Shared.Entities
{
    public class PersonMovie
    {
        public int PersonId { get; set; }

        public int MovieId { get; set; }

        public Person Person { get; set; }

        public Movie Movie { get; set; }
    }
}
