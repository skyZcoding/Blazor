using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Shared.Entities;

namespace MovieManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext context;

        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await context.Genres.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genre genre)
        {
            context.Add(genre);
            await context.SaveChangesAsync();

            return genre.Id;
        }

        [HttpGet("GetGenreById/{genreId:int}")]
        public async Task<ActionResult<Genre>> GetGenreById(int genreId)
        {
            Genre genre = await context.Genres.FindAsync(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genre genre)
        {
            context.Attach(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Genre genre = await context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            context.Remove(genre);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}