using LISWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LISWebApp.Controllers
{
    public class LisController : Controller
    {
        readonly ILisService _lisService;
        public LisController(ILisService lisService)
        {
            _lisService = lisService ?? throw new ArgumentException(nameof(lisService));
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest($"Fail to load the UI. Error: {ex.Message}");
            }
        }

        public IActionResult Compute(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return Json(new { result = string.Empty });
                }

                List<int> numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToList();

                var result = _lisService.GetLis(numbers);
                string resultString = string.Join(" ", result);

                //var filtered = numbers.Where(x => x % 2 == 0).ToList();
                //var resultString = string.Join(" ", filtered);
                //var finalResult = resultString.Replace(',', ' ');

                return Json(new { result = resultString });
            }
            catch(Exception e)
            {
                return BadRequest($"Fail to load the UI. Error: {e.Message}");
            }
        }
    }
}
