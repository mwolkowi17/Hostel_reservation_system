using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensjonat.Data
{
    public class AdditionalMethods
    {
        public ReservationBook newBook = new ReservationBook();

        public List<Room> DisplayRooms()
        {
            return newBook.RoomList;
        }

        public List<Guest> DisplayGuests()
        {
            return newBook.GuestList;
        }

        public List<Room> AddRooms(RoomType type)
        {
            Room NewRoom = new Room(type);
            NewRoom.RoomID=newBook.RoomList.Count+1;
            NewRoom.RoomNumber=newBook.RoomList.Count+1;
            NewRoom.Price = 100;
            NewRoom.IfOccupied = false;
            newBook.RoomList.Add(NewRoom);
            return newBook.RoomList;
        }
        public List<Guest> AddGuest(string name, string surname, string nationality)
        {
            Guest NewGuest = new Guest(name, surname, nationality);
            NewGuest.GuestID=newBook.GuestList.Count+1;
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

        public List<Guest> AddReservation(int id, RoomType kindOfRomm)
        {
            Guest GuestWantingToMakeReservation = (from Guest item in newBook.GuestList
                                                   where item.GuestID == id
                                                   select item).First();
            Room RoomToRent = (from Room item in newBook.RoomList
                               where item.Type == kindOfRomm
                               select item).First();

            GuestWantingToMakeReservation.NrofRoom = RoomToRent.RoomNumber;
            RoomToRent.IfOccupied = true;

            return newBook.GuestList;
        }

        public List<Guest>CancelReservation( int id)
        {
            Guest GuestWantingCancelReservation = (from Guest item in newBook.GuestList
                                                   where item.GuestID == id
                                                   select item).First();

            Room RoomToCancel = (from Room item in newBook.RoomList
                                 where item.RoomNumber == GuestWantingCancelReservation.NrofRoom
                                 select item).First();

            GuestWantingCancelReservation.NrofRoom = 0;
            RoomToCancel.IfOccupied = false;

            return newBook.GuestList;
        }
    }
}
