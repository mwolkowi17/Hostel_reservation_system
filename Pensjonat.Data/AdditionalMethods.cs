using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensjonat.Data
{
    class AdditionalMethods
    {
        public ReservationBook newBook = new ReservationBook();

        public List<Room> DisplayRooms()
        {
            return newBook.ReservationOfRooms;
        }

        public List<Guest> DisplayGuests()
        {
            return newBook.GuestList;
        }

        public List<Guest> AddGuest(string name, string surname, string nationality)
        {
            Guest NewGuest = new Guest(name, surname, nationality);
            newBook.GuestList.Add(NewGuest);
            return newBook.GuestList;
        }

        public List<Guest> RemoveGuest(int id)
        {
            Guest RemoveFromListGuest = (from Guest item in newBook.GuestList
                                         where item.GuestID == id
                                         select item).First();

            newBook.GuestList.Remove(RemoveFromListGuest);
            return newBook.GuestList;
        }
    }
}
