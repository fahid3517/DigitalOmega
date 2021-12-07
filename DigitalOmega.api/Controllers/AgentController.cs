using DigitalOmega.api.Common;
using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DataViewModels.Enum;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.ModelsData;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Agent;
using DigitalOmega.api.Services.Implement;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOmega.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService agentService;
        private readonly IConfiguration configuration;
        public AgentController(IAgentService _agentService, IConfiguration configuration)
        {
            this.agentService = _agentService;
            this.configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("GetAgents")]
        public async Task<IActionResult> GetAgents(ListGeneralModel page)
        {
            try
            {
                
                    if (!ModelState.IsValid)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                    }

                return StatusCode(StatusCodes.Status200OK, new Response<GetAgentsResponse>() { IsError = false, Message = "", Data = agentService.GetAgent(page) });
                // return StatusCode(StatusCodes.Status200OK, new Response<List<Agent>>() { IsError = false, Message = "", Data = agentService() });

                //var agents = await agentService.GetAgents();
                //if (agents == null)
                //{
                //    return NotFound();
                //}

                //return Ok(agents);
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
        [Route("GetAgentByID")]
        public async Task<IActionResult> GetAgentByID(Guid? agentId)
        {
            if (agentId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await agentService.GetAgentByID(agentId);

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
        [Route("SaveAgent")]
        public async Task<IActionResult> SaveAgent(CreateAgentsRequest request)
        {
 

            try
            {

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(v => v.Errors.Select(z => z.ErrorMessage)));
                }
                var userId = Guid.Parse("d1a258a4-8a4f-4883-8213-f35ee31e8717");
                // var userId = Guid.Parse(RouteData.Values["userId"].ToString());

                return StatusCode(StatusCodes.Status200OK, new Response<bool>() { IsError = false, Message = "", Data = await agentService.AddAgent(request, userId) });
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
        [Route("DeleteAgent")]
        public async Task<IActionResult> DeleteAgent(int? postId)
        {
            int result = 0;

            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await agentService.DeletePost(postId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("UpdateAgent")]
        public async Task<IActionResult> UpdateAgen([FromBody] Agent model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await agentService.UpdatePost(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}
