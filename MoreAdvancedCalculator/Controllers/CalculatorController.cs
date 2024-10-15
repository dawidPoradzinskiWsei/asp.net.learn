using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoreAdvancedCalculator.Models;

namespace MoreAdvancedCalculator.Controllers;

public class CalculatorController : Controller
{

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
    if (!model.IsValid())
    {
        return View("Error");
    }
    return View(model);
    }

    public enum Operator
    {
        Add,Sub,Mul,Div,Pow,Sin
    }
}
