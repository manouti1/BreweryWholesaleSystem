using Domain.Common;

namespace Domain.Entities
{
    public class Wholesaler : BaseEntity
    {
        public string Name { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
