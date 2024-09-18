using Coravel.Queuing.Interfaces;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dot_dotnet_test_api.API.Version1.Services;

public class OrderService (
  IConfiguration configuration,
  UserRepository userRepository,
  OrderRepository orderRepository,
  MovieScheduleRepository movieScheduleRepository,
  IQueue queue,
  ILogger<OrderService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly UserRepository _userRepository = userRepository;
  private readonly OrderRepository _orderRepository = orderRepository;
  private readonly MovieScheduleRepository _movieScheduleRepository = movieScheduleRepository;
  private readonly IQueue _queue = queue;

  private readonly ILogger<OrderService> _logger = logger;

  public async Task<ContentResult> PreviewOrder(OrderCreateOrViewDto orderCreateOrViewDto, long userId)
  {
    var user = await _userRepository.FindById(userId);

    var orderItems = new OrderItems[orderCreateOrViewDto.Items!.Length];
    int totalPriceAll = 0;
    int totalQty = 0;
    int idx = 0;
    foreach (var item in orderCreateOrViewDto.Items)
    {
      var foundedSchedule = await _movieScheduleRepository.FindById((long)item.MovieScheduleId!);

      if (foundedSchedule == null)
      {
        return new Response<object>(
            error: $"Movie Schedule with id {item.MovieScheduleId} not found",
            message: "Preview Order Failed"
        ).GetFormated(StatusCodes.Status404NotFound);
      }

      var startTime = DateTime.Parse($"{foundedSchedule.Date.ToString()} {foundedSchedule.StartTime}");

      if (DateTime.Now >= startTime)
      {
        return new Response<object>(
            error: $"Movie Schedule with id {item.MovieScheduleId} already passed.",
            message: "Preview Order Failed"
        ).GetFormated(StatusCodes.Status400BadRequest);
      }

      if (foundedSchedule.RemainingSeat < item.Qty)
      {
        return new Response<object>(
            error: $"Movie Schedule with id {item.MovieScheduleId} is overload",
            message: "Checkout Order Failed"
        ).GetFormated(StatusCodes.Status400BadRequest);
      }

      var SubTotalPrice = foundedSchedule.Price * (int)item.Qty!;
      var orderItem = new OrderItems
      {
        MovieSchedule = foundedSchedule,
        Price = foundedSchedule.Price,
        Qty = item.Qty,
        SubTotalPrice = SubTotalPrice,
      };

      totalQty += (int)item.Qty;
      totalPriceAll += SubTotalPrice;
      orderItems[idx++] = orderItem;
    }

    var order = new Order
    {
      User = user,
      OrderItems = orderItems,
      TotalItemPrice = totalPriceAll
    };

    return new Response<PreviewOrderResult>(
        data: new PreviewOrderResult
        {
          TotalQty = totalQty,
          TotalPrice = order.TotalItemPrice == null ? 0 : (int)order.TotalItemPrice,
          ItemDetails = order.OrderItems.Select(item => new PreviewOrderDetailResult
          {
            StudioNumber = item.MovieSchedule!.Studio!.StudioNumber,
            Qty = item.Qty == null ? 0 : (int)item.Qty,
            SubTotalPrice = item.SubTotalPrice == null ? 0 : (int)item.SubTotalPrice,
            StartTime = item.MovieSchedule.StartTime,
            EndTime = item.MovieSchedule.EndTime
          }).ToArray(),
        },
        message: "Preview Order Success"
    ).GetFormated();
  }

  public async Task<ContentResult> CheckOutOrder(OrderCreateOrViewDto orderCreateOrViewDto, long userId)
  {
    var user = await _userRepository.FindById(userId);

    var orderItems = new OrderItems[orderCreateOrViewDto.Items!.Length];
    int totalPriceAll = 0;
    int idx = 0;

    foreach (var item in orderCreateOrViewDto.Items)
    {
      var foundedSchedule = await _movieScheduleRepository.FindById((long)item.MovieScheduleId!);

      if (foundedSchedule == null)
      {
        return new Response<object>(
            error: $"Movie Schedule with id {item.MovieScheduleId} not found",
            message: "Checkout Order Failed"
        ).GetFormated(StatusCodes.Status404NotFound);
      }

      var startTime = DateTime.Parse($"{foundedSchedule.Date.ToString()} {foundedSchedule.StartTime}");

      // if (DateTime.Now >= startTime)
      // {
      //   return new Response<object>(
      //       error: $"Movie Schedule with id {item.MovieScheduleId} already passed.",
      //       message: "Checkout Order Failed"
      //   ).GetFormated(StatusCodes.Status400BadRequest);
      // }

      if (foundedSchedule.RemainingSeat < item.Qty)
      {
        return new Response<object>(
            error: $"Movie Schedule with id {item.MovieScheduleId} is overload",
            message: "Checkout Order Failed"
        ).GetFormated(StatusCodes.Status400BadRequest);
      }

      var SubTotalPrice = foundedSchedule.Price * (int)item.Qty!;
      var orderItem = new OrderItems
      {
        MovieSchedule = foundedSchedule,
        Price = foundedSchedule.Price,
        Qty = item.Qty,
        SubTotalPrice = SubTotalPrice,
      };

      foundedSchedule.RemainingSeat -= item.Qty;

      totalPriceAll += SubTotalPrice;
      orderItems[idx++] = orderItem;

      await _movieScheduleRepository.Update(foundedSchedule);
    }

    var order = new Order
    {
      User = user,
      OrderItems = orderItems,
      TotalItemPrice = totalPriceAll
    };

    await _orderRepository.Create(order);

    var emailMessage = new EmailMessage
    {
      To = "yusriladr.37@gmail.com",
      Subject = "Your checkout is success",
      Body = $"Your checkout id is {order.Id}",
    };

    _queue.QueueInvocableWithPayload<EmailInvocable, EmailMessage>(emailMessage);

    return new Response<PreviewOrderResult>(
        data: PreviewOrderResult.MapJson(order),
        message: "Checkout Order Success"
    ).GetFormated();
  }
}
