using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("movie_schedules")]
public class MovieSchedule
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [Column("movie_id", TypeName = "bigint")]
    public long? MovieId { get;set; }

    [ForeignKey(nameof(MovieId))]
    public virtual Movie? Movie { get; set; }

    [Column("studio_id", TypeName = "bigint")]
    public long? StudioId { get;set; }

    [ForeignKey(nameof(StudioId))]
    public virtual Studio? Studio { get; set; }

    [Column("remaining_Seat")]
    public int? RemainingSeat { get; set; }

    [Column("start_time", TypeName = "VARCHAR(255)")]
    public required string StartTime { get; set; }

    [Column("end_time", TypeName = "VARCHAR(255)")]
    public required string EndTime { get; set; }

    [Column("price")]
    public int Price { get; set; }

    [Column("date")]
    public required DateOnly Date { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}