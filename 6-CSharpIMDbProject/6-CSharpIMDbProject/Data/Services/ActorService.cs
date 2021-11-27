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
    }
}
