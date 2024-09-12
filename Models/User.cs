using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Models;

[Table("users")]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long Id { get; set; }

    [Column("name", TypeName = "varchar(255)")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Column("email", TypeName = "varchar(255)")]
    [Required]
    public string Email { get; set; } = string.Empty;

    [Column("password", TypeName = "varchar(255)")]
    [Required] 
    public string Password { get; set; } = string.Empty;

    [Column("avatar", TypeName = "varchar(255)")]
    [Required]
    public string Avatar { get; set; } = string.Empty;

    [Column("is_admin")]
    [Required]
    public bool Is_admin { get; set; } = false;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime DeletedAt { get; set; }
}