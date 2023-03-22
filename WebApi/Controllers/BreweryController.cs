using Application.BreweryManager;
using Application.BreweryManager.Commands;
using Application.BreweryManager.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class BreweryController : BaseApiController
    {

        // FR1 - List all the beers by brewery
        [HttpGet("List")]
        public async Task<IActionResult> GetAllBreweries()
        {
            return Ok(await Mediator.Send(new GetAllBreweriesQuery()));
        }

        // FR2 - A brewer can add new beer
        [HttpPost("AddBeer")]
        public async Task<IActionResult> AddBeer(AddBeerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // FR3 - A brewer can delete a beer
        [HttpDelete("Beers/{beerId}")]
        public async Task<IActionResult> DeleteBeer(int beerId)
        {
            return Ok(await Mediator.Send(new DeleteBeerByIdCommand { Id = beerId }));
        }

        // FR4 - Add the sale of an existing beer to an existing wholesaler
        [HttpPost("Wholesalers/{wholesalerId}/Sales")]
        public async Task<IActionResult> AddSale(int wholesalerId, AddSaleCommand command)
        {
            if (wholesalerId != command.WholesalerId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // FR5 - A wholesaler can update the remaining quantity of a beer in his stock
        [HttpPut("Wholesalers/{wholesalerId}/Stocks/{beerId}")]
        public async Task<IActionResult> UpdateStock(int wholesalerId, int beerId, UpdateBeerCommand command)
        {
            if (wholesalerId != command.WholesalerId && beerId != command.BeerId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // FR6 - A client can request a quote from a wholesaler
        [HttpPost("Wholesalers/{wholesalerId}/Quotes")]
        public async Task<ActionResult<QuoteRequestResponse>> GetQuote(int wholesalerId, RequestQuoteCommand command)
        {
            if (wholesalerId != command.WholesalerId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}
