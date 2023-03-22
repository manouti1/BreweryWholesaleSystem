using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Stock : BaseEntity
    {
        public int BeerId { get; set; }
        public int WholesalerId { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public virtual Beer Beer { get; set; }
        public virtual Wholesaler Wholesaler { get; set; }
    }
}
