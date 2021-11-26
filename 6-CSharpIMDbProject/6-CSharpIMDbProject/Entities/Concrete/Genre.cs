using _6_CSharpIMDbProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Entities.Concrete
{
    public class Genre : IEntity
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
    }
}
