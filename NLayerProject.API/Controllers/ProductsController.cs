using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Entities;
using NLayerProject.Core.Service;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NLayerProject.API.Controllers
{
    // Add the validationFilter for all, configure the start up for that.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetbyIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpGet("{id}/category")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var product = await  _productService.GetWithCatergoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [ValidationFilter]
        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            //  return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
            return Ok(newProduct);

        }
        [HttpPut]

        public IActionResult Update(ProductDto productDto)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult Remove(int id)
        {
            var product = _productService.GetbyIdAsync(id).Result;

            _productService.Remove(product);

            return NoContent();
        }



    }
}
