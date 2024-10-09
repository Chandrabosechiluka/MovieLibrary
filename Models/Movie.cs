using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    [Serializable]
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Director: {Director}, Release Year: {ReleaseYear}";
        }
    }
}
