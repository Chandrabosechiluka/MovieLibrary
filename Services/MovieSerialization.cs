using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class MovieSerialization
    {
        private static string filePath = @"C:\Users\CHANDRA BOSE\OneDrive\Desktop\Objects\movies.json";

        public static void SerializeMovies(List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, json);

        }

        public static List<Movie> DeserializeMovies()
        {
            if (!File.Exists(filePath))
            {
                return new List<Movie>();
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }
    }
}
