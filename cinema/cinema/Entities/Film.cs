using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public class Film : Cinema
    {
        public int DurationInMinutes { get; set; }

        public Film(string code, string name, string productor, string language, int durationOnMinutes) : base(code, name, productor, language)
        {
            DurationInMinutes = durationOnMinutes;
        }

        public override string ToString()
        {
            return Code + " koduyla " + Name + " adlı film " + Language + " dilinde " + Productor + " yapımcısı tarafından " + DurationInMinutes + " dakika sürmektedir.";
        }
    }
}
