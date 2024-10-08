using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Models;

[Table("orders")]
public class Order
{
    [Column("id", TypeName = "bigint")]
    [Key]
    [Required]
    public long? Id { get;set; }

    [Column("user_id", TypeName = "bigint")]
    public long? UserId { get;set; }

    [ForeignKey(nameof(UserId))]
    public virtual User? User { get; set; }

    [Column("total_item_price")]
    public int? TotalItemPrice { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItems>? OrderItems { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; } = null;
}