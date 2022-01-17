using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public class Screen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }

        public Screen(int id, string name, int seatCount)
        {
            this.Id = id;
            this.Name = name;
            this.SeatCount = seatCount;
        }

        public override string ToString()
        {
            return Id + " idli sahne " + Name + " adıyla " + SeatCount + " koltuğa sahiptir.";
        }
    }
}
