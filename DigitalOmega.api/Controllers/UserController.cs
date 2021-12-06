using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DigitalOmega.api.Common;
using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.Interface;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.DataViewModels.Enum;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService usersService;
        private readonly IConfiguration configuration;

        public UserController(IUserService usersService, IConfiguration configuration)
        {
            this.usersService = usersService;
            this.configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<LoginResponse>), 200)]
        [ProducesResponseType(typeof(Response<LoginResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
        [Route("adminlogin")]
        public IActionResult AdminLogin(LoginRequest login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                var res = usersService.AdminLogin(login);

                if (res.Item3)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.AccountBlocked, Data = new LoginResponse() });
                }

                if (res.Item2)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response<LoginResponse>() { IsError = false, Message = "", Data = res.Item1 });
                }

                return StatusCode(StatusCodes.Status403Forbidden, new Response<LoginResponse>() { IsError = true, Message = Error.LoginFailed, Data = new LoginResponse() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<GetUsersResponse>), 200)]
        [ProducesResponseType(typeof(Response<GetUsersResponse>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
       // [AdminAuthorize(ERight.UserManagement)]
        [HttpPost]
        [Route("getusers")]
        public IActionResult GetUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }

                return StatusCode(StatusCodes.Status403Forbidden, new Response<GetUsersResponse>() { IsError = false, Message = "", Data = usersService.GetUsers() });
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
        [ProducesResponseType(typeof(Response<bool>), 200)]
        [ProducesResponseType(typeof(Response<bool>), 403)]
        [ProducesResponseType(typeof(string[]), 400)]
       // [AdminAuthorize(ERight.UserManagement)]
        [Route("saveuser")]
        public async Task<IActionResult> SaveUser([FromForm] CreateUserRequest createUser)
        {
            try
            {
               // FileUrlResponce file = new FileUrlResponce();

               // createUser.ProfileImage = JsonConvert.DeserializeObject<FileUrlResponce>(Request.Form["profileImage"]);

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.NewGuid();

               // var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                //if (profileImage != null && profileImage.Length > 0)
                //{
                //    file = await new SaveFiles().SendMyFileToS3(profileImage, configuration.GetValue<string>("Amazon:Bucket"), "ProfilePicture", false, configuration.GetValue<string>("Amazon:AccessKey"), configuration.GetValue<string>("Amazon:AccessSecret"), configuration.GetValue<string>("Amazon:BaseUrl"));

                //    createUser.ProfileImage = file;
                //}

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await usersService.SaveUser(createUser, userId) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Response<CreateUserRequest>), 200)]
        [ProducesResponseType(typeof(Response<CreateUserRequest>), 403)]
       // [AdminAuthorize(ERight.UserManagement)]
        [HttpGet]
        [Route("getedituser/{id}")]
        public IActionResult GetEditUser(Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new Response<CreateUserRequest>() { IsError = false, Message = "", Data = usersService.GetEditUser(id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (var context = new D_OContext())
            {
                return  context.Users.ToList();
            }
        }
    }
}
