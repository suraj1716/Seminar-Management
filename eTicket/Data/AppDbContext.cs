using eTicket.Models;
using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker_Event>().HasKey(am => new
            {
                am.SpeakerId,
                am.EventId
            });

            modelBuilder.Entity<Speaker_Event>().HasOne(m => m.Event).WithMany(am => am.Speakers_Events).HasForeignKey(m => m.EventId); 
            modelBuilder.Entity<Speaker_Event>().HasOne(m => m.Speaker).WithMany(am => am.Speakers_Events).HasForeignKey(m => m.SpeakerId);




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker_Event> Speakers_Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        
        public DbSet<Coordinator> Coordinators { get; set; }


        //Bookings related tables
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}