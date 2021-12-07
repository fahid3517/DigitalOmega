using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DataViewModels.Enum;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.IP;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private readonly IIPService ipService;
        private readonly IConfiguration configuration;
        public IPController(IIPService _ipService, IConfiguration configuration)
        {
            this.ipService = _ipService;
            this.configuration = configuration;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetIPList")]
        public  IActionResult GetIPList(ListGeneralModel page)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK, new Response<GetIPResponse>() { IsError = false, Message = "", Data = ipService.GetIP(page) });
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
        [Route("GetIPByID")]
        public async Task<IActionResult> GetIPByID(Guid? ipId)
        {
            if (ipId == null)
            {
                return BadRequest();
            }

            try
            {
                var dispositon = await ipService.GetIPByID(ipId);

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
        [Route("SaveIP")]
        public async Task<IActionResult> SaveIP(CreateIPsRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
               // var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await ipService.AddIP(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
