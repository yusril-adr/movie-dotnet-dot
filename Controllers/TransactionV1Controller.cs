using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.Validators;
using FluentValidation.Results;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using NuGet.Protocol;

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class TransactionV1Controller(SQLServerContext context, ILogger<TransactionV1Controller> logger) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<TransactionV1Controller> _logger = logger;


        // POST: api/v1/order/checkout/preview
        [HttpPost("checkout/preview")]
        [Authorize]
        public async Task<ActionResult> PreviewOrder([FromBody] TransactionV1OrderDto transactionV1OrderDto)
        {
            var validator = new TransactionV1OrderValidator();
            ValidationResult results = validator.Validate(transactionV1OrderDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Preview Order Failed");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.FindAsync(Convert.ToInt64(userId));


            var orderItems = new OrderItemsV1[transactionV1OrderDto.Items.Length];
            int totalPriceAll = 0;
            int totalQty = 0;
            int idx = 0;
            foreach (var item in transactionV1OrderDto.Items)
            {
                var foundedSchedule = await _context.Schedule
                    .Include(x => x.Studio)
                    .Where(x => x.Id == (long) item.MovieScheduleId)
                    .SingleAsync();
                    
                if (foundedSchedule == null) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} not found",
                        message: "Preview Order Failed"
                    ).GetFormated(StatusCodes.Status404NotFound);
                }

                var startTime = DateTime.Parse($"{foundedSchedule.Date.ToString()} {foundedSchedule.StartTime}");

                if (DateTime.Now >= startTime) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} already passed.",
                        message: "Preview Order Failed"
                    ).GetFormated(StatusCodes.Status400BadRequest);
                }

                var shceduleStudioCount = await _context.OrderItems
                    .Where(x => x.MovieSchedule.Id == (long) item.MovieScheduleId)
                    .SumAsync(x => x.Qty);
                
                if ((foundedSchedule.Studio.SeatCapacity - (int) shceduleStudioCount) < item.Qty) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} is overload",
                        message: "Checkout Order Failed"
                    ).GetFormated(StatusCodes.Status400BadRequest);
                }

                var SubTotalPrice = foundedSchedule.Price * (int) item.Qty;
                var orderItem = new OrderItemsV1{
                    MovieSchedule = foundedSchedule,
                    Price = foundedSchedule.Price,
                    Qty = item.Qty,
                    SubTotalPrice = SubTotalPrice,
                };

                totalQty += (int) item.Qty;
                totalPriceAll += SubTotalPrice;
                orderItems[idx++] = orderItem;
            }

            var order = new OrderV1{
                User = user,
                OrderItems = orderItems,
                TotalItemPrice = totalPriceAll
            };


            return new Response<object>(
                data: new {
                    total_qty = totalQty,
                    total_price = order.TotalItemPrice,
                    item_details = order.OrderItems.Select(item => new {
                        studio_number = item.MovieSchedule!.Studio!.StudioNumber,
                        qty = item.Qty,
                        sub_total_price = item.SubTotalPrice,
                        start_time = item.MovieSchedule.StartTime,
                        end_time = item.MovieSchedule.EndTime
                    }).ToArray(),
                },
                message: "Preview Order Success"
            ).GetFormated();
        }

        // POST: api/v1/order/checkout
        [HttpPost("checkout")]
        [Authorize]
        public async Task<ActionResult> CheckoutOrder([FromBody] TransactionV1OrderDto transactionV1OrderDto)
        {
            var validator = new TransactionV1OrderValidator();
            ValidationResult results = validator.Validate(transactionV1OrderDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Checkout Order Failed");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.FindAsync(Convert.ToInt64(userId));


            var orderItems = new OrderItemsV1[transactionV1OrderDto.Items.Length];
            int totalPriceAll = 0;
            int totalQty = 0;
            int idx = 0;
            foreach (var item in transactionV1OrderDto.Items)
            {
                var foundedSchedule = await _context.Schedule
                    .Include(x => x.Studio)
                    .Where(x => x.Id == (long) item.MovieScheduleId)
                    .SingleAsync();
                    
                if (foundedSchedule == null) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} not found",
                        message: "Checkout Order Failed"
                    ).GetFormated(StatusCodes.Status404NotFound);
                }
                
                var startTime = DateTime.Parse($"{foundedSchedule.Date.ToString()} {foundedSchedule.StartTime}");

                if (DateTime.Now >= startTime) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} already passed.",
                        message: "Checkout Order Failed"
                    ).GetFormated(StatusCodes.Status400BadRequest);
                }

                var shceduleStudioCount = await _context.OrderItems
                    .Where(x => x.MovieSchedule.Id == (long) item.MovieScheduleId)
                    .SumAsync(x => x.Qty);
                
                if ((foundedSchedule.Studio.SeatCapacity - (int) shceduleStudioCount) < item.Qty) {
                    return new Response<object>(
                        error: $"Movie Schedule with id {item.MovieScheduleId} is overload",
                        message: "Checkout Order Failed"
                    ).GetFormated(StatusCodes.Status400BadRequest);
                }   

                var SubTotalPrice = foundedSchedule.Price * (int) item.Qty;
                var orderItem = new OrderItemsV1{
                    MovieSchedule = foundedSchedule,
                    Price = foundedSchedule.Price,
                    Qty = item.Qty,
                    SubTotalPrice = SubTotalPrice,
                };

                totalQty += (int) item.Qty;
                totalPriceAll += SubTotalPrice;
                orderItems[idx++] = orderItem;
            }

            var order = new OrderV1{
                User = user,
                OrderItems = orderItems,
                TotalItemPrice = totalPriceAll
            };

            _context.Add(order);
            await _context.SaveChangesAsync();


            return new Response<object>(
                data: new {
                    total_qty = totalQty,
                    total_price = order.TotalItemPrice,
                    item_details = order.OrderItems.Select(item => new {
                        studio_number = item.MovieSchedule!.Studio!.StudioNumber,
                        qty = item.Qty,
                        sub_total_price = item.SubTotalPrice,
                        start_time = item.MovieSchedule.StartTime,
                        end_time = item.MovieSchedule.EndTime
                    }).ToArray(),
                },
                message: "Preview Order Success"
            ).GetFormated();
        }
    }
}
