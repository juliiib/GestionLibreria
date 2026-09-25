using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibreria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult<OrderResponse> Create([FromBody] CreateOrderRequest request)
        {
            try
            {
                OrderResponse? order = _orderService.CreateOrder(request);
                if (order == null)
                {
                    return BadRequest("Failed to create order.");
                }
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Order>> GetAll()
        {
            var orders = _orderService.GetAllOrders();
            if (!orders.Any())
            {
                return NotFound("No orders found.");
            }
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderResponse> GetOrderById(Guid id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            return Ok(order);
        }

        [HttpPatch("{id}/complete")]
        public ActionResult<OrderResponse> CompleteOrder(Guid id)
        {
            if (!_orderService.MarkOrderAsCompleted(id))
            {
                return NotFound("Order not found.");
            }
            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public ActionResult<OrderResponse> CancelOrder(Guid id)
        {
            if (!_orderService.MarkOrderAsCancelled(id))
            {
                return NotFound("Order not found.");
            }
            return NoContent();
        }
    }
}
