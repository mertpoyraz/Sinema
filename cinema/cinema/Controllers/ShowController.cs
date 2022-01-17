using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class ShowController
    {
        private static List<Show> shows;

        public ShowController()
        {
            shows = new List<Show>();
        }

        public void AddShow(Show show)
        {
            foreach (var showItem in shows)
            {
                if (show.Id.Equals(showItem.Id))
                {
                    Console.WriteLine(showItem.Id + " idli gösterim zaten ekli.");
                    return;
                }
            }
            shows.Add(show);
            Console.WriteLine(show.Id + " idli gösterim başarıyla eklendi.");
        }

        public void DeleteShow(Show show)
        {
            for (int i = 0; i < shows.Count; i++)
            {
                if (show.Id.Equals(shows[i].Id))
                {
                    shows.RemoveAt(i);
                    Console.WriteLine(show.Id + " idli gösterim silindi.");
                    return;
                }
            }
            Console.WriteLine(show.Id + " idli gösterim bulunamadı.");
        }

        public Show FindShowById(int id)
        {
            foreach (var showItem in shows)
            {
                if (id == showItem.Id)
                {
                    return showItem;
                }
            }
            Console.WriteLine(id + " idli gösterim bulunamadı");
            return null;
        }

        public void ShowShows()
        {
            Console.WriteLine("------------------- Gösterimler -------------------");
            for (int i = 0; i < shows.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + shows[i]);
            }
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
