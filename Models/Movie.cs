using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("movies")]
public class Movie
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long? Id { get;set; }

    [Column("title", TypeName = "varchar(255)")]
    [Required]
    public string? Title { get; set; }

    [Column("overview", TypeName = "NVARCHAR(MAX)")]
    [Required]
    public string? Overview { get; set; }

    [Column("poster", TypeName = "varchar(255)")]
    [Required]
    public string? Poster { get; set; }

    [Column("play_until")]
    [JsonProperty("play_until")]
    public DateTime? PlayUntil { get; set; } = DateTime.Now;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;

    [InverseProperty("Movie")]
    public virtual ICollection<MovieTags>? MovieTags { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<MovieSchedule>? MovieSchedules { get; set; }
}