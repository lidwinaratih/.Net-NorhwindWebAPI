using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts;
using Northwind.Entities.DataTransferObject;
using Northwind.Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWebApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CustomersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            try
            {
                var customer = _repository.Customers.GetAllCustomer(trackChanges: false);

                var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customer);

                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetCustomer)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomer(string id)
        {
            var customer = _repository.Customers.GetCustomer(id, trackChanges: false);

            if (customer == null)
            {
                _logger.LogInfo($"Customer with Id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError("Customer object is null");
                return BadRequest("Customer object is null");
            }

            var customerEntity = _mapper.Map<Customer>(customerDto);
            _repository.Customers.CreateCustomer(customerEntity);
            _repository.Save();

            var customerResult = _mapper.Map<CustomerDto>(customerEntity);
            return CreatedAtRoute("CategoryById", new { id = customerResult.CustomerId }, customerResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            var customer = _repository.Customers.GetCustomer(id, trackChanges: false);

            if (customer == null)
            {
                _logger.LogInfo($"Customer with Id : {id} not found");
                return NotFound();
            }

            _repository.Customers.DeleteCustomer(customer);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                _logger.LogError($"Customer must not be null");
                return BadRequest("Customemr must not be null");
            }

            var customerEntity = _repository.Customers.GetCustomer(id, trackChanges: true);

            if(customerEntity == null)
            {
                _logger.LogInfo($"Customer with id : {id} not found");
                return NotFound();
            }

            _mapper.Map(customerDto, customerEntity);
            _repository.Customers.UpdateCustomer(customerEntity);

            _repository.Save();
            return NoContent();
        }
    }
}
