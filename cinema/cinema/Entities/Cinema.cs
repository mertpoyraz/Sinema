using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Entities
{
    public abstract class Cinema
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Productor { get; set; }
        public string Language { get; set; }

        public Cinema(string code, string name, string productor, string language)
        {
            this.Code = code;
            this.Name = name;
            this.Productor = productor;
            this.Language = language;
        }
    }
}
