using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public class Ticket
    {
        public string Code { get; set; }
        public Show Show { get; set; }
        public Screen Screen { get; set; }
        public int SeatNumber { get; set; }

        public Ticket(string code, Show show, Screen screen, int seatNumber)
        {
            this.Code = code;
            this.Show = show;
            this.Screen = screen;
            this.SeatNumber = seatNumber;
        }

        public override string ToString()
        {
            return Code + " kodlu bilet " + Show.Cinema.Name + " sineması için " + Show.Day + " tarihinde " + Screen.Name  + " adlı salonda " + SeatNumber + " numaralı koltukta izlenecektir. ";
        }

    }
}
