using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewsController : ControllerBase
    {

        private readonly DevReviewsDbContext _dbContext;
        public ProductReviewsController(DevReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/products/1/productreviews/5
        [HttpGet("{id}")]
        public IActionResult GetById(int productId, int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var productreview = _dbContext.Products
                .Select(e => e.Reviews)
                .Select(e => e.SingleOrDefault(e => e.Id == id));

            if (productreview == null)
                NotFound();

            return Ok(productreview);
        }

        // POST api/products/1/productreviews
        [HttpPost]
        public IActionResult Post(int productId, AddProductReviewInputModel model)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            product.AddReview(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}
