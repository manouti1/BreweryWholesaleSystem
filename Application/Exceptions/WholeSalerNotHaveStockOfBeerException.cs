using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class WholeSalerNotHaveStockOfBeerException : BadRequestException
    {
        public WholeSalerNotHaveStockOfBeerException() : base("Wholesaler does not have stock of this beer")
        {
        }
    }
}
