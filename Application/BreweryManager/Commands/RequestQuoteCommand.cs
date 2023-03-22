using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BreweryManager.Commands
{
    public class RequestQuoteCommand : IRequest<QuoteRequestResponse>
    {
        public int WholesalerId { get; set; }
        public Dictionary<int, int> Orders { get; set; }
        public class RequestQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, QuoteRequestResponse>
        {
            private readonly IApplicationDbContext _context;
            public RequestQuoteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<QuoteRequestResponse> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.Orders is null || request.Orders.Count == 0)
                        throw new OrderNotEmptyException();

                    var wholesaler = _context.Wholesalers.FirstOrDefault(w => w.Id == request.WholesalerId);

                    if (wholesaler is null)
                        throw new WholesalerNotExistException();

                    var totalQuantity = request.Orders.Values.Sum();

                    if (totalQuantity > wholesaler.Stocks.Sum(s => s.Quantity))
                        throw new OrderQuantityGreaterThanWholesalerStockException();

                    var quoteItems = new List<QuoteItem>();
                    var totalPrice = 0m;

                    foreach (var order in request.Orders)
                    {
                        var beer = _context.Beers.Include(b => b.Stocks).FirstOrDefault(b => b.Id == order.Key && b.Wholesalers.Contains(wholesaler));

                        if (beer is null)
                            throw new BeerNotSoldByWholesalerException();

                        var stock = beer.Stocks.FirstOrDefault(s => s.WholesalerId == request.WholesalerId);

                        if (stock is null)
                            throw new StockNotExistForWholeSalerAndBeerException();

                        if (stock.Quantity < order.Value)
                            throw new NotEnoughStockOfBeerException();

                        quoteItems.Add(new QuoteItem { Beer = beer, Quantity = order.Value });

                        var itemPrice = beer.Price * order.Value;

                        if (order.Value > 10 && order.Value <= 20)
                            itemPrice *= 0.9m;
                        else if (order.Value > 20)
                            itemPrice *= 0.8m;

                        totalPrice += itemPrice;
                    }

                    var quoteResponse = new QuoteRequestResponse
                    {
                        TotalPrice = totalPrice,
                        Items = quoteItems
                    };

                    return quoteResponse;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
