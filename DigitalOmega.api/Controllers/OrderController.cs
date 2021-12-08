using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Order;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;
        private readonly IConfiguration configuration;
        public OrderController(IOrderService _orderService, IConfiguration configuration)
        {
            this.orderService = _orderService;
            this.configuration = configuration;
        }
        [HttpPost]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        // [AdminAuthorize(ERight.SuperAdmin)]
        [Route("SaveOrder")]
        public async Task<IActionResult> SaveOrder(CreateCustomerRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
                //var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await orderService.AddOrder(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetOrderList")]
        public IActionResult GetOrderList(ListOrderModel page)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK, new Response<GetOrderResponse>() { IsError = false, Message = "", Data = orderService.GetOrder(page) });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetOrderByID")]
        public async Task<IActionResult> GetOrderByID(Guid? orderId)
        {
            if (orderId == null)
            {
                return BadRequest();
            }

            try
            {
                var dispositon = await orderService.GetOrderByID(orderId);

                if (dispositon == null)
                {
                    return NotFound();
                }

                return Ok(dispositon);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetOrderByAffiliate")]
        public async Task<IActionResult> GetOrderByAffiliate(string? affiliate)
        {
            if (affiliate == null)
            {
                return BadRequest();
            }

            try
            {
                var orders = await orderService.GetOrderByAffiliate(affiliate);

                if (orders == null)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetOrderByAgentId")]
        public async Task<IActionResult> GetOrderByAgentId(string? agentId)
        {
            if (agentId == null)
            {
                return BadRequest();
            }

            try
            {
                var order = await orderService.GetOrderByAgentId(agentId);

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
