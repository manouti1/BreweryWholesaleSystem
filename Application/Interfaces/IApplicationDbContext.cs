using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Brewery> Breweries { get; set; }
        DbSet<Beer> Beers { get; set; }
        DbSet<Wholesaler> Wholesalers { get; set; }
        DbSet<Stock> Stocks { get; set; }
        Task<int> SaveChangesAsync();
    }
}
