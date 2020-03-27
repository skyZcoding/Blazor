using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MovieManagement.Client.Helpers;
using MovieManagement.Client.Repository;
using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Shared.MovieComponents
{
    public partial class MoviesList
    {
        private async Task DeleteMovie(Movie movie)
        {
            bool confirmed = await js.Confirm($"Are you sure you want to delete {movie.Name}?");

            if (confirmed)
            {
                await movieRepository.DeleteMovie(movie.Id);
            }
        }
    }
}
