using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers;

public class BirthController : Controller
{
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm] Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }

        return View(model);
    }
}