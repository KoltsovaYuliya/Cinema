using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Cinema.Models;
using System.Diagnostics;

namespace Cinema.Models
{
    public class Operation
    {
        public Guid Id { get; set; }
        public OperationType Type { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Time { get; set; }
        public int SeatNumber { get; set; }
        public string Person { get; set; }
    }
        

}

public enum OperationType
{
    Add,
    Sold
}