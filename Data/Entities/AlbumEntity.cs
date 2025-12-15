using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("albums")]
public class AlbumEntity
{
    public int Id { get; set; }

    [MaxLength(120)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [MaxLength(120)]
    [Required]
    public string Artist { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? List { get; set; }

    public int Position { get; set; }

    [Column("release_date")]
    public DateTime ReleaseDate { get; set; }

    public int Duration { get; set; }

    //enum w bazie jako int
    [Column("music_type")]
    public int MusicType { get; set; }

    [Column("created")]
    public DateTime Created { get; set; }
    public int LabelId { get; set; }
    public LabelEntity? Label { get; set; }
}