using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Order;
using DigitalOmega.api.Services.Interface;

namespace DigitalOmega.api.Services.Implement
{
    public class OrderSerivce : IOrderService
    {
        do_insightContext db;
        
        public OrderSerivce(do_insightContext _db)
        {
            db = _db;
        }
        
        public async Task<bool> AddOrder(CreateCustomerRequest request, Guid userId)
        {
            try
            {
                bool response = false;

                if (request.Id == null)
                {
                    // createnew
                    using (var db = new do_insightContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                Guid CustID = SystemGlobal.GetId();
                                await db.Customers.AddAsync(new Customer
                                {

                                    CusId = CustID,


                                    Title = request.Title,
                                    FirstName = request.FirstName,
                                    MiddleInitial = request.MiddleInitial,
                                    LastName = request.LastName,
                                    Gender = request.Gender,
                                    PhoneCode = request.PhoneCode,
                                    PhoneNumber = request.PhoneNumber,
                                    Agent = request.Agent,
                                    Provider = request.Provider,
                                    PreviousProvider = request.PreviousProvider,
                                    CustDateTime = DateTime.Now,
                                    Campaign = request.Campaign,
                                    QueGroup = request.QueGroup,
                                    PhoneLogin = request.PhoneLogin,
                                    DialedLabel = request.DialedLabel,
                                    CallId = request.CallId,
                                    LeadId = request.LeadId,
                                    ListId = request.ListId,
                                    UserGroup = request.UserGroup,
                                    Channel = request.Channel,
                                    DispoStatus = request.DispoStatus,
                                    CallbackDatetime = DateTime.Now,
                                    CallbackType = request.CallbackType,
                                    CallbackComments = request.CallbackComments,
                                    CallChannel = request.CallChannel,
                                    AltPhone = request.AltPhone,
                                    Street = request.Street,
                                    Appartment = request.Appartment,
                                    Address1 = request.Address1,
                                    PostalCode = request.PostalCode,
                                    Address2 = request.Address2,
                                    AccountNumber = request.AccountNumber,
                                    City = request.City,
                                    State = request.State,
                                    Email = request.Email,
                                    VendorLeadCode = request.VendorLeadCode,
                                    Comments = request.Comments,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = userId.ToString(),

                                }); ; ;
                               await db.SaveChangesAsync();
                                

                                Guid OrderId = SystemGlobal.GetId();

                                await db.Orders.AddAsync(new Order
                                {

                                    OrderId = OrderId,
                                    CustId =CustID,
                                    Mso=request.order.Mso,
                                    AgentId=request.order.AgentId,
                                    Agent= request.order.Agent,
                                    SaleTechCode=request.order.SaleTechCode,
                                    Provider=request.order.Provider,
                                    Affiliate=request.order.Affiliate,
                                    AccountNumber=request.order.AccountNumber,
                                    Btn=request.order.Btn,
                                    WorkOrderNumber=request.order.WorkOrderNumber,
                                    OrderConfirmationNumber=request.order.OrderConfirmationNumber,
                                    PaymentType=request.order.PaymentType,
                                    SaleDate=request.order.SaleDate,
                                    InstallationType=request.order.InstallationType,
                                    OrderInstallationDate=request.order.OrderInstallationDate,
                                    OrderInstallationTime=request.order.OrderInstallationTime,
                                    ActualInstallationDate=request.order.ActualInstallationDate,
                                    FiscalMonth=request.order.FiscalMonth,
                                    DisconnectDate=request.order.DisconnectDate,
                                    SaleSource=request.order.SaleSource,
                                    OrderStatus=request.order.OrderStatus,
                                    Comments=request.order.Comments,
                                    
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = userId.ToString(),
                                });
                                await db.SaveChangesAsync();
                                //var id = db.Orders.LastOrDefault();

                                await db.OrderPakageDetails.AddAsync(new OrderPakageDetail
                                {

                                    //OrderId = request.PackageDetail.OrderId,
                                    //CustId = CustID,
                                    //Mso = request.Mso,
                                    //AgentId = request.AgentId,
                                    //Agent = request.Agent,
                                    //SaleTechCode = request.SaleTechCode,
                                    //Provider = request.Provider,
                                    //Affiliate = request.Affiliate,
                                    //AccountNumber = request.AccountNumber,
                                    //Btn = request.Btn,
                                    //WorkOrderNumber = request.WorkOrderNumber,
                                    //OrderConfirmationNumber = request.OrderConfirmationNumber,
                                    //PaymentType = request.PaymentType,
                                    //SaleDate = request.SaleDate,
                                    //InstallationType = request.InstallationType,
                                    //OrderInstallationDate = request.OrderInstallationDate,
                                    //OrderInstallationTime = request.OrderInstallationTime,
                                    //ActualInstallationDate = request.ActualInstallationDate,
                                    //FiscalMonth = request.FiscalMonth,
                                    //DisconnectDate = request.DisconnectDate,
                                    //SaleSource = request.SaleSource,
                                    //OrderStatus = request.OrderStatus,
                                    //Comments = request.Comments,
                                    //CreatedAt = DateTime.Now,
                                    //CreatedBy = userId.ToString(),
                                });
                                await db.SaveChangesAsync();



                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    using (var db = new do_insightContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var agent = db.Agents.Find(request.Id);

                                if (agent == null) throw new Exception("Agent Not Found");

                                //agent.UserId = request.UserId;
                                //agent.AgentName = request.AgentName;
                                //agent.Affiliate = request.Affiliate;
                                //agent.AgentId = request.AgentId;
                                //agent.RealName = request.RealName;
                                ////agent.Live = request.Live;
                                //agent.LiveDate = DateTime.Now;
                                //agent.DialerId = request.DialerId;
                                //agent.Active = request.Active;
                                //agent.DeactivatedAt = DateTime.Now;
                                //agent.DeactivatedBy = userId.ToString();
                                //agent.GId = request.GId;

                                //db.Entry(agent).State = EntityState.Modified;
                                await db.SaveChangesAsync();

                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteOrder(int? postId)
        {
            throw new NotImplementedException();
        }

        public GetOrderResponse GetOrder(ListGeneralModel page)
        {
            throw new NotImplementedException();
        }

        public Task<Agent> GetOrderByID(Guid? orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
