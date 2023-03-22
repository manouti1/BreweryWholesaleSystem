using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BreweryManager.Commands
{
    public class AddBeerCommand : IRequest<int>
    {
        public int BreweryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // FR2 - A brewer can add new beer
        public class AddBeerCommandHandler : IRequestHandler<AddBeerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddBeerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddBeerCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var brewery = _context.Breweries.FirstOrDefault(b => b.Id == command.BreweryId);

                    if (brewery is null)
                        throw new BreweryNotExistException();

                    var beer = new Beer();
                    beer.Name = command.Name;
                    beer.Description = command.Description;
                    beer.Price = command.Price;
                    beer.BreweryId = command.BreweryId;
                    _context.Beers.Add(beer);
                    await _context.SaveChangesAsync();
                    return beer.Id;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
