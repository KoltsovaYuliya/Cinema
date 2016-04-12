using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class Film
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public FilmGenre Genre { get; set; }
        public int Age { get; set; }
        public int LenghtInMinutes { get; set; }
        public string Country { get; set; }

        public Film(string name, int year, FilmGenre genre, int age, int lenghtInMinutes, string country)
        {
            Id = Guid.NewGuid();
            Name = name;
            Year = year;
            Genre = genre;
            Age = age;
            LenghtInMinutes = lenghtInMinutes;
            Country = country;
        }

        public Film() : this("UNKNOWN", -111, FilmGenre.Unknown, -111, -111, "UNKNOWN")
        {

        }

        public string GetGenreString()
        {
            switch(Genre)
            {
                case FilmGenre.Anime:
                    return "Аниме";
                case FilmGenre.Cartoon:
                    return "Мультфильм";
                case FilmGenre.Film:
                    return "Фильм";
                case FilmGenre.Unknown:
                default:
                    return "UNKNOWN";
            }
        }
    }

    public enum FilmGenre
    {
        Cartoon,
        Film,
        Anime,
        Unknown
    }
}