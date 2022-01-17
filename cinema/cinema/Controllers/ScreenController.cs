using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class ScreenController
    {
        private static List<Screen> screens;

        public ScreenController()
        {
            screens = new List<Screen>();
        }

        public void AddScreen(Screen screen)
        {
            foreach (var screenItem in screens)
            {
                if (screen.Id.Equals(screenItem.Id))
                {
                    Console.WriteLine(screen.Id + " idli salon zaten ekli.");
                    return;
                }
            }
            screens.Add(screen);
            Console.WriteLine(screen.Name + " adlı salon başarıyla eklendi.");
        }

        public void DeleteScreen(Screen screen)
        {
            for (int i = 0; i < screens.Count; i++)
            {
                if (screen.Id.Equals(screens[i].Id))
                {
                    screens.RemoveAt(i);
                    Console.WriteLine(screen.Id + " idli salon silindi.");
                    return;
                }
            }
            Console.WriteLine(screen.Id + " idli salon bulunamadı.");
        }

        public Screen FindScreenById(int id)
        {
            foreach (var screenItem in screens)
            {
                if (id == screenItem.Id)
                {
                    return screenItem;
                }
            }
            Console.WriteLine(id + " idli salon bulunamadı");
            return null;
        }

        public void ShowScreens()
        {
            Console.WriteLine("------------------- Salonlar -------------------");
            for (int i = 0; i < screens.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + screens[i]);
            }
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
