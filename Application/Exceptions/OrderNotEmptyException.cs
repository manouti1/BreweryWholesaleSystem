using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class OrderNotEmptyException : NotFoundException
    {
        public OrderNotEmptyException() : base("Order cannot be empty")
        {
        }
    }
}
