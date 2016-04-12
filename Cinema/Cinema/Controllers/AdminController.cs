using Cinema.Models.CinemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Cinema.Infrastructure.CinemaRepository repo = new Infrastructure.CinemaRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("InStock");
        }

        public ActionResult Sold()
        {
            var sessions = repo.GetAllSessionsByStatus(Status.Sold);
            var list = new List<FilmSession>();

            foreach(var s in sessions)
            {
                list.Add(new FilmSession(repo.GetFilmById(s.FilmId), s));
            }

            ViewBag.Data = list;

            return View();
        }

        public ActionResult InStock()
        {
            // получаем из бд все объекты Session
            var filmsGuid = repo.GetFilmIdByStatus(Status.InStock);
            var films = new List<Film>();
            foreach (var guid in filmsGuid)
            {
                films.Add(repo.GetFilmById(guid));
            }
            // передаем все объекты в динамическое свойство Sessions в ViewBag
            ViewBag.Films = films;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("InStock", "Admin");
            }
            var id = new Guid(Id);
            var session = repo.GetSessionById(id);
            if (session == null)
            {
                return RedirectToAction("InStock", "Admin");
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
                return RedirectToAction("Result", "Admin", new { header = "Ошибка! Такая сессия не найдена.", good = false });
            }
            if (string.IsNullOrEmpty(operation.Person))
            {
                return RedirectToAction("Result", "Admin", new { header = "Ошибка! Вы не ввели своё имя.", good = false });
            }

            session.Status = Status.Sold;
            repo.ChangeSession(session);

            operation.Time = DateTime.Now;
            operation.Type = OperationType.Sold;
            operation.Id = Guid.NewGuid();
            repo.AddOperation(operation);

            return RedirectToAction("Result", "Admin", new { header = "Успешно продано!", good = true });
        }

        public ActionResult Film(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("InStock", "Admin");
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

        [HttpGet]
        public ActionResult AddSession()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSession(AddSessionModel model)
        {
            repo.AddSessionsPack(new Film(model.FilmName, int.Parse(model.FilmYear), CinemaHelper.ConvertStringToGenre(model.FilmGenre),
                int.Parse(model.FilmYear), int.Parse(model.FilmLenghtInMinutes), model.FilmCountry),
                new Session(Guid.NewGuid(), int.Parse(model.SessionHall), int.Parse(model.SessionPrice), Convert.ToDateTime(model.SessionTime), Status.InStock, 1),
                new Hall(int.Parse(model.SessionHall)));

            return RedirectToAction("Index", "Admin");
        }
    }
}