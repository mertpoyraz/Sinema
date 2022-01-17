using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class SeriesController
    {
        private static List<Series> seriesList;
        private static FilmController filmController = new FilmController();

        public SeriesController()
        {
            seriesList = new List<Series>();
        }

        public void AddSeries(Series series)
        {
            if(filmController.FindFilmByCode(series.Code) != null)
            {
                Console.WriteLine(series.Code + " kodlu sinema film olarak ekli.");
                return;
            }
            foreach (var seriesItem in seriesList)
            {
                if (series.Code.Equals(seriesItem.Code) || filmController.FindFilmByCode(series.Code) !=null)
                {
                    Console.WriteLine(series.Code + " kodlu dizi ya da film zaten ekli.");
                    return;
                }
            }
            seriesList.Add(series);
            Console.WriteLine(series.Name + " adlı dizi başarıyla eklendi.");
        }

        public void DeleteSeries(Series series)
        {
            for (int i = 0; i < seriesList.Count; i++)
            {
                if (series.Code.Equals(seriesList[i].Code))
                {
                    seriesList.RemoveAt(i);
                    Console.WriteLine(series.Code + " kodlu dizi silindi.");
                    return;
                }
            }
            Console.WriteLine(series.Code + " kodlu dizi bulunamadı.");
        }

        public Series FindSeriesByCode(string code)
        {
            foreach (var seriesItem in seriesList)
            {
                if (code.Equals(seriesItem.Code))
                {
                    return seriesItem;
                }
            }
            Console.WriteLine(code + " kodlu dizi bulunamadı");
            return null;
        }

        public void ShowSeries()
        {
            Console.WriteLine("------------------- Diziler -------------------");
            for (int i = 0; i < seriesList.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + seriesList[i]);
            }
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
