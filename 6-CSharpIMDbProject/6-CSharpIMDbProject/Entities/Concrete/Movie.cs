using _6_CSharpIMDbProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Entities.Concrete
{
    public class Movie : IEntity
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string MovieDesc { get; set; }
        public string ReleaseDate { get; set; }
        public int GenreID { get; set; }
    }
}
