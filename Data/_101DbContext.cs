using _101.API.Models;
using Microsoft.EntityFrameworkCore;
//using WebApi.Entities;

namespace _101.API.Data
{
    
    
    public class _101DbContext : DbContext
    {
        public _101DbContext(DbContextOptions<_101DbContext> options) : base(options) { } //constructor
        
        //agrego para usar PG
         //protected override void OnConfiguring(DbContextOptionsBuilder options)
         //  {
            // connect to postgres with connection string from app settings
         //   options.UseNpgsql();
         //  }


        public DbSet<Pilots> Pilots { get; set; } // tiene q llamarse igual que la DB
        public DbSet<Planes> Planes { get; set; }
        public DbSet<Reservations> Reservations { get; set; }

       
    }
}

