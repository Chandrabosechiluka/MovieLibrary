using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Controllers
{
    public class MovieManager
    {
        private static List<Movie> movies;

        static MovieManager()
        {
            movies = MovieSerialization.DeserializeMovies();
        }

        public static List<Movie> GetAllMovies()
        {
            if (!movies.Any())
            {
                throw new NoMoviesAvailableException("No movies are available to display.");
            }

            return movies;
        }

        public static void AddMovie(Movie movie)
        {
            if (movies.Any(m => m.Title.Equals(movie.Title, System.StringComparison.OrdinalIgnoreCase)))
            {
                throw new DuplicateMovieException($"A movie with the title \"{movie.Title}\" already exists.");
            }

            movies.Add(movie);
            MovieSerialization.SerializeMovies(movies);
        }

        public static void EditMovie(int id, Movie updatedMovie)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new MovieNotFoundException($"Movie with ID {id} was not found.");
            }

            movie.Title = updatedMovie.Title;
            movie.Director = updatedMovie.Director;
            movie.ReleaseYear = updatedMovie.ReleaseYear;
            MovieSerialization.SerializeMovies(movies);
        }

        public static Movie FindMovieById(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new MovieNotFoundException($"Movie with ID {id} was not found.");
            }

            return movie;
        }

        public static Movie FindMovieByName(string title)
        {
            var movie = movies.FirstOrDefault(m => m.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
            if (movie == null)
            {
                throw new MovieNotFoundException($"Movie with the title \"{title}\" was not found.");
            }

            return movie;
        }

        public static void RemoveMovieById(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new MovieNotFoundException($"Movie with ID {id} was not found.");
            }

            movies.Remove(movie);
            MovieSerialization.SerializeMovies(movies);
        }

        public static void RemoveMovieByName(string title)
        {
            var movie = movies.FirstOrDefault(m => m.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
            if (movie == null)
            {
                throw new MovieNotFoundException($"Movie with the title \"{title}\" was not found.");
            }

            movies.Remove(movie);
            MovieSerialization.SerializeMovies(movies);
        }

        public static void ClearAllMovies()
        {
            if (!movies.Any())
            {
                throw new NoMoviesAvailableException("No movies available to clear.");
            }

            movies.Clear();
            MovieSerialization.SerializeMovies(movies);
        }

        public static void ExitApp()
        {
            MovieSerialization.SerializeMovies(movies);
        }
    }
}
