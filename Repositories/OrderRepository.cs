using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class OrderIncome
{
  public int Income { get; set; }
  public DateOnly Date { get; set; }
}

public class OrderRepository(IConfiguration configuration, SQLServerContext context, ILogger<OrderRepository> logger)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<OrderRepository> _logger = logger;

  public async Task<Order> Create(Order order)
  {
    _context.Order.Add(order);
    await _context.SaveChangesAsync();

    return order;
  }

  private IEnumerable<OrderIncome> QueryOrderIncomePerDate(DateOnly startDate, DateOnly endDate)
  {
    var allDates = Enumerable.Range(
      0, (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days + 1
    )
    .Select(day => startDate.AddDays(day))
    .ToList();

    var query = from date in allDates
                join order in _context.Order
                    on date equals DateOnly.FromDateTime((DateTime)order.CreatedAt!) into orderGroup
                from order in orderGroup.DefaultIfEmpty() // Ensure all dates are included
                .Where(order => order == null
                  || (order.CreatedAt >= startDate.ToDateTime(TimeOnly.MinValue)
                  && order.CreatedAt <= endDate.ToDateTime(TimeOnly.MaxValue))
                )
                group order by date into dailyGroup
                select new OrderIncome
                {
                  Date = dailyGroup.Key,
                  Income = (int)dailyGroup.Sum(o => o != null ? o.TotalItemPrice : 0)! // Assuming `Price` is the income field
                };

    return query;
  }
  public async Task<List<OrderIncome>> FindOrderIncome(DateOnly startDate, DateOnly endDate, int page, int perPage)
  {
    var query = QueryOrderIncomePerDate(startDate, endDate);
    var offset = (page - 1) * perPage;
    var result = query.Skip(offset).Take(perPage).ToList();

    return result;
  }
  public async Task<int> CountOrderIncome(DateOnly startDate, DateOnly endDate)
  {
    var query = QueryOrderIncomePerDate(startDate, endDate);
    var result = query.Count();

    return result;
  }

  public async Task<int> SumOrderIncome(DateOnly startDate, DateOnly endDate)
  {
    var totalIncome = await (
      from order in _context.Order
      where order.CreatedAt >= startDate.ToDateTime(TimeOnly.MinValue) &&
            order.CreatedAt <= endDate.ToDateTime(TimeOnly.MinValue)
      select order.TotalItemPrice
    )
    .SumAsync();

    return totalIncome != null ? (int) totalIncome : 0;
  }
}
