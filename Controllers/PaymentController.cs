using Golden_Leaf_Back_End.Models;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.ErrorModels;
using Golden_Leaf_Back_End.Models.OrderModels;
using Golden_Leaf_Back_End.Models.PaymentModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IClientRepository clientRepository;
        private readonly IOrderRepository orderRepository;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IClientRepository clientRepository,
            IOrderRepository orderRepository)
        {
            this.paymentRepository = paymentRepository;
            this.clientRepository = clientRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve a collections of payments.")]
        [SwaggerResponse(200, "The request has succeeded.", typeof(Pagination<Payment>))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        public async Task<IActionResult> Get([FromQuery] PaymentFilter filter, [FromQuery] EntityOrder order, [FromQuery] PagingParams pagination)
        {
            var list = await paymentRepository.Browse()
                .AplyFilter(filter)
                .AplyOrder(order)
                .ToEntityPaginated(pagination);

            return Ok(list);
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new payment.", Description = "Requires admin privileges")]
        [SwaggerResponse(201, "The category was created", typeof(string))]
        [SwaggerResponse(500, "The server encountered an unexpected condition that prevented it from fulfilling the request.", typeof(ErrorResponse))]
        [SwaggerResponse(400, "The was unable to processe the request.", typeof(ErrorResponse))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(CreatingPaymentModel model)
        {
            if (ModelState.IsValid)
            {
                var client = await clientRepository.Read(model.ClientId);
                if (client == null)
                {
                    return NotFound($"Cliente com Id {model.ClientId} não foi encontrado.");
                }

                if (model.Value <= 0 || model.Value > client.Debt)
                {
                    return BadRequest($"O valor precisa ser maior que R$ 0 e menor que R$ {client.Debt}");
                }

                client.Debt -= model.Value;
                client.LastPurchase = DateTime.Now;

                if (client.Debt == 0)
                {
                    var pendings = await orderRepository.Pending(client.Id);
                    foreach (var order in pendings)
                    {
                        order.Status = Models.OrderModels.Status.Pago;
                    }
                }

                var p = new Payment
                {
                    Client = client,
                    Amount = model.Value,
                    Date = DateTime.Now,
                };

                await paymentRepository.Add(p);
                var url = Url.Action("Get", new { id = p.Id });
                var created = Created(url, p);
                return created;
            }

            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }
    }
}
