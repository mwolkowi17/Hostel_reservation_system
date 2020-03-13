using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensjonat.Data
{
    class ReservationBook
    {
        public List<Room> ReservationOfRooms = new List<Room>();
        public List<Guest> GuestList = new List<Guest>();
    }
}
