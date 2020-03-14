using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pensjonat.Data;

namespace Pensjonat.Data.Test
{
    [TestClass]
    public class PensjontDataTest
    {
        [TestMethod]
        public void TestNowyPensjonat()
        {
            AdditionalMethods model = new AdditionalMethods();
            Assert.AreEqual(0, model.DisplayGuests().Count);
            Assert.AreEqual(0, model.DisplayRooms().Count);
        }

        [TestMethod]
        public void TestAddGuest()
        {
            AdditionalMethods model = new AdditionalMethods();
            model.AddGuest("Łucja", "Wołkowicz", "Polish");
            Assert.AreEqual(1, model.DisplayGuests().Count);
            Assert.AreEqual(0, model.DisplayRooms().Count);
            
        }

        [TestMethod]
        public void TestRemoveGuest()
        {
            AdditionalMethods model = new AdditionalMethods();
            model.AddGuest("Łucja", "Wołkowicz", "Polish");
            model.RemoveGuest(1);
            Assert.AreEqual(0, model.DisplayGuests().Count);
            Assert.AreEqual(0, model.DisplayRooms().Count);
        }

        [TestMethod]
        public void TestReservation()
        {
            AdditionalMethods model = new AdditionalMethods();
            model.AddGuest("Łucja", "Wołkowicz", "Polish");
            model.DisplayRooms().Add(new Room(1,200,RoomType.doublebed));
            model.AddReservation(1, RoomType.doublebed);
            Assert.AreEqual(1, model.DisplayGuests()[0].NrofRoom);
            
        }

        [TestMethod]
        public void TestCancelReservation()
        {
            AdditionalMethods model = new AdditionalMethods();
            model.AddGuest("Łucja", "Wołkowicz", "Polish");
            model.DisplayRooms().Add(new Room(1, 200, RoomType.doublebed));
            model.AddReservation(1, RoomType.doublebed);
            model.CancelReservation(1);
            Assert.AreEqual(0, model.DisplayGuests()[0].NrofRoom);
            Assert.IsFalse(model.DisplayRooms()[0].IfOccupied);
        }

        

    }
}
