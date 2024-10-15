using Microsoft.AspNetCore.Mvc;

namespace MoreAdvancedCalculator.Controllers;

public class BirthController : Controller {

    public IActionResult Form() {
        return View();
    }

    [HttpPost]
    public IActionResult Result(Birth model) {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
}