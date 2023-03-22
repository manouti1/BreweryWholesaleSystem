using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.BreweryManager.Commands
{
    public class DeleteBeerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        // FR3 - A brewer can delete a beer
        public class DeleteBeerByIdCommandHandler : IRequestHandler<DeleteBeerByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteBeerByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBeerByIdCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var beer = _context.Beers.FirstOrDefault(b => b.Id == command.Id);

                    if (beer is null)
                        throw new BreweryNotExistException();

                    _context.Beers.Remove(beer);
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
