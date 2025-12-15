using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("labels")]
public class LabelEntity
{
    public int Id { get; set; }

    [MaxLength(120)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Nip { get; set; }

    [MaxLength(20)]
    public string? Regon { get; set; }

    public Address? Address { get; set; }

    public ISet<AlbumEntity> Albums { get; set; } = new HashSet<AlbumEntity>();
}