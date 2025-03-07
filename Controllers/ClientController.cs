﻿using Golden_Leaf_Back_End.Models;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Golden_Leaf_Back_End.Models.ProductModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository repository;
        private readonly IProductRepository productRepository;

        public ClientController(IClientRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Retrieve a collections of clients.")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Pagination<Client>))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        public async Task<IActionResult> Get([FromQuery] ClientFilter filter, [FromQuery] EntityOrder order, [FromQuery] PagingParams pagination)
        {
            var list = await repository.Browse()
                .AplyFilter(filter)
                .AplyOrder(order)
                .ToEntityPaginated(pagination);

            return Ok(list);
        }

        [HttpGet]
        [Route("{id}/Suggestions")]
        [SwaggerOperation(Summary = "Retrieve a collections of products.")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Pagination<Product>))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        public async Task<IActionResult> Suggestions(int id, [FromQuery] ProductFilter filter, [FromQuery] EntityOrder order, [FromQuery] PagingParams pagination)
        {
            var list = await (await productRepository.SuggestionsTo(id))
                .AplyFilter(filter)
                .AplyOrder(order)
                .ToEntityPaginated(pagination);

            return Ok(list);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieve a client identified by it's {id}")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Client))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(404, "The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", typeof(ErrorResponse))]
        public async Task<IActionResult> Get(int id)
        {
            var client = await repository.Read(id);
            if (client == null)
            {
                return NotFound(id);
            }
            return Ok(client);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new client.", Description = "Requires admin privileges")]
        [SwaggerResponse(201, "The client was created", typeof(string))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(400, "The was unable to processe the request.", typeof(ErrorResponse))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(CreatingClientModel model)
        {
            if (ModelState.IsValid)
            {
                var c = new Client
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Notifiable = model.Notifiable
                };

                await repository.Add(c);
                var url = Url.Action("Get", new { id = c.Id });
                return Created(url, c);
            }

            return BadRequest(ErrorResponse.From(ModelState));
        }


        [HttpPut]
        [SwaggerOperation(Summary = "Modifies a client.", Description = "Requires admin privileges")]
        [SwaggerResponse(201, "The category modification has succeeded.", typeof(Client))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(400, "The was unable to processe the request.", typeof(ErrorResponse))]
        [SwaggerResponse(404, "The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", typeof(ErrorResponse))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Put(EditingClientModel model)
        {
            if (ModelState.IsValid)
            {
                var c = await repository.Read(model.Id);
                if (c == null)
                {
                    return NotFound(model.Id);
                }

                c.Name = model.Name;
                c.Address = model.Address;
                c.PhoneNumber = model.PhoneNumber;
                c.Notifiable = model.Notifiable;

                await repository.Edit(c);
                return Ok(c);
            }
            return BadRequest(ErrorResponse.From(ModelState));
        }


    }
}
