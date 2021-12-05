using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DataViewModels.Enum;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.Request;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService providerService;
        private readonly IConfiguration configuration;
        public ProviderController(IProviderService _providerService, IConfiguration configuration)
        {
            this.providerService = _providerService;
            this.configuration = configuration;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetProviders")]
        public async Task<IActionResult> Getproviders()
        {
            try
            {
                var agents = StatusCode(StatusCodes.Status200OK, new { IsError = false, Message = "", Data = providerService.GetProviders() });

                //var agents = await agentService.GetAgents();
                if (agents == null)
                {
                    return NotFound();
                }

                return Ok(agents);
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
        [Route("GetProviderByID")]
        public async Task<IActionResult> GetProviderByID(Guid? agentId)
        {
            if (agentId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await providerService.GetProviderByID(agentId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
        [AdminAuthorize(ERight.SuperAdmin)]
        [Route("AddProvider")]
        public async Task<IActionResult> AddProvider(CreateProvidersRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await providerService.AddProvider(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
