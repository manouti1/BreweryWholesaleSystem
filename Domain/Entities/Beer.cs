using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Beer : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BreweryId { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public virtual Brewery Brewery { get; set; }
        public virtual ICollection<Wholesaler> Wholesalers { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }

    }
}
