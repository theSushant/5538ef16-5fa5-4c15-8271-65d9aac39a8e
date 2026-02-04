using Microsoft.AspNetCore.Mvc;

namespace LISWebApp.Controllers
{
    public class LisController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                return BadRequest($"Fail to load the UI. Error: {e.Message}");
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

                var numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToList();

                var filtered = numbers.Where(x => x % 2 == 0).ToList();
                var resultString = string.Join(" ", filtered);

                return Json(new { result = resultString });
            }
            catch(Exception e)
            {
                return BadRequest($"Fail to load the UI. Error: {e.Message}");
            }
        }
    }
}
