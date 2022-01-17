using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public class Series : Cinema
    {
        public int NumberOfEpisodes { get; set; }

        public Series(string code, string name, string productor, string language, int numberOfEpisodes) : base(code, name, productor, language)
        {
            NumberOfEpisodes = numberOfEpisodes;
        }

        public override string ToString()
        {
            return Code + " koduyla " + Name + " adlı dizi " + Language + " dilinde " + Productor + " yapımcısı tarafından " + NumberOfEpisodes + " bölüm sürmektedir.";
        }
    }
}
