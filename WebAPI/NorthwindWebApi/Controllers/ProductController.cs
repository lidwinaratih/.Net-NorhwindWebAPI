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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /*[HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var product = _repository.Products.GetAllProduct(trackChanges : false);

                var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetProduct)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "ProductById")]
        public IActionResult GetProduct(int id)
        {
            var product = _repository.Products.GetProduct(id, trackChanges : false);

            if (product == null)
            {
                _logger.LogInfo($"Product with Id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }
        }*/

        /*[HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("Product object is null");
                return BadRequest("Product object is null");
            }

            var productEntity = _mapper.Map<Product>(productDto);
            _repository.Products.CreateProduct(productEntity);
            _repository.Save();

            var productResult = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("ProductById", new { id = productResult.ProductId }, productResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _repository.Products.GetProduct(id, trackChanges: false);

            if(product == null)
            {
                _logger.LogInfo($"Product with Id : {id} not found");
                return NotFound();
            }

            _repository.Products.DeleteProduct(product);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError($"Product must not be null");
                return BadRequest("Product must not be null");
            }

            var productEntity = _repository.Products.GetProduct(id, trackChanges: true);

            if (productEntity == null)
            {
                _logger.LogInfo($"Product with Id : {id} not found");
                return NotFound();
            }

            _mapper.Map(productDto, productEntity);
            _repository.Products.UpdateProduct(productEntity);

            _repository.Save();
            return NoContent();
        }*/
    }
}
