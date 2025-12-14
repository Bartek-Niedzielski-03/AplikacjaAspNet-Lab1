using System.ComponentModel.DataAnnotations;

public enum MusicType
{
    [Display(Name = "Rock")]
    Rock = 1,

    [Display(Name = "Pop")]
    Pop = 2,

    [Display(Name = "Hip-Hop")]
    HipHop = 3,

    [Display(Name = "Electronic")]
    Electronic = 4
}