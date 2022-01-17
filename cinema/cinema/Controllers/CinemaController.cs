using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class CinemaController
    {
        private FilmController filmController = new FilmController();
        private SeriesController seriesController = new SeriesController();
        public void ShowCinemas()
        {
            filmController.ShowFilms();
            seriesController.ShowSeries();
        }

        public Cinema FindCinemaByCode(string code)
        {
            if(filmController.FindFilmByCode(code) != null)
            {
                return filmController.FindFilmByCode(code);
            }
            if(seriesController.FindSeriesByCode(code) != null)
            {
                return seriesController.FindSeriesByCode(code);
            }
            Console.WriteLine("Yazılan kod doğru değil!");
            return null;
        }
    }
}
