using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Result(Operator op, double? a, double? b)
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
    
    public IActionResult Form()
    {
        return View();
    }

    public enum Operator
    {
        Unknown,
        Add,
        Mul,
        Sub,
        Div
    }
}

