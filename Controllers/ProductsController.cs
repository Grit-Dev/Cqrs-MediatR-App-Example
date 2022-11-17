using CqrsMediatRExample.Commands;
using CqrsMediatRExample.Data;
using CqrsMediatRExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CqrsMediatRExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Allows us to send messages to mediator and dispatches them to the relevant handlers
        private readonly ISender _sender;

        //Example One:

        /*        
        
        public ProductsController(ISender sender)
        {
            _sender = sender;
        }*/


        //Better Way: 
        public ProductsController(ISender sender) => _sender = sender;


        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product pProduct)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(pProduct));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id}, productToReturn);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int pId)
        {
           var product = await _sender.Send(new GetProductByIdQuery(pId));

            return Ok(product);
        }
            

    }
}
