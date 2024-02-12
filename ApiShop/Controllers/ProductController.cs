using ApiShop.Interfaces;
using ApiShop.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiShop.Dto;
using ApiShop.Helper;
using ApiShop.Context;

namespace ApiShop.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ShopContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ShopContext context, IProductRepository productRepository, IMapper mapper)
        {
            _context = context;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProductDto))]

        public async Task<IActionResult> GetProducts()
        {
            var product =  _mapper.Map<List<ProductDto>>( await _productRepository.GetProducts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return  Ok(product);
            
        }

        [HttpGet("name/{productName}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductsByName(string productName)
        {
            var product = _mapper.Map<List<ProductDto>>(await _productRepository.GetProductsByName(productName));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("manufacturer/{productManufacturer}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductsByManufacturer(string productManufacturer)
        {
            var product = _mapper.Map<List<ProductDto>>(await _productRepository.GetProductsByManufacturer(productManufacturer));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("provider/{productProvider}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductsByProvider(string productProvider)
        {
            var product = _mapper.Map<List<ProductDto>>(await _productRepository.GetProductsByProvider(productProvider));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("category/{productCategory}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductsByCategory(string productCategory)
        {
            var product = _mapper.Map<List<ProductDto>>(await _productRepository.GetProductsByCategory(productCategory));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("article/{productArticle}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductByArticle(string productArticle)
        {
            var product = _mapper.Map<ProductDto>(await _productRepository.GetProductByArticle(productArticle));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if(productDto == null)
                return BadRequest(ModelState);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = ProductConverter.ConvertorProducts(_context,productDto);

            if(!await _productRepository.CreateProduct(product))
            {
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);
            }
            return Ok("Add product");

        }


    }
}
