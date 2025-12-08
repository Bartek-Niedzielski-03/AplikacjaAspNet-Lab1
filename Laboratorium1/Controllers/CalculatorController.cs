using Microsoft.AspNetCore.Mvc;
using Laboratorium1.Models;

namespace Laboratorium1.Controllers;

public class CalculatorController : Controller
{
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }

        return View(model);
    }


    public IActionResult Form()
    {
        return View();
    }
}

