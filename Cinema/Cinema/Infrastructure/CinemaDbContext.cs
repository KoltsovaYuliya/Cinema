using Cinema.Models;
using Cinema.Models.CinemaModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Cinema.Infrastructure
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Film> Films { get; set; }
    }
}