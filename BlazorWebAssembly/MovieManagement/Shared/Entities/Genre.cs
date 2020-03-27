using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieManagement.Shared.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }
    }
}
