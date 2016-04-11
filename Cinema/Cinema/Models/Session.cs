using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;

namespace Cinema.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Hall { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
        public Status Status { get; set; }
        public ICollection<int> FreeSeats { get; set; }
        public int SeatCount { get; set; }

        public Session(string name, int hall, int price, DateTime time, Status status)
        {
            Id = Guid.NewGuid();
            Name = name;
            Hall = hall;
            Price = price;
            Time = time;
            Status = status;
            switch (Hall)
            {
                case 1:
                    SeatCount = 5;
                    break;
                case 2:
                    SeatCount = 20;
                    break;
                case 3:
                    SeatCount = 50;
                    break; 
            }
            FreeSeats = new List<int>(); 
            for(int i=0; i<SeatCount; i++)
            {
                FreeSeats.Add(i + 1);
            }
        }
        public Session() : this("UNKNOWN", -111, -111, DateTime.Now, Status.Sold)
        {

        }

    }
}

public enum Status
{
    InStock,
    Sold
}