using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts;
using Northwind.Entities.DataTransferObject;
using Northwind.Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NorthwindWebApi.Controllers
{
    [Route("api/orderDetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderDetailsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /*[HttpGet]
        public IActionResult GetOrderDetails()
        {
            try
            {
                var orderDetails = _repository.OrderDetails.GetAllOrderDetail(trackChanges: false);

                var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);

                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetOrderDetails)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "OrderDetailById")]
        public IActionResult GetOrderDetail(int id, int proId)
        {
            var orderDetails = _repository.OrderDetails.GetOrderDetail(id, proId, trackChanges: false);

            if (orderDetails == null)
            {
                _logger.LogInfo($"Order Details with Id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var orderDetailsDto = _mapper.Map<OrderDetailDto>(orderDetails);
                return Ok(orderDetailsDto);
            }
        }*/

        /*[HttpPost]
        public IActionResult CreateOrderDetails([FromBody] OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null)
            {
                _logger.LogError("Order Detail object is null");
                return BadRequest("Order Detail object is null");
            }

            var orderDetailEntity = _mapper.Map<OrderDetail>(orderDetailDto);
            _repository.OrderDetails.CreateOrderDetail(orderDetailEntity);
            _repository.Save();

            var orderDetailResult = _mapper.Map<OrderDetailDto>(orderDetailEntity);
            return CreatedAtRoute("OrderDetailById", new { id = orderDetailResult.OrderId }, orderDetailResult);
        }

        [HttpDelete]
        public IActionResult DeleteOrderDetail(int id)
        {
            var orderDetail = _repository.OrderDetails.GetOrderDetail(id, trackChanges: false);

            if (orderDetail == null)
            {
                _logger.LogInfo($"Order Detail with id : {id} not found");
                return NotFound();
            }

            _repository.OrderDetails.DeleteOrderDetail(orderDetail);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null)
            {
                _logger.LogError($"Order Detail must not be null");
                return BadRequest("Order Detail must not be null");
            }

            var orderDetailEntity = _repository.OrderDetails.GetOrderDetail(id, trackChanges: true);

            if (orderDetailEntity == null)
            {
                _logger.LogInfo($"Order Detail with Id : {id} not found");
                return NotFound();
            }

            _mapper.Map(orderDetailDto, orderDetailEntity);
            _repository.OrderDetails.UpdateOrderDetail(orderDetailEntity);

            _repository.Save();
            return NoContent();
        }*/
    }
}
