using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class Session
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
        public int Hall { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
        public Status Status { get; set; }
        public int SeatNumber { get; set; }

        public Session(Guid filmId, int hall, int price, DateTime time, Status status, int seatNumber)
        {
            Id = Guid.NewGuid();
            FilmId = filmId;
            Hall = hall;
            Price = price;
            Time = time;
            Status = status;
            SeatNumber = seatNumber;
        }
        public Session() : this(Guid.NewGuid(), -111, -111, DateTime.Now, Status.Sold, -111)
        {

        }
    }

    public enum Status
    {
        InStock,
        Sold
    }
}