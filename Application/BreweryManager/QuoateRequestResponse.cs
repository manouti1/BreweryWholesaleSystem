namespace Application.BreweryManager
{
    public class QuoteRequestResponse
    {
        public decimal TotalPrice { get; set; }
        public List<QuoteItem> Items { get; set; }
    }
}
