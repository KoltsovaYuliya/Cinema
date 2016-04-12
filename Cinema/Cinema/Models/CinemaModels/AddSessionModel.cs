using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class AddSessionModel
    {
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public string FilmYear { get; set; }
        public string FilmLenghtInMinutes { get; set; }
        public string FilmCountry { get; set; }
        public string FilmAge { get; set; }
        public string SessionHall { get; set; }
        public string SessionPrice { get; set; }
        public string SessionTime { get; set; }
    }
}