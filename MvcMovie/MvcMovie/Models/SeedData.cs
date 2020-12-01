using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2001-4-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-3-13"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 8
                    },

                    new Movie
                    {
                        Title = "The Best Two Years",
                        ReleaseDate = DateTime.Parse("2004-2-20"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 9
                    }
                );
                context.SaveChanges();
            }
        }
    }
}