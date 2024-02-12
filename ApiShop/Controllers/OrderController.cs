using ApiShop.Dto;
using ApiShop.Interfaces;
using ApiShop.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiShop.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepositoy;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepositoy, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepositoy = orderRepositoy;          
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        public async Task<IActionResult> GetOrders()
        {
            var order = _mapper.Map<List<OrderDto>>(await _orderRepositoy.GetOrders());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(order);
        }

        [HttpGet("{orderName}")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        public async Task<IActionResult> GetOrdersByName(string orderName)
        {
            var order = _mapper.Map<List<OrderDto>>(await _orderRepositoy.GetOrdersByName(orderName));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(order);
        }
    
        [HttpGet("date/{orderDate}")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        public async Task<IActionResult> GetOrderByDate(DateTime orderDate)
        {
            var order = _mapper.Map<List<OrderDto>>( await _orderRepositoy.GetOrdersByDate(orderDate));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(order);
        }
    }
}
