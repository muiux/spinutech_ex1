using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spinutech_assessment.Models;
using Spinutech_assessment.Services;

namespace Spinutech_assessment.Controllers
{
    public class AmountController : Controller
    {
        private readonly AmountConverterService _amountConverterService;
        private readonly ILogger<AmountController> _logger;

        public AmountController(ILogger<AmountController> logger)
        {
            _logger = logger;
            _amountConverterService = new AmountConverterService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AmountModel model)
        {
            if (ModelState.IsValid)
            {
                model.ConvertedAmount = _amountConverterService.ConvertAmountToWords(model.Amount);
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
            return View(model);
        }
    }
}
