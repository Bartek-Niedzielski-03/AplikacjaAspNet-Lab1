using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Models;

public class Album
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Proszę podać tytuł albumu")]
    [StringLength(120, MinimumLength = 1, ErrorMessage = "Tytuł musi mieć od 1 do 120 znaków")]
    [Display(Name ="Tytuł albumu")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Proszę podać wykonawcę")]
    [StringLength(120, MinimumLength = 1, ErrorMessage = "Nazwa wykonawcy musi mieć od 1 do 120 znaków")]
    public string Artist { get; set; }
    
    [Required(ErrorMessage = "Proszę podać spis utworów")]
    [MinLength(5, ErrorMessage = "Spis utworów musi mieć co najmniej 5 znaków")]
    public string List { get; set; }
    
    [Range(1, 100, ErrorMessage = "Pozycja w notowaniu musi być między 1 a 100")]
    public int Position { get; set; }
    
    [Required(ErrorMessage = "Proszę podać datę wydania")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate  { get; set; }
    
    [Required(ErrorMessage = "Proszę podać czas trwania w minutach")]
    [Range(1, 1000, ErrorMessage = "Czas musi być dodatni")]
    public int Duration { get; set; }
}