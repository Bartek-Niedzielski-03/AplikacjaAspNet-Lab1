using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers;

public class AlbumController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Create(Album album)
    {
        if (ModelState.IsValid)
        {

            return View();
        }
        else
        {
            return View(album);
        }
    }
}