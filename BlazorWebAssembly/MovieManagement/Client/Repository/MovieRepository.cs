using MovieManagement.Client.Helpers;
using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/movie";

        public MovieRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Movie>> GetMoviesByName(string name)
        {
            var response = await httpService.Get<List<Movie>>($"{url}/search/{name}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<List<Movie>> GetMovies()
        {
            var response = await httpService.Get<List<Movie>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task CreateMovie(Movie movie)
        {
            var response = await httpService.Post<Movie>(url, movie);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
