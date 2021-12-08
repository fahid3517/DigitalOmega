using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Order;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

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
                                    //Gender = request.Gender,
                                    PhoneCode = request.PhoneCode,
                                    PhoneNumber = request.PhoneNumber,
                                    Agent = request.Agent,
                                    Provider = request.Provider,
                                    PreviousProvider = request.PreviousProvider,
                                    CustDateTime = DateTime.Now,
                                    //Campaign = request.Campaign,
                                    //QueGroup = request.QueGroup,
                                    //PhoneLogin = request.PhoneLogin,
                                    //DialedLabel = request.DialedLabel,
                                    //CallId = request.CallId,
                                    //LeadId = request.LeadId,
                                    //ListId = request.ListId,
                                    //UserGroup = request.UserGroup,
                                    //Channel = request.Channel,
                                    //DispoStatus = request.DispoStatus,
                                    //CallbackDatetime = DateTime.Now,
                                    //CallbackType = request.CallbackType,
                                    //CallbackComments = request.CallbackComments,
                                    //CallChannel = request.CallChannel,
                                    AltPhone = request.AltPhone,
                                    //Street = request.Street,
                                    //Appartment = request.Appartment,
                                    Address1 = request.Address1,
                                    PostalCode = request.PostalCode,
                                    Address2 = request.Address2,
                                    AccountNumber = request.AccountNumber,
                                    City = request.City,
                                    State = request.State,
                                    Email = request.Email,
                                    //VendorLeadCode = request.VendorLeadCode,
                                    Comments = request.Comments,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = userId.ToString(),

                                }); ; ;
                                await db.SaveChangesAsync();


                                Guid OrderId = SystemGlobal.GetId();

                                await db.Orders.AddAsync(new Order
                                {

                                    OrderId = OrderId,
                                    CustId = CustID,
                                    // Mso=request.order.Mso,
                                    AgentId = request.order.AgentId,
                                    Agent = request.order.Agent,
                                    //SaleTechCode=request.order.SaleTechCode,
                                    Provider = request.order.Provider,
                                    Affiliate = request.order.Affiliate,
                                    AccountNumber = request.order.AccountNumber,
                                    Btn = request.order.Btn,
                                    WorkOrderNumber = request.order.WorkOrderNumber,
                                    OrderConfirmationNumber = request.order.OrderConfirmationNumber,
                                    PaymentType = request.order.PaymentType,
                                    SaleDate = request.order.SaleDate,
                                    InstallationType = request.order.InstallationType,
                                    OrderInstallationDate = request.order.OrderInstallationDate,
                                    OrderInstallationTime = request.order.OrderInstallationTime,
                                    //ActualInstallationDate=request.order.ActualInstallationDate,
                                    //FiscalMonth=request.order.FiscalMonth,
                                    //DisconnectDate=request.order.DisconnectDate,
                                    SaleSource = request.order.SaleSource,
                                    //OrderStatus=request.order.OrderStatus,
                                    Comments = request.order.Comments,

                                    CreatedAt = DateTime.Now,
                                    CreatedBy = userId.ToString(),
                                });
                                await db.SaveChangesAsync();
                                //var id = db.Orders.LastOrDefault();

                                string separator = ", ";
                                var PortedHomePhoneNumbers = "";
                                var NativeHomePhoneNumbers = "";
                                var PortedMobileNumbers = "";
                                var NativeMobileNumbers = "";
                                if (request.order.PackageDetail.PortedHomePhoneNumbers != null)
                                {
                                    foreach (var item in request.order.PackageDetail.PortedHomePhoneNumbers)
                                    {
                                        PortedHomePhoneNumbers += item.Phone + separator;
                                    }
                                }
                                if (request.order.PackageDetail.NativeHomePhoneNumbers != null)
                                {
                                    foreach (var item in request.order.PackageDetail.NativeHomePhoneNumbers)
                                    {
                                        NativeHomePhoneNumbers += item.Phone + separator;
                                    }
                                }
                                if (request.order.PackageDetail.PortedMobileNumbers != null)
                                {
                                    foreach (var item in request.order.PackageDetail.PortedMobileNumbers)
                                    {
                                        PortedMobileNumbers += item.Phone + separator;
                                    }
                                }
                                if (request.order.PackageDetail.NativeMobileNumbers != null)
                                {
                                    foreach (var item in request.order.PackageDetail.NativeMobileNumbers)
                                    {
                                        NativeMobileNumbers += item.Phone + separator;
                                    }
                                }
                                await db.OrderPakageDetails.AddAsync(new OrderPakageDetail
                                {

                                    OrderGId = OrderId,
                                    //Mso = request.Mso,
                                    Pakage = request.order.PackageDetail.Pakage,
                                    Psus = request.order.PackageDetail.Psus,
                                    Dvr = request.order.PackageDetail.Dvr,
                                    Box = request.order.PackageDetail.Box,
                                    Modem = request.order.PackageDetail.Modem,
                                    Wifi = request.order.PackageDetail.Wifi,
                                    PortedHomePhone = request.order.PackageDetail.PortedHomePhone,
                                    // value =request.order.PackageDetail.PortedHomePhoneNumbers,
                                    PortedHomePhoneNumbers = PortedHomePhoneNumbers,
                                    NativeHomePhone = request.order.PackageDetail.NativeHomePhone,
                                    NativeHomePhoneNumbers = NativeHomePhoneNumbers,
                                    PortedMobile = request.order.PackageDetail.PortedMobile,
                                    PortedMobileNumbers = PortedMobileNumbers,
                                    NativeMobile = request.order.PackageDetail.NativeMobile,
                                    NativeMobileNumbers = NativeMobileNumbers,
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

        public GetOrderResponse GetOrder(ListOrderModel page)
        {
            try
            {
                GetOrderResponse response = new GetOrderResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Orders.Where(x => x.SaleDate >= page.FromDate.Value.Date && x.SaleDate <= page.ToDate.Value.Date).Select(s => new Order
                    {
                        Id = s.Id,
                        OrderId = s.OrderId,
                         Mso=s.Mso,
                        AgentId = s.AgentId,
                        Agent = s.Agent,
                        SaleTechCode=s.SaleTechCode,
                        Provider = s.Provider,
                        Affiliate = s.Affiliate,
                        AccountNumber = s.AccountNumber,
                        Btn = s.Btn,
                        WorkOrderNumber = s.WorkOrderNumber,
                        OrderConfirmationNumber = s.OrderConfirmationNumber,
                        PaymentType = s.PaymentType,
                        SaleDate = s.SaleDate,
                        InstallationType = s.InstallationType,
                        OrderInstallationDate = s.OrderInstallationDate,
                        OrderInstallationTime = s.OrderInstallationTime,
                        ActualInstallationDate=s.ActualInstallationDate,
                        FiscalMonth=s.FiscalMonth,
                        DisconnectDate=s.DisconnectDate,
                        SaleSource = s.SaleSource,
                        OrderStatus=s.OrderStatus,
                        Comments =s.Comments,

                        CreatedAt = s.CreatedAt,
                        CreatedBy = s.CreatedBy

                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Agent.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.Agent);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Agent) : query.OrderBy(x => x.Agent);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Orders = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> GetOrderByID(Guid? orderId)
        {
            if (db != null)
            {
                return await db.Orders.Where(x => x.OrderId == orderId).Select(s => new Order
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    Mso = s.Mso,
                    AgentId = s.AgentId,
                    Agent = s.Agent,
                    SaleTechCode = s.SaleTechCode,
                    Provider = s.Provider,
                    Affiliate = s.Affiliate,
                    AccountNumber = s.AccountNumber,
                    Btn = s.Btn,
                    WorkOrderNumber = s.WorkOrderNumber,
                    OrderConfirmationNumber = s.OrderConfirmationNumber,
                    PaymentType = s.PaymentType,
                    SaleDate = s.SaleDate,
                    InstallationType = s.InstallationType,
                    OrderInstallationDate = s.OrderInstallationDate,
                    OrderInstallationTime = s.OrderInstallationTime,
                    ActualInstallationDate = s.ActualInstallationDate,
                    FiscalMonth = s.FiscalMonth,
                    DisconnectDate = s.DisconnectDate,
                    SaleSource = s.SaleSource,
                    OrderStatus = s.OrderStatus,
                    Comments = s.Comments,

                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy

                }).FirstOrDefaultAsync();
            }

            return null;
        }
        public async Task<Order> GetOrderByAffiliate(string? affiliate)
        {
            if (db != null)
            {
                return await db.Orders.Where(x => x.Affiliate == affiliate).Select(s => new Order
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    Mso = s.Mso,
                    AgentId = s.AgentId,
                    Agent = s.Agent,
                    SaleTechCode = s.SaleTechCode,
                    Provider = s.Provider,
                    Affiliate = s.Affiliate,
                    AccountNumber = s.AccountNumber,
                    Btn = s.Btn,
                    WorkOrderNumber = s.WorkOrderNumber,
                    OrderConfirmationNumber = s.OrderConfirmationNumber,
                    PaymentType = s.PaymentType,
                    SaleDate = s.SaleDate,
                    InstallationType = s.InstallationType,
                    OrderInstallationDate = s.OrderInstallationDate,
                    OrderInstallationTime = s.OrderInstallationTime,
                    ActualInstallationDate = s.ActualInstallationDate,
                    FiscalMonth = s.FiscalMonth,
                    DisconnectDate = s.DisconnectDate,
                    SaleSource = s.SaleSource,
                    OrderStatus = s.OrderStatus,
                    Comments = s.Comments,

                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy

                }).FirstOrDefaultAsync();
            }

            return null;
        }
        public async Task<Order> GetOrderByAgentId(string? AgentId)
        {
            if (db != null)
            {
                return await db.Orders.Where(x => x.AgentId == AgentId).Select(s => new Order
                {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    Mso = s.Mso,
                    AgentId = s.AgentId,
                    Agent = s.Agent,
                    SaleTechCode = s.SaleTechCode,
                    Provider = s.Provider,
                    Affiliate = s.Affiliate,
                    AccountNumber = s.AccountNumber,
                    Btn = s.Btn,
                    WorkOrderNumber = s.WorkOrderNumber,
                    OrderConfirmationNumber = s.OrderConfirmationNumber,
                    PaymentType = s.PaymentType,
                    SaleDate = s.SaleDate,
                    InstallationType = s.InstallationType,
                    OrderInstallationDate = s.OrderInstallationDate,
                    OrderInstallationTime = s.OrderInstallationTime,
                    ActualInstallationDate = s.ActualInstallationDate,
                    FiscalMonth = s.FiscalMonth,
                    DisconnectDate = s.DisconnectDate,
                    SaleSource = s.SaleSource,
                    OrderStatus = s.OrderStatus,
                    Comments = s.Comments,

                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy

                }).FirstOrDefaultAsync();
            }

            return null;
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
