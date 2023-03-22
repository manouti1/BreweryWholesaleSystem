using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class WholesalerNotExistException : NotFoundException
    {
        public WholesalerNotExistException()
       : base($"Wholesaler does not exist")
        {
        }
    }
}
