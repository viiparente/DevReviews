using Microsoft.AspNetCore.Mvc;

namespace DevReviews.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }

        // GET para api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        // GET para api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Se não achar, retornar NotFound()

            return Ok();
        }

        // POST para api/products
        [HttpPost]
        public IActionResult Post(object model)
        {
            // Add o objeto
            // Se tiver erros de validação, retornar BadRequest()
            return CreatedAtAction(nameof(GetById), new { id = 1 /* id do model*/ }, model);
        }

        // PUT para api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, object model)
        {
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com o id especificado, retornar NotFound()

            return NoContent();
        }
    }

}



