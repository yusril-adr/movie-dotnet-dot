using System.ComponentModel.DataAnnotations.Schema;

namespace dot_dotnet_test_api.Models;

[Table("TodoItems")]
public class TodoItemV1
{
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("is_complete")]
    public bool IsComplete { get; set; }
}