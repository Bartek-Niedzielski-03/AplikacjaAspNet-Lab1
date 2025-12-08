using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laboratorium1.Models;

namespace Laboratorium1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

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
    
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Calculator(Operator op, double? a, double? b)
    {
        ViewBag.Op = op;
        ViewBag.A = a;
        ViewBag.B = b;

        double? result = null;
        string error = null;

        if (a == null || b == null)
        {
            error = "Brak wartości a lub b.";
        }
        else if (op == Operator.Unknown)
        {
            error = "Nieznany operator.";
        }
        else
        {
            switch (op)
            {
                case Operator.Add:
                    result = a + b;
                    break;
                case Operator.Sub:
                    result = a - b;
                    break;
                case Operator.Mul:
                    result = a * b;
                    break;
                case Operator.Div:
                    if (b == 0)
                        error = "Dzielenie przez zero.";
                    else
                        result = a / b;
                    break;
            }
        }

        ViewBag.Result = result;
        ViewBag.Error = error;

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
    Unknown, Add, Mul, Sub, Div
}