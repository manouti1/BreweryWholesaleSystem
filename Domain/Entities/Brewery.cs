using Domain.Common;

namespace Domain.Entities
{
    public class Brewery : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Beer> Beers { get; set; }
    }
}
