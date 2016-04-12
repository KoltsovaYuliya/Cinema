using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class Operation
    {
        public Guid Id { get; set; }
        public OperationType Type { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Time { get; set; }
        public string Person { get; set; }
    }

    public enum OperationType
    {
        Add,
        Sold
    }
}