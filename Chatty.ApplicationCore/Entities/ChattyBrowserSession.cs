using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chatty.ApplicationCore.Interfaces.Marker;

namespace Chatty.ApplicationCore.Entities;

public class ChattyBrowserSession : ISoftDeletable
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("session_uuid")]
    public string SessionUuid { get; set; } = null!;

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("created_at_gmt")]
    public DateTime CreatedAtGmt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Required]
    [Column("updated_at_gmt")]
    public DateTime UpdatedAtGmt { get; set; }

    [Required]
    [Column("deleted")]
    public bool Deleted { get; set; }
}