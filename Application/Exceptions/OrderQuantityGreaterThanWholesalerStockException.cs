using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class OrderQuantityGreaterThanWholesalerStockException : BadRequestException
    {
        public OrderQuantityGreaterThanWholesalerStockException() : base("Order quantity is greater than the wholesaler's stock")
        {
        }
    }
}
