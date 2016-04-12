using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class FilmSession
    {
        public Film Film { get; set; }
        public Session Session { get; set; }

        public FilmSession(Film film, Session session)
        {
            Film = film;
            Session = session;
        }
    }
}