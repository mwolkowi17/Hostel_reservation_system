namespace Pensjonat.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guests
    {
        [Key]
        public int GuestID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nationality { get; set; }

        public int CreditCardNumber { get; set; }

        public int NrofRoom { get; set; }
    }
}
