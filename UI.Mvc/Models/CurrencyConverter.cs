using Infrastructure.ServiceManager.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Mvc.Models
{

    [ViewComponent(Name = "CurrencyConverter")]
    public class CurrencyConverter : ViewComponent
    {
        private readonly IMarketManager _marketManager;

        public CurrencyConverter(IMarketManager marketManager)
        {
            _marketManager = marketManager;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Markets =  _marketManager.GetAllMarketsForCurrencyConverter();
            return View();
        }
    }
}
