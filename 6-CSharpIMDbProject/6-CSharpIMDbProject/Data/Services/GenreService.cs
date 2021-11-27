using _6_CSharpIMDbProject.Data.ViewModels;
using _6_CSharpIMDbProject.DBOperations;
using _6_CSharpIMDbProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Data.Services
{
    public class GenreService
    {
        private IMDbDBContext _context;

        public GenreService(IMDbDBContext context)
        {
            _context = context;
        }

        public void AddGenre(GenreVM genre)
        {
            var _genre = new Genre()
            {
                GenreName = genre.GenreName,
            };

            _context.Genres.Add(_genre);
            _context.SaveChanges();
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreByID(int genreID)
        {
            return _context.Genres.FirstOrDefault(genre => genre.ID == genreID);
        }

        public Genre UpdateGenreByID(int genreID, GenreVM genre)
        {
            var _genre = _context.Genres.FirstOrDefault(genre => genre.ID == genreID);
            if (_genre != null)
            {
                _genre.GenreName = genre.GenreName;

                _context.SaveChanges();
            }

            return _genre;
        }

        public void DeleteGenreByID(int genreID)
        {
            var _genre = _context.Genres.FirstOrDefault(genre => genre.ID == genreID);
            if (_genre != null)
            {
                _context.Genres.Remove(_genre);

                _context.SaveChanges();
            }
        }
    }
}
