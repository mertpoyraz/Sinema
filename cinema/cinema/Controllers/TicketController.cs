using cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controllers
{
    public class TicketController
    {
        private ScreenController screenController = new ScreenController();
        private ShowController showController = new ShowController();
        private static List<Ticket> tickets;

        public TicketController()
        {
            tickets = new List<Ticket>();
        }

        public void SellTicket(Ticket ticket)
        {
            if (screenController.FindScreenById(ticket.Screen.Id) == null)
            {
                Console.WriteLine("Bilet satışı için belirlenen salon bulunamadı.");
                return;
            }
            if (showController.FindShowById(ticket.Show.Id) == null)
            {
                Console.WriteLine("Bilet satışı için belirlenen gösterim bulunamadı.");
                return;
            }
            if (IsSeatNumberExist(FindAllTicketByShowIdAndScreenId(ticket.Show.Id, ticket.Screen.Id),
                ticket.SeatNumber))
            {
                Console.WriteLine(ticket.SeatNumber + " numaralı koltuk seçilen gösterim için dolu.");
                return;
            }
            tickets.Add(ticket);
            Console.WriteLine("Bilet satışı başarıyla tamamlandı.");
        }

        public void DeleteTicket(Ticket ticket)
        {
            for (int i = 0; i < tickets.Count; i++)
            {
                if (ticket.Code.Equals(tickets[i].Code))
                {
                    tickets.RemoveAt(i);
                    Console.WriteLine(ticket.Code + " kodlu bilet silindi.");
                    return;
                }
            }
            Console.WriteLine(ticket.Code + " kodlu bilet bulunamadı.");
        }

        public Ticket FindTicketByCode(string code)
        {
            foreach (var ticketItem in tickets)
            {
                if (code.Equals(ticketItem.Code))
                {
                    return ticketItem;
                }
            }
            Console.WriteLine(code + " kodlu bilet bulunamadı");
            return null;
        }

        public void ShowTickets()
        {
            Console.WriteLine("------------------- Biletler ------------------");
            for (int i = 0; i < tickets.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + tickets[i]);
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public List<Ticket> FindAllTicketByShowId(int showId)
        {
            List<Ticket> ticketsFound = new List<Ticket>();
            foreach (var ticketItem in tickets)
            {
                if (ticketItem.Show.Id == showId)
                {
                    ticketsFound.Add(ticketItem);
                }
            }
            return ticketsFound;
        }

        public List<Ticket> FindAllTicketByScreenId(int screenId)
        {
            List<Ticket> ticketsFound = new List<Ticket>();
            foreach (var ticketItem in tickets)
            {
                if (ticketItem.Screen.Id == screenId)
                {
                    ticketsFound.Add(ticketItem);
                }
            }
            return ticketsFound;
        }

        public List<Ticket> FindAllTicketByShowIdAndScreenId(int showId, int screenId)
        {
            List<Ticket> ticketsFound = new List<Ticket>();
            foreach (var ticketItem in tickets)
            {
                if (ticketItem.Show.Id == showId && ticketItem.Screen.Id == screenId)
                {
                    ticketsFound.Add(ticketItem);
                }
            }
            return ticketsFound;
        }

        public void ShowAllSeatsByShowIdAndScreenId(int showId, int screenId)
        {
            if(showController.FindShowById(showId) == null)
            {
                Console.WriteLine(showId + " idli gösterim bulunamadı!");
                return;
            }
            Screen screenFound = screenController.FindScreenById(screenId);
            if (screenFound == null)
            {
                Console.WriteLine(screenId + " idli salon bulunamadı!");
                return;
            }
            List<Ticket> ticketsFound = FindAllTicketByShowIdAndScreenId(showId,screenId);
            for (int i = 1; i < screenFound.SeatCount+1; i++)
            {
                foreach (var ticketItem in ticketsFound)
                {
                    if(ticketItem.SeatNumber == i)
                    {
                        Console.WriteLine(i + ") Dolu");
                    }
                    continue;
                }
                Console.WriteLine(i + ") Boş");
            }
        }

        public bool IsSeatNumberExist(List<Ticket> ticketForSearch, int seatNumber)
        {
            foreach (var ticketItem in ticketForSearch)
            {
                if(ticketItem.SeatNumber == seatNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
