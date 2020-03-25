using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Repository
{
    public interface IMovieRepository
    {
        Task CreateMovie(Movie movie);
        Task<List<Movie>> GetMovies();
        Task<List<Movie>> GetMoviesByName(string name);
    }
}
