using Microsoft.AspNetCore.Mvc;
using SnackHub.Gateway.Models.KitchenOrder;
using SnackHub.Gateway.Services;

namespace SnackHub.Gateway.Controllers
{
    [ApiController]
    [Route("api/kitchen-api/v1")]
    public class KitchenOrderController : ControllerBase
    {
        private readonly KitchenOrderService _kitchenOrderService;

        public KitchenOrderController(KitchenOrderService kitchenOrderService)
        {
            _kitchenOrderService = kitchenOrderService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var kitchenOrderResponse = await _kitchenOrderService.GetAll();

            if (kitchenOrderResponse == null)
                return NotFound("KitchenOrder not found");

            return Ok(kitchenOrderResponse);
        }

        [HttpPut("UpdateStatus")]
        public async Task<ActionResult> UpdateStatus([FromRoute] Guid orderId)
        {
            var kithenOrderResponse = await _kitchenOrderService.UpdateStatus(orderId);

            if (kithenOrderResponse == null)
                return NotFound("KitchenOrder not found");

            return Ok(kithenOrderResponse);
        }
    }
}
