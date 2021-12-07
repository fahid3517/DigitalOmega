using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DataViewModels.Enum;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
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
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetProviders")]
        public async Task<IActionResult> Getproviders(ListGeneralModel page)
        {
            try
            {
                var agents = StatusCode(StatusCodes.Status200OK, new { IsError = false, Message = "", Data = providerService.GetProvider(page) });

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
        public async Task<IActionResult> GetProviderByID(Guid? providerId)
        {
            if (providerId == null)
            {
                return BadRequest();
            }

            try
            {
                var agent = await providerService.GetProviderByID(providerId);

                if (agent == null)
                {
                    return NotFound();
                }

                return Ok(agent);
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
      //  [AdminAuthorize(ERight.SuperAdmin)]
        [Route("SaveProvider")]
        public async Task<IActionResult> SaveProvider(CreateProvidersRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
                // var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await providerService.AddProvider(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
