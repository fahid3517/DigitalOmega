using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Affiliate;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        private readonly IAffiliateService affiliateService;
        private readonly IConfiguration configuration;
        public AffiliateController(IAffiliateService _affiliateService, IConfiguration configuration)
        {
            this.affiliateService = _affiliateService;
            this.configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetAffiliateList")]
        public IActionResult GetAffiliateList(ListGeneralModel page)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK, new Response<GetAffiliateResponse>() { IsError = false, Message = "", Data = affiliateService.GetAffiliate(page) });
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
        [Route("GetAffiliateByID")]
        public async Task<IActionResult> GetAffiliateByID(Guid? affiliateId)
        {
            if (affiliateId == null)
            {
                return BadRequest();
            }

            try
            {
                var dispositon = await affiliateService.GetAffiliateByID(affiliateId);

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
        [Route("SaveAffiliate")]
        public async Task<IActionResult> SaveAffiliate(CreateAffiliateRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
                // var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await affiliateService.AddAffiliate(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
