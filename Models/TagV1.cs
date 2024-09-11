using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("Tags")]
public class TagV1
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [Column("name", TypeName = "varchar(255)")]
    [Required]
    public string? Name { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;

    [InverseProperty("Tag")]
    public virtual ICollection<MovieTagsV1> MovieTag { get; } = [];
}