using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Infrastructure
{
    public class CinemaRepository
    {
        SessionContext _db = new SessionContext();
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
            if (!session.FreeSeats.Contains(seatNumber))
            {
                return;
            }
            session.FreeSeats.Remove(seatNumber);
            ChangeSession(session);
        }

        public List<Session> GetAllSessionsByStatus(Status status)
        {
            return _db.Sessions.Where(o => o.Status==status).ToList();
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
    }
}