using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class BeerNotSoldByWholesalerException : BadRequestException
    {
        public BeerNotSoldByWholesalerException() : base("Beer is not sold by the wholesaler")
        {
        }
    }
}
