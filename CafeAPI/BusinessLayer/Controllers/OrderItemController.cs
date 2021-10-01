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
    public class OrderItemController : Controller
    {
        private readonly IOrderItemRepository _orderitemrepo;
        private readonly ILogger<OrderItemController> _logger;

        public OrderItemController(IOrderItemRepository oir, ILogger<OrderItemController> logger)
        {
            _orderitemrepo = oir;
            _logger = logger;
        }

        // "/OrderItem/addorderitem"
        [HttpPost("addorderitem")]
        public async Task<ActionResult<ViewModelOrderItem>> Create(ViewModelOrderItem vmoi)
        {
            if (!ModelState.IsValid) return BadRequest();

            ViewModelOrderItem vmoi1 = await _orderitemrepo.AddOrderItemAsync(vmoi);
            if (vmoi1 == null)
            {
                return NotFound();
            }
            return Created($"~orderitem", vmoi1);
        }
    }
}
