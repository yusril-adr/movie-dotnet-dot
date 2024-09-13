using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class OrderRepository(IConfiguration configuration, SQLServerContext context, ILogger<OrderRepository> logger)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<OrderRepository> _logger = logger;

  public async Task<Order> Create(Order order) {
    _context.Order.Add(order);
    await _context.SaveChangesAsync();

    return order;
  }
}
