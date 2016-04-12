using Cinema.Models;
using Cinema.Models.CinemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Infrastructure
{
    public class CinemaRepository
    {
        CinemaDbContext _db = new CinemaDbContext();

        #region Session

        public Session GetSessionById(Guid id)
        {
            return _db.Sessions.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Session> GetAllSessions()
        {
            return _db.Sessions.ToList();
        }

        public void AddSession(Session session)
        {
            _db.Sessions.Add(session);
            _db.SaveChanges();
        }

        public void DeleteSession(Guid id)
        {
            var session = GetSessionById(id);
            if (session == null)
                return;
            _db.Sessions.Remove(session);
            _db.SaveChanges();
        }

        public void ChangeSession(Session session)
        {
            DeleteSession(session.Id);
            AddSession(session);
        }

        public void RemoveFreeSeat(Guid sessionId, int seatNumber)
        {
            var session = GetSessionById(sessionId);
            if (session == null)
                return;

            ChangeSession(session);
        }

        public void AddSessionsPack(Film film, Session session, Hall hall)
        {
            AddFilm(film);

            var hallSize = hall.Size;
            for(int i = 0; i < hallSize; i++)
            {
                var temp = new Session(film.Id, session.Hall, session.Price, session.Time, session.Status, i + 1);
                AddSession(temp);
            }
        }

        public List<Session> GetAllSessionsByStatus(Status status)
        {
            return _db.Sessions.Where(o => o.Status == status).ToList();
        }

        public List<Session> GetAllInStockSessionsByFilmId(Guid id)
        {
            return _db.Sessions.Where(o => o.Status == Status.InStock && o.FilmId == id).ToList();
        }

        #endregion

        #region Operation
        public Operation GetOperationById(Guid id)
        {
            return _db.Operations.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Operation> GetAllOperations()
        {
            return _db.Operations.ToList();
        }

        public void AddOperation(Operation operation)
        {
            _db.Operations.Add(operation);
            _db.SaveChanges();
        }

        public void DeleteOperation(Guid id)
        {
            var operation = GetOperationById(id);
            if (operation == null)
                return;
            _db.Operations.Remove(operation);
            _db.SaveChanges();
        }

        public void ChangeOperation(Operation operation)
        {
            DeleteOperation(operation.Id);
            AddOperation(operation);
        }
        #endregion

        #region Film

        public Film GetFilmById(Guid id)
        {
            return _db.Films.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Film> GetAllFilms()
        {
            return _db.Films.ToList();
        }

        public void AddFilm(Film film)
        {
            _db.Films.Add(film);
            _db.SaveChanges();
        }

        public void DeleteFilm(Guid id)
        {
            var film = GetFilmById(id);
            if (film == null)
                return;
            _db.Films.Remove(film);
            _db.SaveChanges();
        }

        public List<Guid> GetFilmIdByStatus(Status status)
        {
            var groups = _db.Sessions.Where(o => o.Status == status).GroupBy(o => o.FilmId).ToList();
            var list = new List<Guid>();
            foreach (var g in groups)
            {
                var first = g.FirstOrDefault();
                if (first != null)
                {
                    list.Add(first.FilmId);
                }
            }
            return list;
        }

        #endregion
    }
}