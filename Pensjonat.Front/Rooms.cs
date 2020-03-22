namespace Pensjonat.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rooms
    {
        [Key]
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        public bool IfOccupied { get; set; }

        public double Price { get; set; }

        public int Type { get; set; }
    }
}
