using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext context;

        public MovieController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return await context.Movies.ToListAsync();
        }


        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Movie>>> FilterByName(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return new List<Movie>();
            }

            return await context.Movies
                            .Where(m => m.Name.Contains(searchText))
                            .Take(5)
                            .ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            context.Add(movie);
            await context.SaveChangesAsync();

            return movie.Id;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Movie movie = await context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            context.Remove(movie);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
