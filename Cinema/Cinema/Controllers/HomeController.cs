using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;
using Cinema.Infrastructure;

namespace SessionStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        CinemaRepository repo = new CinemaRepository();

        public ActionResult Index()
        {
            // получаем из бд все объекты Session
            var sessions = repo.GetAllSessionsByStatus(Status.InStock);
            // передаем все объекты в динамическое свойство Sessions в ViewBag
            ViewBag.Sessions = sessions;
            // возвращаем представление
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Buy(Guid id)
        {
            ViewBag.Session = repo.GetSessionById(id);
            return View();
        }
        [HttpPost]
        public string Buy(Operation operation)
        {
            operation.Time = DateTime.Now;
            operation.Type = OperationType.Sold;
            operation.Id = Guid.NewGuid();
            repo.AddOperation(operation);
            repo.RemoveFreeSeat(operation.SessionId, operation.SeatNumber);
            return "Спасибо," + operation.Person + ", за покупку!";
        }
    }
}