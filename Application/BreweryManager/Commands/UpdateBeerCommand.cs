using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.BreweryManager.Commands
{
    public class UpdateBeerCommand : IRequest<int>
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
        // FR5 - A wholesaler can update the remaining quantity of a beer in his stock
        public class UpdateBeerCommandHandler : IRequestHandler<UpdateBeerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateBeerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBeerCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var stock = _context.Stocks.FirstOrDefault(s => s.WholesalerId == command.WholesalerId && s.BeerId == command.BeerId);

                    if (stock == null)
                        throw new StockNotExistForWholeSalerAndBeerException();

                    stock.Quantity = command.Quantity;

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
