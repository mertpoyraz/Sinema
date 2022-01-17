using cinema.Controllers;
using cinema.Entities;
using System;

namespace cinema
{
    class Program
    {
        static CinemaController cinemaController = new CinemaController();
        static FilmController filmController = new FilmController();
        static ScreenController screenController = new ScreenController();
        static SeriesController seriesController = new SeriesController();
        static ShowController showController = new ShowController();
        static TicketController ticketController = new TicketController();
        public const string Menu =  "------------ HTR Sinemaları ------------\n" +
                                    "Menü\n" +
                                    "0) Çıkış yap\n" +
                                    "1) Film işlemleri\n" +
                                    "2) Dizi işlemleri\n" +
                                    "3) Salon işlemleri\n" +
                                    "4) Gösterim işlemleri\n" +
                                    "5) Bilet işlemleri\n" +
                                    "------------------------------------------";
        public const string FilmMenu = "------------ HTR Sinemaları ------------\n" +
                                       "Film Menüsü\n" +
                                       "-1) Geri\n" +
                                       "0) Çıkış yap\n" +
                                       "1) Film ekle\n" +
                                       "2) Film sil\n" +
                                       "3) Filmleri listele\n" +
                                       "4) Kod ile film bul\n" + 
                                       "------------------------------------------";
        public const string SeriesMenu = "------------ HTR Sinemaları ------------\n" +
                                       "Dizi Menüsü\n" +
                                       "-1) Geri\n" +
                                       "0) Çıkış yap\n" +
                                       "1) Dizi ekle\n" +
                                       "2) Dizi sil\n" +
                                       "3) Dizileri listele\n" +
                                       "4) Kod ile dizi bul\n" + 
                                       "------------------------------------------";
        public const string ScreenMenu = "------------ HTR Sinemaları ------------\n" +
                                         "Salon Menüsü\n" +
                                         "-1) Geri\n" +
                                         "0) Çıkış yap\n" +
                                         "1) Salon ekle\n" +
                                         "2) Salon sil\n" +
                                         "3) Salonları listele\n" +
                                         "4) Id ile salon bul\n" + 
                                        "------------------------------------------";
        public const string ShowMenu = "------------ HTR Sinemaları ------------\n" +
                                       "Gösterim Menüsü\n" +
                                       "-1) Geri\n" +
                                       "0) Çıkış yap\n" +
                                       "1) Gösterim ekle\n" +
                                       "2) Gösterim sil\n" +
                                       "3) Gösterimleri listele\n" +
                                       "4) Id ile gösterim bul\n" +
                                        "------------------------------------------";
        public const string TicketMenu = "------------ HTR Sinemaları ------------\n" +
                                         "Bilet Menüsü\n" +
                                         "-1) Geri\n" +
                                         "0) Çıkış yap\n" +
                                         "1) Bilet sat\n" +
                                         "2) Bilet sil\n" +
                                         "3) Biletleri listele\n" +
                                         "4) Kod ile bilet bul\n" +
                                         "5) Gösterim ve salon id ile koltukları listele\n" +
                                         "------------------------------------------";
        public const string MakeAChoice = "Lütfen seçim yapınız: ";
        public static TicketPrice ticketPrice = new TicketPrice();
        static void Main(string[] args)
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(Menu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;
                    case 1:
                        FilmManagement();
                        break;
                    case 2:
                        SeriesManagement();
                        break;
                    case 3:
                        ScreenManagement();
                        break;
                    case 4:
                        ShowManagement();
                        break;
                    case 5:
                        TicketManagement();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void FilmManagement()
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(FilmMenu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Geri dönülüyor...");
                        return;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        AddFilm();
                        break;
                    case 2:
                        DeleteFilm();
                        break;
                    case 3:
                        filmController.ShowFilms();
                        break;
                    case 4:
                        FindFilmByCode();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void AddFilm()
        {
            string code, name, language, productor;
            int durationInMinutes;
            Console.Write("Lütfen film kodunu giriniz: ");
            code = Console.ReadLine();
            Console.Write("Lütfen film adını giriniz: ");
            name = Console.ReadLine();
            Console.Write("Lütfen film dilini giriniz: ");
            language = Console.ReadLine();
            Console.Write("Lütfen produktör adını giriniz: ");
            productor = Console.ReadLine();
            Console.Write("Lütfen film süresini dakika cinsinden giriniz: ");
            durationInMinutes = Convert.ToInt32(Console.ReadLine());
            Film film = new Film(code, name, productor, language, durationInMinutes);
            filmController.AddFilm(film);
        }

        static void DeleteFilm()
        {
            string code;
            Console.Write("Lütfen film kodunu giriniz: ");
            code = Console.ReadLine();
            Film film = new Film(code, null, null, null, 0);
            filmController.DeleteFilm(film);
        }

        static void FindFilmByCode()
        {
            string code;
            Console.Write("Lütfen film kodunu giriniz: ");
            code = Console.ReadLine();
            Film film = filmController.FindFilmByCode(code);
            if(film == null)
            {
                Console.WriteLine("Film bulunamadı");
                return;
            }
            Console.WriteLine(film);
        }

        static void SeriesManagement()
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(SeriesMenu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Geri dönülüyor...");
                        return;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        AddSeries();
                        break;
                    case 2:
                        DeleteSeries();
                        break;
                    case 3:
                        seriesController.ShowSeries();
                        break;
                    case 4:
                        FindSeriesByCode();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void AddSeries()
        {
            string code, name, language, productor;
            int numberOfEpisodes;
            Console.Write("Lütfen dizi kodunu giriniz: ");
            code = Console.ReadLine();
            Console.Write("Lütfen dizi adını giriniz: ");
            name = Console.ReadLine();
            Console.Write("Lütfen dizi dilini giriniz: ");
            language = Console.ReadLine();
            Console.Write("Lütfen produktör adını giriniz: ");
            productor = Console.ReadLine();
            Console.Write("Lütfen dizi bölüm sayısını giriniz: ");
            numberOfEpisodes = Convert.ToInt32(Console.ReadLine());
            Series series = new Series(code, name, productor, language, numberOfEpisodes);
            seriesController.AddSeries(series);
        }

        static void DeleteSeries()
        {
            string code;
            Console.Write("Lütfen dizi kodunu giriniz: ");
            code = Console.ReadLine();
            Series series = new Series(code, null, null, null, 0);
            seriesController.DeleteSeries(series);
        }

        static void FindSeriesByCode()
        {
            string code;
            Console.Write("Lütfen dizi kodunu giriniz: ");
            code = Console.ReadLine();
            Series series = seriesController.FindSeriesByCode(code);
            if(series == null)
            {
                Console.WriteLine("Aranan dizi bulunamadı.");
                return;
            }
            Console.WriteLine(series);
        }


        static void ScreenManagement()
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(ScreenMenu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Geri dönülüyor...");
                        return;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        AddScreen();
                        break;
                    case 2:
                        DeleteScreen();
                        break;
                    case 3:
                        screenController.ShowScreens();
                        break;
                    case 4:
                        FindScreenById();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void AddScreen()
        {
            string name;
            int id, seatCount;
            Console.Write("Lütfen salon idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lütfen salon adını giriniz: ");
            name = Console.ReadLine();
            Console.Write("Lütfen salon koltuk sayısını giriniz: ");
            seatCount = Convert.ToInt32(Console.ReadLine());
            Screen screen = new Screen(id, name, seatCount);
            screenController.AddScreen(screen);
        }

        static void DeleteScreen()
        {
            int id;
            Console.Write("Lütfen salon idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            Screen screen = new Screen(id, null, 0);
            screenController.DeleteScreen(screen);
        }

        static void FindScreenById()
        {
            int id;
            Console.Write("Lütfen salon idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            Screen screen = screenController.FindScreenById(id);
            if(screen == null)
            {
                Console.WriteLine("Aranan salon bulunamadı");
                return;
            }
            Console.WriteLine(screen);
        }

        static void ShowManagement()
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(ShowMenu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Geri dönülüyor...");
                        return;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        AddShow();
                        break;
                    case 2:
                        DeleteShow();
                        break;
                    case 3:
                        showController.ShowShows();
                        break;
                    case 4:
                        FindShowById();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void AddShow()
        {
            int id, day;
            string code;
            Cinema cinema = null;
            Console.Write("Lütfen gösterim idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            cinemaController.ShowCinemas();
            while (cinema == null)
            {
                Console.Write("Lütfen gösterilen listede sinema kodunu giriniz: ");
                code = Console.ReadLine();
                cinema = cinemaController.FindCinemaByCode(code);
            }
            Console.Write("Lütfen gösterimin hangi gün olacağını sayı olarak giriniz: ");
            day = Convert.ToInt32(Console.ReadLine());
            
            Show show = new Show(id, cinema, day);
            showController.AddShow(show);
        }

        static void DeleteShow()
        {
            int id;
            Console.Write("Lütfen gösterim idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            Show show = new Show(id, null, 0);
            showController.DeleteShow(show);
        }

        static void FindShowById()
        {
            int id;
            Console.Write("Lütfen gösterim idsini giriniz: ");
            id = Convert.ToInt32(Console.ReadLine());
            Show show = showController.FindShowById(id);
            if(show == null)
            {
                Console.WriteLine("Aranan gösterim bulunamadı.");
                return;
            }
            Console.WriteLine(show);
        }

        static void TicketManagement()
        {
            
            int choice;
            while (true)
            {
                Console.WriteLine(TicketMenu);
                Console.Write(MakeAChoice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Geri dönülüyor...");
                        return;
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...");
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        SellTicket();
                        break;
                    case 2:
                        DeleteTicket();
                        break;
                    case 3:
                        ticketController.ShowTickets();
                        break;
                    case 4:
                        FindTicketByCode();
                        break;
                    case 5:
                        ShowAllSeatsByShowIdAndScreenId();
                        break;
                    default:
                        Console.WriteLine("Lütfen menüde gösterildiği şekilde seçim yapınız");
                        break;
                }
            }
        }

        static void SellTicket()
        {
            string code;
            int seatNumber = 0, showId,screenId;
            Show show = null;
            Screen screen = null;
            Console.Write("Lütfen bilet kodu giriniz: ");
            code = Console.ReadLine();
            showController.ShowShows();
            while (show == null)
            {
                Console.Write("Lütfen gösterilen listede gösterim idsini giriniz: ");
                showId = Convert.ToInt32(Console.ReadLine());
                show = showController.FindShowById(showId);
            }
            screenController.ShowScreens();
            while(screen == null)
            {
                Console.Write("Lütfen gösterilen listede salon idsini giriniz: ");
                screenId = Convert.ToInt32(Console.ReadLine());
                screen = screenController.FindScreenById(screenId);
            }
            while (seatNumber <= 0 || seatNumber > screen.SeatCount)
            {
                Console.Write("Lütfen koltuk numarası giriniz (koltuk numarası 0'dan küçük ya da salon koltuk sayısından büyük olamaz): ");
                seatNumber = Convert.ToInt32(Console.ReadLine());
            }



            Ticket ticket = new Ticket(code, show, screen, seatNumber);
            ticketController.SellTicket(ticket);
        }

        static void DeleteTicket()
        {
            string code;
            Console.Write("Lütfen bilet kodunu giriniz: ");
            code = Console.ReadLine();
            Ticket ticket = new Ticket(code, null, null, 0);
            ticketController.DeleteTicket(ticket);
        }

        static void FindTicketByCode()
        {
            string code;
            Console.Write("Lütfen bilet kodunu giriniz: ");
            code = Console.ReadLine();
            Ticket ticket = ticketController.FindTicketByCode(code);
            if (ticket == null)
            {
                Console.WriteLine("Aranan bilet bulunamadı.");
                return;
            }
            Console.WriteLine(ticket);
        }

        static void ShowAllSeatsByShowIdAndScreenId()
        {
            int showId, screenId;
            Console.Write("Lütfen gösterim idsini giriniz: ");
            showId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lütfen salon idsini giriniz: ");
            screenId = Convert.ToInt32(Console.ReadLine());
            ticketController.ShowAllSeatsByShowIdAndScreenId(showId, screenId);
        }
    }

    struct TicketPrice
    {
        public const double Price = 18.00;
        public double Discount { get; set; }
    }
}
