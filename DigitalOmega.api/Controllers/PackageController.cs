using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DataViewModels.Enum;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Packages;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;
        private readonly IConfiguration configuration;
        public PackageController(IPackageService _packageService, IConfiguration configuration)
        {
            this.packageService = _packageService;
            this.configuration = configuration;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetPackages")]
        public async Task<IActionResult> GetPackages(ListGeneralModel page)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status200OK, new Response<GetPackgesResponse>() { IsError = false, Message = "", Data = packageService.GetPackage(page) });
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
        [Route("GetPackageByID")]
        public async Task<IActionResult> GetPackageByID(Guid? packageId)
        {
            if (packageId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await packageService.GetPackageByID(packageId);

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
       // [AdminAuthorize(ERight.SuperAdmin)]
        [Route("SavePackage")]
        public async Task<IActionResult> SavePackage(CreatePackagesRequest request)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId =Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
                //var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await packageService.AddPackage(request, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
