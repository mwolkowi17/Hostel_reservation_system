namespace Pensjonat.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}
