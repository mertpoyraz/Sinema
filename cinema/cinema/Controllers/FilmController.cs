using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class FilmController
    {
        private static List<Film> films;
        private static SeriesController seriesController = new SeriesController();

        public FilmController()
        {
            films = new List<Film>();
        }

        public void AddFilm(Film film)
        {
            if (seriesController.FindSeriesByCode(film.Code) != null)
            {
                Console.WriteLine(film.Code + " kodlu sinema dizi olarak ekli.");
                return;
            }
            foreach (var filmItem in films)
            {
                if (film.Code.Equals(filmItem.Code) || seriesController.FindSeriesByCode(film.Code) != null)
                {
                    Console.WriteLine(film.Code + " kodlu film ya da dizi zaten ekli.");
                    return;
                }
            }
            films.Add(film);
            Console.WriteLine(film.Name + " adlı film başarıyla eklendi.");
        }

        public void DeleteFilm(Film film)
        {
            for (int i = 0; i < films.Count; i++)
            {
                if (film.Code.Equals(films[i].Code))
                {
                    films.RemoveAt(i);
                    Console.WriteLine(film.Code + " kodlu film silindi.");
                    return;
                }
            }
            Console.WriteLine(film.Code + " kodlu film bulunamadı.");
        }

        public Film FindFilmByCode(string code)
        {
            foreach (var filmItem in films)
            {
                if (code.Equals(filmItem.Code))
                {
                    return filmItem;
                }
            }
            Console.WriteLine(code + " kodlu film bulunamadı");
            return null;
        }

        public void ShowFilms()
        {
            Console.WriteLine("------------------- Filmler -------------------");
            for(int i = 0; i< films.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + films[i]);
            }
            Console.WriteLine("-----------------------------------------------");
        }

    }
}
