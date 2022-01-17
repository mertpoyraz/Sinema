using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public class Show
    {
        public enum Gunler
        {
            Pazartesi = 1, Salı = 2, Çarşamba = 3, Perşembe = 4, Cuma = 5, Cumartesi = 6, Pazar = 7
        }

        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Gunler Day { get; set; }

        public Show(int id, Cinema cinema, int day )
        {
            this.Id = id;
            this.Cinema = cinema;
            this.Day = (Gunler) day;
        }

        public override string ToString()
        {
            return Id + " idli gösterim " + Cinema.Name + " sineması için " + Day + " gününde gösterime girecektir.";
        }
    }
}
