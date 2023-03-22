using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
            .HasOne(b => b.Brewery)
            .WithMany(bw => bw.Beers)
            .HasForeignKey(b => b.BreweryId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Beer)
                .WithMany(b => b.Stocks)
                .HasForeignKey(s => s.BeerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Wholesaler)
                .WithMany(w => w.Stocks)
                .HasForeignKey(s => s.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewery>().HasData(
                       new Brewery { Id = 1, Name = "Brewer 1", Location = "X" },
                       new Brewery { Id = 2, Name = "Brewer 2", Location = "Y" });


            modelBuilder.Entity<Beer>().HasData(
                new Beer { Id = 1, Name = "Beer 1", Description = "Description 1", Price = 4.50m, BreweryId = 1 },
                new Beer { Id = 2, Name = "Beer 2", Description = "Description 2", Price = 5.00m, BreweryId = 1 },
                new Beer { Id = 3, Name = "Beer 3", Description = "Description 3", Price = 4.00m, BreweryId = 2 },
                new Beer { Id = 4, Name = "Beer 4", Description = "Description 4", Price = 5.50m, BreweryId = 2 });

            modelBuilder.Entity<Wholesaler>().HasData(
                new Wholesaler { Id = 1, Name = "Wholesaler 1" },
                new Wholesaler { Id = 2, Name = "Wholesaler 2" });

            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, WholesalerId = 1, BeerId = 1, Quantity = 2, Price = 100.0m },
                new Stock { Id = 2, WholesalerId = 1, BeerId = 2, Quantity = 1, Price = 10.0m },
                new Stock { Id = 3, WholesalerId = 2, BeerId = 3, Quantity = 3, Price = 20.0m },
                new Stock { Id = 4, WholesalerId = 2, BeerId = 4, Quantity = 1, Price = 4.50m });

        }

        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}