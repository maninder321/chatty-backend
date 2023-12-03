using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chatty.ApplicationCore.Entities;

public class ChattySessionQrCode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("chatty_browser_session_id")]
    public int ChattyBrowserSessionId { get; set; }

    [Required]
    [Column("qr_code_identifier")]
    public string QrCodeIdentifier { get; set; } = null!;

    [Required]
    [Column("qr_code_image_path")]
    public string QrCodeImagePath { get; set; } = null!;

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
    [Column("expire_at")]
    public DateTime ExpireAt { get; set; }

    [Required]
    [Column("expire_at_gmt")]
    public DateTime ExpireAtGmt { get; set; }

    [Required]
    [Column("deleted")]
    public int Deleted { get; set; }

}