using _6_CSharpIMDbProject.Data.ViewModels;
using _6_CSharpIMDbProject.DBOperations;
using _6_CSharpIMDbProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Data.Services
{
    public class DirectorService
    {
        private IMDbDBContext _context;

        public DirectorService(IMDbDBContext context)
        {
            _context = context;
        }

        public void AddDirector(DirectorVM director)
        {
            var _director = new Director()
            {
                FirstName = director.FirstName,
                LastName = director.LastName,
                MovieID = director.MovieID
            };

            _context.Directors.Add(_director);
            _context.SaveChanges();
        }

        public List<Director> GetAllDirectors()
        {
            return _context.Directors.ToList();
        }

        public Director GetDirectorByID(int directorID)
        {
            return _context.Directors.FirstOrDefault(director => director.ID == directorID);
        }

        public Director UpdatedirectorByID(int directorID, DirectorVM director)
        {
            var _director = _context.Directors.FirstOrDefault(director => director.ID == directorID);
            if (_director != null)
            {
                _director.FirstName = director.FirstName;
                _director.LastName = director.LastName;
                _director.MovieID = director.MovieID;

                _context.SaveChanges();
            }

            return _director;
        }

        public void DeletedirectorByID(int directorID)
        {
            var _director = _context.Directors.FirstOrDefault(director => director.ID == directorID);
            if (_director != null)
            {
                _context.Directors.Remove(_director);

                _context.SaveChanges();
            }
        }
    }
}
