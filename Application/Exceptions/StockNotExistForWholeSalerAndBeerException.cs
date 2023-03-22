using Application.Exceptions.Generic;

namespace Application.Exceptions
{
    public sealed class StockNotExistForWholeSalerAndBeerException : BadRequestException
    {
        public StockNotExistForWholeSalerAndBeerException() : base("Stock does not exist for this wholesaler and beer")
        {
        }
    }
}
