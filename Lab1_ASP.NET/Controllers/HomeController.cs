using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1_ASP.NET.Models;

namespace Lab1_ASP.NET.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public IActionResult About()
    {
        return View();
    }

    // Zdefiniuj metodę z widokiem Calculator,
    // dodaj link do nwaigacji do tej metody
    // dodaj do kalkulatora:
    // operator pow, który podniesie liczbe x do potegi y
    // funkcje sin, ktora olibcza sin(x), a y jest zbedne
    // 

    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        // string operate = Request.Query["op"];
        // int x = int.Parse(Request.Query["x"]);
        // int y = int.Parse(Request.Query["y"]);


        if (op == null)
        {
            ViewBag.ErrorMessage = "You need to specify operator with keyword op";
            return View("CalculatorError");
        }
        if(x is null || (y is null && op.Value != Operator.Sin))
        {
            ViewBag.ErrorMessage = "x or y is missing or in wrong format";
            return View("CalculatorError");
        }
            double? result = 0;

            switch(op)
            {
                case Operator.Add:
                    result = x + y;
                    break;
                case Operator.Sub:
                    result = x - y;
                    break;
                case Operator.Mul:
                    result = x * y;
                    break;
                case Operator.Div:
                    if(y == 0)
                    {
                        ViewBag.ErrorMessage = "You cannot divide by 0!";
                        return View("CalculatorError");
                    }
                    result = x / y;
                    break;
                case Operator.Pow:
                    result = Math.Pow(x.Value,y.Value);
                    break;
                case Operator.Sin:
                    result = Math.Sin(x.Value * Math.PI / 180);
                    result = (double)Math.Round((decimal)result * 1000000) / 1000000;
                    break;
                                        
            }

            ViewBag.Result = result;


        return View();
    }
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div, Pow, Sin
}