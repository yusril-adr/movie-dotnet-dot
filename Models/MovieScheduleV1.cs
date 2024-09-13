using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("Movie_Schedules")]
public class MovieScheduleV1
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    [JsonProperty("id")]
    public long? Id { get;set; }

    [ForeignKey("movie_id")]
    public virtual MovieV1? Movie { get; set; }

    [ForeignKey("studio_id")]
    public virtual StudioV1? Studio { get; set; }

    [Column("remaining_Seat")]
    public int? RemainingSeat { get; set; }

    [Column("start_time", TypeName = "VARCHAR(255)")]
    public required string StartTime { get; set; }

    [Column("end_time", TypeName = "VARCHAR(255)")]
    public required string EndTime { get; set; }

    [Column("price")]
    public int Price { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}