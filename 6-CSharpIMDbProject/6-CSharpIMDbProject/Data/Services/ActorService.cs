using _6_CSharpIMDbProject.Data.ViewModels;
using _6_CSharpIMDbProject.DBOperations;
using _6_CSharpIMDbProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Data.Services
{
    public class ActorService
    {
        private IMDbDBContext _context;

        public ActorService(IMDbDBContext context)
        {
            _context = context;
        }

        public void AddActor(ActorVM actor)
        {
            var _actor = new Actor()
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                MovieID = actor.MovieID
            };

            _context.Actors.Add(_actor);
            _context.SaveChanges();
        }

        public List<Actor> GetAllActors()
        {
            return _context.Actors.ToList();
        }

        public Actor GetActorByID(int actorID)
        {
            return _context.Actors.FirstOrDefault(actor => actor.ID == actorID);
        }

        public Actor UpdateActorByID(int actorID, ActorVM actor)
        {
            var _actor = _context.Actors.FirstOrDefault(actor => actor.ID == actorID);
            if (_actor != null)
            {
                _actor.FirstName = actor.FirstName;
                _actor.LastName = actor.LastName;
                _actor.MovieID = actor.MovieID;

                _context.SaveChanges();
            }

            return _actor;
        }

        public void DeleteActorByID(int actorID)
        {
            var _actor = _context.Actors.FirstOrDefault(actor => actor.ID == actorID);
            if (_actor != null)
            {
                _context.Actors.Remove(_actor);

                _context.SaveChanges();
            }
        }
    }
}
