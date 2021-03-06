using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductReviewsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        // GET api/products/1/productreviews/5
        /// <summary>
        /// Retorna o Product Details
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns>Product Details</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productReview = await _repository.GetReviewByIdAsync(id);

            if (productReview == null)
                return NotFound();

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            Log.Information("Método GetById (Retorna o Product Details) finalizado!");

            return Ok(productDetails);
        }

        // POST api/products/1/productreviews
        /// <summary>
        /// Insere um review no product
        /// </summary>
        /// <remarks>{ "rating": 10,"author": "Parente","comments": "Muito Bom"}</remarks>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns> Id do Review relacionado ao product </returns>
        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            Log.Information("Método Post (Insere um review no product) finalizado!");

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}
