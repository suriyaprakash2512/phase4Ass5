// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

public class Movie
{
    public int ID { get; set; }
    public string? Title { get; set; }


}

public class MovieRepository
{
    public List<Movie> movies;

    public MovieRepository()
    {
        movies = new List<Movie>
        {
            new Movie { Title = "Master", ID = 1  },
            new Movie { Title = "Jailer",ID=2 },
            new Movie { Title = "Dada", ID=3 },
            new Movie{Title="Good night",ID=4}
        };
    }

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public Movie GetMovieById(int ID)
    {
        return movies.FirstOrDefault(m => m.ID == ID);
    }
}

public class Program
{
    public static MovieRepository movieRepository;

    public static void Main(string[] args)
    {
        movieRepository = new MovieRepository();

        DisplayMenu();
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. List all movies");
        Console.WriteLine("2. Get a movie by ID");
        Console.WriteLine("3. Exit");

        switch (Console.ReadLine())
        {
            case "1":
                ListAllMovies();
                break;
            case "2":
                GetMovieById();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    public static void ListAllMovies()
    {
        Console.WriteLine("Movies:");
        foreach (var movie in movieRepository.GetAllMovies())
        {
            Console.WriteLine($"{movie.Title} - {movie.ID}");
        }

        DisplayMenu();
    }

    public static void GetMovieById()
    {
        Console.WriteLine("Enter the movie title:");
        int id = int.Parse(Console.ReadLine());

        var movie = movieRepository.GetMovieById(id);
        if (movie != null)
        {
            Console.WriteLine($"Movie: {movie.ID} - {movie.Title}");
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }

        DisplayMenu();
    }
}