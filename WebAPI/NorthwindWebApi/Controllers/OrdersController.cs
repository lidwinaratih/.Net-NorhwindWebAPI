using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts;
using Northwind.Contracts.ServiceChart;
using Northwind.Entities.DataTransferObject;
using Northwind.Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NorthwindWebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IChartService _chartService;

        public OrdersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IChartService chartService)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _chartService = chartService;
        }

        /*[HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = _repository.Orders.GetAllOrder(trackChanges: false);

                var ordersDto = _mapper.Map<IEnumerable<OrdersDto>>(orders);

                return Ok(ordersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetOrders)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrder(int id)
        {
            var order = _repository.Orders.GetOrder(id, trackChanges: false);

            if (order == null)
            {
                _logger.LogInfo($"Order with Id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var orderDto = _mapper.Map<OrdersDto>(order);
                return Ok(orderDto);
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrdersDto ordersDto)
        {
            if (ordersDto == null)
            {
                _logger.LogError("Order object is null");
                return BadRequest("Order object is null");
            }

            var ordersEntity = _mapper.Map<Order>(ordersDto);
            _repository.Orders.CreateOrder(ordersEntity);
            _repository.Save();

            var ordersResult = _mapper.Map<OrdersDto>(ordersEntity);
            return CreatedAtRoute("OrderById", new { id = ordersResult.OrderId }, ordersResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _repository.Orders.GetOrder(id, trackChanges: false);

            if (order == null)
            {
                _logger.LogInfo($"Order with Id : {id} not found");
                return NotFound();
            }

            _repository.Orders.DeleteOrder(order);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrdersDto orderDto)
        {
            if (orderDto == null)
            {
                _logger.LogError($"Order must not be null");
                return BadRequest("Order must not be null");
            }

            var orderEntity = _repository.Orders.GetOrder(id, trackChanges: true);

            if (orderEntity == null)
            {
                _logger.LogInfo($"Order with Id : {id} not found");
                return NotFound();
            }

            _mapper.Map(orderDto, orderEntity);
            _repository.Orders.UpdateOrder(orderEntity);

            _repository.Save();
            return NoContent();
        }*/

        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            try
            {
                var result = _chartService.GetAllProduct(trackChanges: false);

                return Ok(_mapper.Map<IEnumerable<ProductDto>>(result.Item2));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToChart(ChartDto chartDto)
        {
            try
            {
                var chartResult = _chartService.AddToChart(chartDto.ProductId, chartDto.Quantity, chartDto.CustomerId);

                if (chartResult.ProductId == -1)
                {
                    return BadRequest();
                }

                return Ok(_mapper.Map<OrderDetailDto>(chartResult));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Checkout")]
        public IActionResult CheckOut(int orderId)
        {
            try
            {
                var orderResult = _chartService.Checkout(orderId);
                
                if (orderResult.OrderId == -1)
                {
                    return BadRequest(orderResult);
                }
                return Ok(_mapper.Map<OrdersDto>(orderResult.OrderId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Shipped")]
        public IActionResult Shipped(ShipDto shipDto, int id)
        {
            try
            {
                var shipResult = _chartService.ShipOrder(shipDto, id);

                if (shipResult.ShipVia == -1)
                {
                    return BadRequest(shipResult);
                }
                return Ok(_mapper.Map<OrdersDto>(shipResult));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
