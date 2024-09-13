using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("studios")]
public class Studio
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    [JsonProperty("id")]
    public long? Id { get;set; }

    [Column("studio_number")]
    [Required]
    [JsonProperty("studio_number")]
    public int StudioNumber { get; set; }

    [Column("seat_capacity")]
    [Required]
    [JsonProperty("seat_capacity")]
    public int SeatCapacity { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}