using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_CSharpIMDbProject.Data.ViewModels
{
    public class MovieVM
    {
        public string MovieName { get; set; }
        public string MovieDesc { get; set; }
        public string ReleaseDate { get; set; }
        public int GenreID { get; set; }
    }
}
