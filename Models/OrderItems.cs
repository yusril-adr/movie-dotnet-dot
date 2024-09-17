using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("order_items")]
public class OrderItems
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [Column("order_id", TypeName = "bigint")]
    public long? OrderId { get;set; }

    [ForeignKey(nameof(OrderId))]
    public virtual Order? Order { get; set; }

    [Column("movie_schedule_id", TypeName = "bigint")]
    public long? MovieScheduleId { get;set; }

    [ForeignKey(nameof(MovieScheduleId))]
    public virtual MovieSchedule? MovieSchedule { get; set; }

    [Column("qty")]
    public int? Qty { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    [Column("sub_total_price")]
    public int? SubTotalPrice { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}