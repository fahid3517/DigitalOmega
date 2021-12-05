using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Agent;

namespace DigitalOmega.api.Services.Interface
{
    public interface IAgentService
    {

        Task<List<Agent>> GetAgents();
        GetAgentsResponse GetAgent(ListGeneralModel page);


        Task<Agent> GetAgentByID(Guid? postId);

       // Task<bool> AddAgent(Agent agent);
        Task<bool> AddAgent(CreateAgentsRequest request, Guid userId);

        Task<int> DeletePost(int? postId);

        Task UpdatePost(Agent post);
    }
}
