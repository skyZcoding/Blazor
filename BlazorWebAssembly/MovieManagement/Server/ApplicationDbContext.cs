using Microsoft.EntityFrameworkCore;
using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<PersonMovie>().HasKey(x => new { x.MovieId, x.PersonId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<PersonMovie> PersonMovie { get; set; }
    }
}
