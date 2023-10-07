using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ApplicationCore.Entities;

public class ChattyUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Required]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("password")]
    public string Password { get; set; }

    [Required]
    [Column("mobile_number")]
    public string MobileNumber { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("created_at_gmt")]
    public DateTime CreatedAtGmt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set;}

    [Required]
    [Column("updated_at_gmt")]
    public DateTime UpdatedAtGmt { get; set;}

    [Required]
    [Column("deleted")]
    public int Deleted {  get; set; }

}
