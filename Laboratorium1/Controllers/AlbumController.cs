using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;

namespace Laboratorium1.Controllers;

public class AlbumController : Controller
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        var all = _albumService.GetAlbums();

        int totalItems = all.Count;
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        
        if (totalPages < 1) totalPages = 1;
        page = Math.Max(1, Math.Min(page, totalPages));

        var items = all
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.Page = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = totalPages;

        return View(items);
    }


    [HttpGet]
    public IActionResult Create()
    {
        var model = new Album();
        model.ReleaseDate = DateTime.Today;
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

        album.Labels = _albumService
            .FindAllLabels()
            .Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Title
            })
            .ToList();

        return View(album);
    }
    [HttpPost]
    public IActionResult Edit(Album album)
    {
        if (!ModelState.IsValid)
        {
            album.Labels = _albumService
                .FindAllLabels()
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Title
                })
                .ToList();

            return View(album);
        }

        _albumService.UpdateAlbum(album);
        return RedirectToAction("Index");
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
