using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Cinema.Infrastructure
{
    public class SessionContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Operation> Operations { get; set; }
      //  public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
    }
}