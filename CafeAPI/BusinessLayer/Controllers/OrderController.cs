using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderrepo;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository or, ILogger<OrderController> logger)
        {
            _orderrepo = or;
            _logger = logger;
        }

        // "/Order/placeorder"
        [HttpPost("placeorder")]
        public async Task<ActionResult<ViewModelOrder>> Create(ViewModelOrder vmo)
        {
            if (!ModelState.IsValid) return BadRequest();

            ViewModelOrder o1 = await _orderrepo.PlaceOrderAsync(vmo);
            if (o1 == null)
            {
                return NotFound();
            }
            return Created($"~order/{o1.Id}", o1);
        }

         // "/Order/orderlist"
        [HttpGet("orderlist")]
        public async Task<ActionResult<List<ViewModelOrder>>> Details()
        {
            if (!ModelState.IsValid) return BadRequest();

            Task<List<ViewModelOrder>> orders = _orderrepo.OrderListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            List<ViewModelOrder> orders1 = await orders;

            return orders1;
        }
    }
}
