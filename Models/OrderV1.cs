using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("Orders")]
public class OrderV1
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [ForeignKey("user_id")]
    public virtual UserV1? User { get; set; }

    [Column("total_item_price")]
    public int? TotalItemPrice { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItemsV1>? OrderItems { get; set; }


    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}