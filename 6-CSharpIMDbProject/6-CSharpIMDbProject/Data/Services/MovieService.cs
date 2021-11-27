using _6_CSharpIMDbProject.Data.ViewModels;
using _6_CSharpIMDbProject.DBOperations;
using _6_CSharpIMDbProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Data.Services
{
    public class MovieService
    {
        private IMDbDBContext _context;

        public MovieService(IMDbDBContext context)
        {
            _context = context;
        }

        public void AddMovie(MovieVM movie)
        {
            var _movie = new Movie()
            {
                MovieName = movie.MovieName,
                MovieDesc = movie.MovieDesc,
                ReleaseDate = movie.ReleaseDate
            };

            _context.Movies.Add(_movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieByID(int movieID)
        {
            return _context.Movies.FirstOrDefault(movie => movie.ID == movieID);
        }

        public Movie UpdateMovieByID(int movieID, MovieVM movie)
        {
            var _movie = _context.Movies.FirstOrDefault(movie => movie.ID == movieID);
            if (_movie != null)
            {
                _movie.MovieName = movie.MovieName;
                _movie.MovieDesc = movie.MovieDesc;
                _movie.ReleaseDate = movie.ReleaseDate;

                _context.SaveChanges();
            }

            return _movie;
        }

        public void DeleteMovieByID(int movieID)
        {
            var _movie = _context.Movies.FirstOrDefault(movie => movie.ID == movieID);
            if (_movie != null)
            {
                _context.Movies.Remove(_movie);

                _context.SaveChanges();
            }
        }
    }
}
