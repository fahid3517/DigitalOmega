using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Order;

namespace DigitalOmega.api.Services.Interface
{
    public interface IOrderService
    {

        Task<List<Order>> GetOrders();
        GetOrderResponse GetOrder(ListOrderModel page);


        Task<Order> GetOrderByID(Guid? orderId);

        Task<Order> GetOrderByAffiliate(string? affiliate);

        Task<Order> GetOrderByAgentId(string? AgentId);

        // Task<bool> AddAgent(Agent agent);
        Task<bool> AddOrder(CreateCustomerRequest request, Guid userId);

        Task<int> DeleteOrder(int? postId);

        Task UpdatePost(Order order);
    }
}
