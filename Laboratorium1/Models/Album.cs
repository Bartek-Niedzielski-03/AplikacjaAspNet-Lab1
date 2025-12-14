using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Models;

public class Album
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Proszę podać tytuł albumu")]
    [StringLength(120, MinimumLength = 1)]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Proszę podać wykonawcę")]
    [StringLength(120, MinimumLength = 1)]
    [Display(Name = "Artist")]
    public string Artist { get; set; }

    [Display(Name = "Track list")]
    public string List { get; set; }

    [Range(1, 100)]
    [Display(Name = "Position")]
    public int Position { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Release date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Range(1, 1000)]
    [Display(Name = "Duration")]
    public int Duration { get; set; }

    [Display(Name = "Music type")]
    public MusicType MusicType { get; set; }

    [HiddenInput]
    [Display(Name = "Created")]
    public DateTime Created { get; set; }
}