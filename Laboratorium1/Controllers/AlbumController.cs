using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Laboratorium1.Controllers;

public class AlbumController : Controller
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public IActionResult Index()
    {
        return View(_albumService.GetAlbums());
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new Album();
        FillLabels(model);
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Album album)
    {
        if (ModelState.IsValid)
        {
            _albumService.AddAlbum(album);
            return RedirectToAction("Index");
        }

        FillLabels(album);
        return View(album);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var album = _albumService.GetAlbumById(id);
        if (album == null) return NotFound();
        return View(album);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var album = _albumService.GetAlbumById(id);
        if (album == null) return NotFound();

        FillLabels(album);
        return View(album);
    }

    [HttpPost]
    public IActionResult Edit(Album album)
    {
        if (!ModelState.IsValid)
        {
            FillLabels(album);
            return View(album);
        }

        if (_albumService.UpdateAlbum(album))
            return RedirectToAction("Index");

        return NotFound();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var album = _albumService.GetAlbumById(id);
        if (album == null) return NotFound();
        return View(album);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        if (_albumService.DeleteAlbumById(id))
            return RedirectToAction("Index");

        return NotFound();
    }

    private void FillLabels(Album model)
    {
        model.Labels = _albumService
            .FindAllLabels()
            .Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Title
            })
            .ToList();
    }
}
