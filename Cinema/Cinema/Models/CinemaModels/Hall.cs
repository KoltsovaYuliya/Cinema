using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.CinemaModels
{
    public class Hall
    {
        public int Number { get; private set; }
        public HallSize Type { get; private set; }
        public int Size { get; private set; }

        public Hall(int number)
        {
            switch (number)
            {
                case 1:
                    Type = HallSize.VIP;
                    break;
                case 2:
                    Type = HallSize.Small;
                    break;
                case 3:
                default:
                    Type = HallSize.Big;
                    break;
            }

            Size = Convert.ToInt32(Type);
        }
    }

    public enum HallSize
    {
        VIP = 5,
        Small = 20,
        Big = 50
    }
}