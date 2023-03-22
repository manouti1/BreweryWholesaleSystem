using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BreweryManager.Queries
{
    public class GetAllBreweriesQuery : IRequest<IEnumerable<Brewery>>
    {
        // FR1 - List all the beers by brewery
        public class GetAllBreweriesQueryHandler : IRequestHandler<GetAllBreweriesQuery, IEnumerable<Brewery>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBreweriesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Brewery>> Handle(GetAllBreweriesQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var breweryList = await _context.Breweries.Include(b => b.Beers).ToListAsync();
                    if (breweryList == null)
                    {
                        return null;
                    }
                    return breweryList.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
