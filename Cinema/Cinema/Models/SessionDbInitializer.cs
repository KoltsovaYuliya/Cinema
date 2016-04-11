using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cinema.Models;
using Cinema.Infrastructure;

namespace Cinema.Models
{
    public class SessionDbInitializer : DropCreateDatabaseAlways<SessionContext>
    {
        protected override void Seed(SessionContext db)
        {
            var repo = new CinemaRepository();

            db.Sessions.Add(new Session("Зверополис", 1, 50000, new DateTime(2016, 4, 15, 18, 0, 0), Status.InStock));
            db.Sessions.Add(new Session("Бэтмен против Супермена: На заре справедливости", 1, 75000, new DateTime(2016, 4, 15, 20, 4, 0), Status.InStock));
            db.Sessions.Add(new Session("Герой", 2, 55000, new DateTime(2016, 4, 15, 17, 1, 0), Status.InStock));
            db.Sessions.Add(new Session("Книга Джунглей",2, 65000, new DateTime(2016, 4, 15, 21, 1, 0), Status.InStock));
            db.Sessions.Add(new Session("Миссия в Майами", 3, 35000, new DateTime(2016, 4, 15, 15, 2, 0), Status.InStock));

            db.SaveChanges();
            base.Seed(db);
        }
    }
}