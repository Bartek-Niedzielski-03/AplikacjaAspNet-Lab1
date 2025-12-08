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
    public string Title { get; set; }

    [Required(ErrorMessage = "Proszę podać wykonawcę")]
    [StringLength(120, MinimumLength = 1)]
    public string Artist { get; set; }
    
    public string List { get; set; }

    [Range(1, 100)]
    public int Position { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Range(1, 1000)]
    public int Duration { get; set; }

}
