using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensjonat.Data
{
    public enum RoomType
       {
           single,doublebed,threebed
       }
    public class Room
    {
        /*public enum RoomType
        {
            single,doublebed,threebed
        }*/
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public bool IfOccupied { get; set; }
        public double Price { get; set; }
        public RoomType Type { get; set; }
        
        public Room()
        {

        }

        public Room(int roomnumber,double price,RoomType type)
        {
            RoomNumber = roomnumber;
            Price = price;
            Type = type;
            RoomID++;
           
        }
        public override string ToString()
        {
            return "Nr pokoju "+RoomNumber + "- cena: " + Price;
        }
    }


}
