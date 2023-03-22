using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BreweryManager.Commands
{
    public class AddSaleCommand : IRequest<int>
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
        // FR4 - Add the sale of an existing beer to an existing wholesaler
        public class AddSaleCommandHandler : IRequestHandler<AddSaleCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddSaleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(AddSaleCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var wholesaler = _context.Wholesalers.FirstOrDefault(w => w.Id == request.WholesalerId);

                    if (wholesaler is null)
                        throw new WholesalerNotExistException();

                    var beer = _context.Beers.Include(b => b.Stocks).FirstOrDefault(b => b.Id == request.BeerId && b.Wholesalers.Contains(wholesaler));

                    if (beer is null)
                        throw new BeerNotSoldByWholesalerException();

                    var stock = beer.Stocks.FirstOrDefault(s => s.WholesalerId == request.WholesalerId);

                    if (stock is null)
                        throw new WholeSalerNotHaveStockOfBeerException();

                    if (stock.Quantity < request.Quantity)
                        throw new NotEnoughStockOfBeerException();

                    stock.Quantity -= request.Quantity;

                    await _context.SaveChangesAsync();

                    return stock.Id;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
