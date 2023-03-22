using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class NotEnoughStockOfBeerException : BadRequestException
    {
        public NotEnoughStockOfBeerException() : base("Not enough stock of this bear")
        {
        }
    }
}
