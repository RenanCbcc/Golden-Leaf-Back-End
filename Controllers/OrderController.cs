using Golden_Leaf_Back_End.Models;
using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Golden_Leaf_Back_End.Models.OrderModels;
using Golden_Leaf_Back_End.Models.ProductModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProductRepository productRepository;
        private readonly UserManager<Clerk> userManager;

        public OrderController(IOrderRepository orderRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository, UserManager<Clerk> userManager)
        {
            this.orderRepository = orderRepository;
            this.clientRepository = clientRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve a collection of orders.")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Pagination<Order>))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        public async Task<IActionResult> Get([FromQuery] OrderFilter filter, [FromQuery] EntityOrder order, [FromQuery] PagingParams pagination)
        {
            var list = await orderRepository.Browse()
                .AplyFilter(filter)
                .AplyOrder(order)
                .ToEntityPaginated(pagination);

            return Ok(list);
        }

        [SwaggerOperation(Summary = "Retrieve a item collections items identified by order's {id}")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Item))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(404, "The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", typeof(ErrorResponse))]
        [HttpGet("{id}/Item")]
        public IActionResult GetItems(int id)
        {
            var list = orderRepository.Browse(id);

            return Ok(list);
        }


        [SwaggerOperation(Summary = "Retrieve an order identified by it's {id}")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Order))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(404, "The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", typeof(ErrorResponse))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await orderRepository.Read(id);
            if (order == null)
            {
                return NotFound(id);
            }
            return Ok(order);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new order.", Description = "Requires admin privileges")]
        [SwaggerResponse(201, "The category was created", typeof(string))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(400, "The was unable to processe the request.", typeof(ErrorResponse))]
        [SwaggerResponse(404, "The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", typeof(ErrorResponse))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(CreatingOrderModel model)
        {
            if (ModelState.IsValid)
            {
                var client = await clientRepository.Read(model.ClientId);
                if (client == null)
                {
                    return NotFound(ErrorResponse.From($"Cliente com o Id {model.ClientId} não foi encontrado."));
                }

                var clerk = await userManager.FindByIdAsync(model.ClerkId);
                if (clerk == null)
                {
                    return NotFound(ErrorResponse.From($"Atendent com o Id {model.ClerkId} não foi encontrado."));
                }

                var order = new Order
                {
                    Client = client,
                    Items = model.Items,
                    Date = DateTime.Now,
                };

                foreach (var item in model.Items)
                {
                    var p = await productRepository.Read(item.ProductId);
                    if (p == null)
                    {
                        return NotFound(ErrorResponse.From($"Produto com Id {item.ProductId} não foi encontrado."));
                    }
                    if (item.Quantity > p.Quantity)
                    {
                        return BadRequest(ErrorResponse.From("Quantidade em estoque insuficiente."));
                    }

                    item.Value = p.SalePrice;
                    p.Quantity -= item.Quantity;
                    var total = (p.SalePrice * item.Quantity);
                    order.Value += total;
                }

                client.Debt += order.Value;

                await orderRepository.Add(order);
                var url = Url.Action("Get", new { id = order.Id });
                var created = Created(url, order);
                return created;
            }

            return BadRequest(ErrorResponse.From(ModelState));
        }

    }
}
