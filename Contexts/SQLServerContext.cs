using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;

namespace dot_dotnet_test_api.Contexts;

public class SQLServerContext : DbContext
{
    public SQLServerContext(DbContextOptions<SQLServerContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItemV1> TodoItems { get; set; } = null!;
    public DbSet<UserV1> Users { get; set; } = null!;
}