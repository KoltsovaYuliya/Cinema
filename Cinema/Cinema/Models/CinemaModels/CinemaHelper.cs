using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public static class CinemaHelper
    {
        public static FilmGenre ConvertStringToGenre(string str)
        {
            switch(str)
            {
                case "Аниме":
                    return FilmGenre.Anime;
                case "Мультфильм":
                    return FilmGenre.Cartoon;
                case "Фильм":
                    return FilmGenre.Film;
                default:
                    return FilmGenre.Unknown;
            }
        }
    }
}