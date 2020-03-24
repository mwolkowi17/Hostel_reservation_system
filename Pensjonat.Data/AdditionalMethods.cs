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
            using (Model1 context = new Model1())
            {
                newBook.RoomList = context.Rooms.ToList();
            }
            return newBook.RoomList;
        }

        public List<Guest> DisplayGuests()
        {
            using (Model1 context = new Model1())
            {
                newBook.GuestList = context.Guests.ToList();
            }
            return newBook.GuestList;
        }

        public List<Room> AddRooms(RoomType type)
        {
            Room NewRoom = new Room(type);
            NewRoom.RoomID = newBook.RoomList.Count + 1;
            NewRoom.RoomNumber = newBook.RoomList.Count + 1;
            NewRoom.Price = 100;
            NewRoom.IfOccupied = false;
            newBook.RoomList.Add(NewRoom);
            return newBook.RoomList;
        }
        public List<Guest> AddGuest(string name, string surname, string nationality)
        {
            using (Model1 context = new Model1()) { 
                Guest NewGuest = new Guest(name, surname, nationality);
                NewGuest.GuestID = newBook.GuestList.Count + 1;
                context.Guests.Add(NewGuest);//newBook.GuestList.Add(NewGuest);
                context.SaveChanges();
                return context.Guests.ToList();//newBook.GuestList;
            }
        }

        public List<Guest> RemoveGuest(int id)
        {
            Guest RemoveFromListGuest = (from Guest item in newBook.GuestList
                                         where item.GuestID == id
                                         select item).First();

            newBook.GuestList.Remove(RemoveFromListGuest);
            return newBook.GuestList;
        }

        public List<Guest> AddReservation(int id)
        {
            using (Model1 context = new Model1())
            {
                List<Room> robocza = (from Room item in context.Rooms.ToList()//newBook.RoomList
                                      where item.IfOccupied == false
                                      select item).ToList();
                if (robocza.Count > 0)
                {
                    Guest GuestWantingToMakeReservation = (from Guest item in context.Guests.ToList()//newBook.GuestList
                                                           where item.GuestID == id
                                                           select item).First();
                    Room RoomToRent = (from Room item in context.Rooms.ToList()//newBook.RoomList
                                       where item.IfOccupied == false
                                       select item).First();
                    if (GuestWantingToMakeReservation.NrofRoom == 0)
                    {
                        GuestWantingToMakeReservation.NrofRoom = RoomToRent.RoomNumber;
                        RoomToRent.IfOccupied = true;
                    }
                    context.SaveChanges();
                    return context.Guests.ToList();//newBook.GuestList;

                }
                else
                {
                    return null;
                }
            }
        }

        public List<Guest> CancelReservation(int id)
        {
            using (Model1 context = new Model1())
            {
                Guest GuestWantingCancelReservation = (from Guest item in context.Guests.ToList()//newBook.GuestList
                                                       where item.GuestID == id
                                                       select item).First();

                Room RoomToCancel = (from Room item in context.Rooms.ToList()//newBook.RoomList
                                     where item.RoomNumber == GuestWantingCancelReservation.NrofRoom
                                     select item).First();

                GuestWantingCancelReservation.NrofRoom = 0;
                RoomToCancel.IfOccupied = false;
                context.SaveChanges();
                return newBook.GuestList;
            }
        }
    }
}
