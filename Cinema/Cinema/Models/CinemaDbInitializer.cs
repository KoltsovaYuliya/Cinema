using Cinema.Infrastructure;
using Cinema.Models.CinemaModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class CinemaDbInitializer : DropCreateDatabaseAlways<CinemaDbContext>
    {
        protected override void Seed(CinemaDbContext db)
        {
            var repo = new CinemaRepository();

            repo.AddSessionsPack(new Film("Зверополис", 2016, FilmGenre.Cartoon, 6, 108, "США"), new Session(Guid.NewGuid(), 1, 50000, new DateTime(2016, 4, 15, 18, 0, 0), Status.InStock, 1), new Hall(1));
            repo.AddSessionsPack(new Film("Бэтмен против Супермена: На заре справедливости", 2016, FilmGenre.Film, 16, 153, "США"), new Session(Guid.NewGuid(), 1, 75000, new DateTime(2016, 4, 15, 20, 4, 0), Status.InStock, 1), new Hall(1));
            repo.AddSessionsPack(new Film("Герой", 2016, FilmGenre.Film, 12, 86, "Россия"), new Session(Guid.NewGuid(), 2, 55000, new DateTime(2016, 4, 15, 17, 1, 0), Status.InStock, 1), new Hall(2));
            repo.AddSessionsPack(new Film("Книга Джунглей", 2016, FilmGenre.Film, 12, 105, "США"), new Session(Guid.NewGuid(), 2, 65000, new DateTime(2016, 4, 15, 21, 1, 0), Status.InStock, 1), new Hall(2));
            repo.AddSessionsPack(new Film("Миссия в Майами", 2016, FilmGenre.Film, 16, 102, "США"), new Session(Guid.NewGuid(), 3, 35000, new DateTime(2016, 4, 15, 15, 2, 0), Status.InStock, 1), new Hall(3));

            //db.Sessions.Add(new Session("Зверополис", 1, 50000, new DateTime(2016, 4, 15, 18, 0, 0), Status.InStock));
            //db.Sessions.Add(new Session("Бэтмен против Супермена: На заре справедливости", 1, 75000, new DateTime(2016, 4, 15, 20, 4, 0), Status.InStock));
            //db.Sessions.Add(new Session("Герой", 2, 55000, new DateTime(2016, 4, 15, 17, 1, 0), Status.InStock));
            //db.Sessions.Add(new Session("Книга Джунглей", 2, 65000, new DateTime(2016, 4, 15, 21, 1, 0), Status.InStock));
            //db.Sessions.Add(new Session("Миссия в Майами", 3, 35000, new DateTime(2016, 4, 15, 15, 2, 0), Status.InStock));

            //db.SaveChanges();
            base.Seed(db);
        }
    }
}