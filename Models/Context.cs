using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base()//onconfigu
        {

        }

        public Context(DbContextOptions options ) : base(options)
        {

        }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<RawProductMovments> RawProductMovments { get; set; }
        public DbSet<ProductMovments> ProductMovments { get; set; }
        public DbSet<AssignDeals> AssignDeals { get; set; }
        public DbSet<AssignPackage> AssignPackage { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Chair> Chair { get; set; }
        public DbSet<ChairReserve> chairReserve { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientCart> clientCart { get; set; }  
        public DbSet<Deal> Deal { get; set; }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<Incomming> Incomming { get; set; }
        public DbSet<Loging> Loging { get; set; }
        public DbSet<Outgoing> Outgoing { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RawProduct> RawProduct { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomReserve> RoomReserve { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RawProductMovments>()
                .HasKey(b => new { b.Raw_ProductID, b.OutgoingID });
            modelBuilder.Entity<ProductMovments>()
              .HasKey(b => new { b.ProductID, b.OutgoingID });
            modelBuilder.Entity<Receptionist>()
              .HasKey(b => b.AppId);
            modelBuilder.Entity<CartProducts>()
                .HasKey(b => new { b.Cart_Id, b.ProductId});
            base.OnModelCreating(modelBuilder);
            
        }
      

    }
}
