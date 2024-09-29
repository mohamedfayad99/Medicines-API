using EMedicineBE.Models;
using Microsoft.EntityFrameworkCore;

namespace EMedicineBE.DBContext
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options):base(options) { }
        public DbSet<Users> users { get; set; }
        public DbSet<Medicines> medicines { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
        public DbSet<Orders> orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configuring relationships
        //    modelBuilder.Entity<Users>()
        //        .HasMany(u => u.Carts)
        //        .WithOne(c => c.User)
        //        .HasForeignKey(c => c.UserId);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(u => u.Orders)
        //        .WithOne(o => o.User)
        //        .HasForeignKey(o => o.UserId);

        //    modelBuilder.Entity<Medicines>()
        //        .HasMany(u => u.Carts)
        //        .WithOne(c => c.Medicine)
        //        .HasForeignKey(c => c.MedicineId);

        //    modelBuilder.Entity<Medicines>()
        //        .HasMany(u => u.OrdersItems)
        //        .WithOne(o => o.Medicine)
        //        .HasForeignKey(o => o.MedicineId);

        //    modelBuilder.Entity<Orders>()
        //       .HasMany(u => u.orderItems)
        //       .WithOne(o => o.order)
        //       .HasForeignKey(o => o.OrderId);


        //}



    }
}
