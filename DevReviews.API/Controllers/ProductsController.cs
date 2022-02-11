using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        // GET para api/products
        /// <summary> Retorno de todos os Produtos </summary>
        /// <returns> Todos os products do banco</returns>
        /// <response code="200">OK</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        // GET para api/products/{id}
        /// <summary> Retorno de um produto </summary>
        /// <param name="id"></param>
        /// <returns> One ProductDetails </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetDetailsByIdAsync(id);

            if (product == null)
                return NotFound();

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        // POST para api/products
        /// <summary>Cadastro de Produto</summary>
        /// <remarks>Requisição:
        /// {
        ///  "title": "Notebook",
        ///  "description": "Roda Tudo no Ultra!",
        ///  "price": 7000
        /// }
        /// </remarks>
        /// <param name="model">Objeto com dados de cadastro de Produto</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            await _repository.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // PUT para api/products/{id}
        /// <summary>
        /// Atualização de Produto
        /// </summary>
        /// <remarks> {"description": "Roda tudo no Low","price": 7000}</remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns> 204 No content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            if (model.Description.Length > 50)
                return BadRequest();

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            product.Update(model.Description, model.Price);

            await _repository.UpdateAsync(product);

            return NoContent();
        }
    }

}



