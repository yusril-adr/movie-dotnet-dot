using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("movie_tags")]
public class MovieTags
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [ForeignKey("movie_id")]
    public virtual Movie? Movie { get; set; }

    [ForeignKey("tag_id")]
    public virtual Tag? Tag { get; set; }


    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}