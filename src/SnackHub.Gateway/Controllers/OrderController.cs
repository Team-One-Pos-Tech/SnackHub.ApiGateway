using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.KitchenOrder;
using SnackHub.Gateway.Models.Order;
using SnackHub.Gateway.Services;
using System.Net.Http.Json;

namespace SnackHub.Api.Gateway.Controllers
{
    [ApiController]
    [Route("order-api/v1")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var orderResponse = await _orderService.GetAll();
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);
        }

        [HttpPost("Confirm")]
        public async Task<ActionResult> Confirm([FromBody] ConfirmOrderRequest request)
        {
            var orderResponse = await _orderService.Confirm(request);
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);            
        }

        [HttpPut("Cancel")]
        public async Task<ActionResult> Cancel([FromBody] CancelOrderRequest request)
        {
            var orderResponse = await _orderService.Cancel(request);
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);
        }

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] CheckoutOrderRequest request)
        {
            var orderResponse = await _orderService.Checkout(request);
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);
        }

        [HttpGet("{orderId:guid}/payment-status")]
        public async Task<ActionResult> CheckPaymentStatus(Guid orderId)
        {
            var orderResponse = await _orderService.CheckPaymentStatus(orderId);
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);
        }

        [HttpPut("{orderId:guid}/status")]
        public async Task<ActionResult> UpdateOrderStatus(Guid orderId)
        {
            var orderResponse = await _orderService.UpdateOrderStatus(orderId);
            if (orderResponse == null)
                return NotFound("Order not found");

            return Ok(orderResponse);
        }
    }
}
