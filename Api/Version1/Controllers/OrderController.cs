using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.API.Version1.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.API.Version1.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using dot_dotnet_test_api.API.Version1.Services;

namespace dot_dotnet_test_api.API.Version1.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController(
        ILogger<OrderController> logger,
        OrderService orderService
    ) : ControllerBase
    {
        private readonly ILogger<OrderController> _logger = logger;
        private readonly OrderService _orderService = orderService;


        // POST: api/v1/order/checkout/preview
        [HttpPost("checkout/preview")]
        [Authorize]
        public async Task<ContentResult> PreviewOrder([FromBody] OrderCreateOrViewDto orderCreateOrViewDto)
        {
            var validator = new OrderCreateOrViewValidator();
            ValidationResult results = validator.Validate(orderCreateOrViewDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Preview Order Failed");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _orderService.PreviewOrder(orderCreateOrViewDto, Convert.ToInt64(userId));
        }

        // POST: api/v1/order/checkout
        [HttpPost("checkout")]
        [Authorize]
        public async Task<ContentResult> CheckoutOrder([FromBody] OrderCreateOrViewDto orderCreateOrViewDto)
        {
            var validator = new OrderCreateOrViewValidator();
            ValidationResult results = validator.Validate(orderCreateOrViewDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Checkout Order Failed");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await _orderService.CheckOutOrder(orderCreateOrViewDto, Convert.ToInt64(userId));
        }
    }
}
