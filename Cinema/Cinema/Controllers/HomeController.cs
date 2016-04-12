using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;
using Cinema.Infrastructure;
using Cinema.Models.CinemaModels;

namespace SessionStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        CinemaRepository repo = new CinemaRepository();

        public ActionResult Index()
        {
            // получаем из бд все объекты Session
            var filmsGuid = repo.GetFilmIdByStatus(Status.InStock);
            var films = new List<Film>();
            foreach(var guid in filmsGuid)
            {
                films.Add(repo.GetFilmById(guid));
            }
            // передаем все объекты в динамическое свойство Sessions в ViewBag
            ViewBag.Films = films;
            // возвращаем представление
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Buy(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("Index", "Home");
            }
            var id = new Guid(Id);
            var session = repo.GetSessionById(id);
            if(session == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Session = session;
            ViewBag.Film = repo.GetFilmById(session.FilmId);
            return View();
        }
        [HttpPost]
        public ActionResult Buy(Operation operation)
        {
            var session = repo.GetSessionById(operation.SessionId);
            if (session == null)
            {
                return RedirectToAction("Result", "Home", new { header = "Ошибка! Такая сессия не найдена.", good = false });
            }
            if(string.IsNullOrEmpty(operation.Person))
            {
                return RedirectToAction("Result", "Home", new { header = "Ошибка! Вы не ввели своё имя.", good = false });
            }

            session.Status = Status.Sold;
            repo.ChangeSession(session);

            operation.Time = DateTime.Now;
            operation.Type = OperationType.Sold;
            operation.Id = Guid.NewGuid();
            repo.AddOperation(operation);

            return RedirectToAction("Result", "Home", new { header = "Спасибо, " + operation.Person + ", за покупку!", good = true });
        }

        public ActionResult Film(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            var filmId = new Guid(id);
            var sessions = repo.GetAllInStockSessionsByFilmId(filmId).OrderBy(o => o.SeatNumber);
            // передаем все объекты в динамическое свойство Sessions в ViewBag
            ViewBag.Sessions = sessions;
            ViewBag.Film = repo.GetFilmById(filmId);

            return View();
        }

        public ActionResult Result(string header, bool good)
        {
            ViewBag.Header = header;
            if (good)
            {
                ViewBag.Message = "Для нас каждый клиент важен. Будем рады обслужить Вас ещё раз. Пользуйтесь услугами нашего сервиса.";
            }
            else
            {
                ViewBag.Message = "Попробуйте заново купить билет.";
            }

            return View();
        }
    }
}