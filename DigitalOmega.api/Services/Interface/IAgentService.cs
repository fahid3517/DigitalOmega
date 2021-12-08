using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Agent;

namespace DigitalOmega.api.Services.Interface
{
    public interface IAgentService
    {

        Task<List<Agent>> GetAgents();
        GetAgentsResponse GetAgent(ListGeneralModel page);


        Task<Agent> GetAgentByID(Guid? AgentId);

        Task<Agent> GetAgentByAffiliate(string? affiliate);

        // Task<bool> AddAgent(Agent agent);
        Task<bool> AddAgent(CreateAgentsRequest request, Guid userId);

        Task<int> DeletePost(int? postId);

        Task UpdatePost(Agent post);
    }
}
