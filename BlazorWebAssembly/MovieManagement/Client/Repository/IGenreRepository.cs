using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Repository
{
    public interface IGenreRepository
    {
        Task CreateGenre(Genre genre);
        Task DeleteGenre(int id);
        Task<Genre> GetGenreById(int id);
        Task<List<Genre>> GetGenres();
        Task UpdateGenre(Genre genre);
    }
}
