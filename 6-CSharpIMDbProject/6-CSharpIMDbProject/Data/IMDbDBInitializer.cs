using _6_CSharpIMDbProject.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.DBOperations
{
    public class IMDbDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IMDbDBContext>();

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new Actor()
                    {
                        FirstName = "Dwayne",
                        LastName = "Johnson",
                        MovieID = 1
                    }, new Actor()
                    {
                        FirstName = "Gal",
                        LastName = "Gadot",
                        MovieID = 1
                    }, new Actor()
                    {
                        FirstName = "Ryan",
                        LastName = "Reynolds",
                        MovieID = 1
                    }, new Actor()
                    {
                        FirstName = "Zendaya",
                        LastName = "",
                        MovieID = 2
                    }, new Actor()
                    {
                        FirstName = "Jason",
                        LastName = "Momoa",
                        MovieID = 2
                    }, new Actor()
                    {
                        FirstName = "Oscar",
                        LastName = "Isaac",
                        MovieID = 2
                    }, new Actor()
                    {
                        FirstName = "Angelina",
                        LastName = "Jolie",
                        MovieID = 3
                    }, new Actor()
                    {
                        FirstName = "Harry",
                        LastName = "Styles",
                        MovieID = 3
                    }, new Actor()
                    {
                        FirstName = "Kit",
                        LastName = "Harington",
                        MovieID = 3
                    });
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new Movie()
                    {
                        MovieName = "Red Notice",
                        MovieDesc = "Red Notice is a 2021 American action comedy film written and directed by Rawson Marshall Thurber. It stars Dwayne Johnson as an FBI agent who reluctantly teams up with a renowned art thief (Ryan Reynolds) in order to catch an even more notorious criminal (Gal Gadot). ",
                        ReleaseDate = "5 November 2021",
                        GenreID = 1
                    }, new Movie()
                    {
                        MovieName = "Dune",
                        MovieDesc = "Dune (titled onscreen as Dune: Part One) is a 2021 American epic science fiction film directed by Denis Villeneuve and written by Villeneuve, Jon Spaihts, and Eric Roth. It is the first of a planned two-part adaptation of the 1965 novel by Frank Herbert, primarily covering the first half of the book. Set in the far future, it follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis.",
                        ReleaseDate = "3 September 2021",
                        GenreID = 2
                    }, new Movie()
                    {
                        MovieName = "Eternals",
                        MovieDesc = "Eternals is a 2021 American superhero film based on the Marvel Comics race of the same name. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the 26th film in the Marvel Cinematic Universe (MCU). The film is directed by Chloé Zhao, who wrote the screenplay with Patrick Burleigh, Ryan Firpo, and Kaz Firpo.",
                        ReleaseDate = "18 October 2021",
                        GenreID = 2
                    });
                }

                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new Genre()
                    {
                        GenreName = "Comedy"
                    }, new Genre()
                    {
                        GenreName = "Science Fiction"
                    });
                }

                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new Director()
                    {
                        FirstName = "Rawson Marshall",
                        LastName = "Thurber",
                        MovieID = 1
                    }, new Director()
                    {
                        FirstName = "Denis",
                        LastName = "Villeneuve",
                        MovieID = 2
                    }, new Director()
                    {
                        FirstName = "Chloé",
                        LastName = "Zhao",
                        MovieID = 3
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
