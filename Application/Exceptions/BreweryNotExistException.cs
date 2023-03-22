using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class BreweryNotExistException : NotFoundException
    {
        public BreweryNotExistException() : base("Brewery does not exist")
        {
        }
    }
}
