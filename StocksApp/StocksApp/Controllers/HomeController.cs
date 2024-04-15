using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;


        public HomeController(FinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubService = finnhubService;
            _tradingOptions = tradingOptions;
        }


        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object> responseDictionary = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            Stock stock = new()
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString(), CultureInfo.InvariantCulture),
                HighestPrice = Convert.ToDouble(responseDictionary["h"].ToString(), CultureInfo.InvariantCulture),
                LowestPrie = Convert.ToDouble(responseDictionary["l"].ToString(), CultureInfo.InvariantCulture),
                OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString(), CultureInfo.InvariantCulture)
            };

            return View(stock);
        }
    }
}

