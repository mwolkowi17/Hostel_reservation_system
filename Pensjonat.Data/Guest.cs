using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensjonat.Data
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public int CreditCardNumber { get; set; }
        public int NrofRoom { get; set; }

        public Guest()
        {

        }

        public Guest(string name, string surname, string nationality)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
        }

        public override string ToString()
        {
            return Name + " " + Surname + "Nr of the room" + NrofRoom;
        }

        public Queue<Room> reservationHistory = new Queue<Room>();
    }
}