using DigitalOmega.api.Common;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Agent;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class AgentService : IAgentService
    {
        D_OContext db;
        public AgentService(D_OContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddAgent(CreateAgentsRequest request,Guid userId)
        {
            try
            {
                bool response = false;

                if (request.Id == null)
                {
                    // createnew
                    using (var db = new D_OContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                await db.Agents.AddAsync(new Models.Agent
                                {

                                    Id = SystemGlobal.GetId(),
                                    AgentName = request.AgentName,
                                    UserId = request.UserId,
                                    Affiliate = request.Affiliate,
                                   
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
                    using (var db = new D_OContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var agent = db.Agents.Find(request.Id);

                                if (agent == null) throw new Exception("Agent Not Found");

                                agent.UserId = request.UserId;
                                agent.AgentName = request.AgentName;
                                agent.Affiliate = request.Affiliate;
                               
                                db.Entry(agent).State = EntityState.Modified;
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

        public Task<int> DeletePost(int? postId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Agent>> GetAgents()
        {
            if (db != null)
            {
                return await db.Agents.ToListAsync();
            }

            return null;
        }

        public async Task<Agent> GetAgentByID(Guid? postId)
        {
            if (db != null)
            {
                return await(from a in db.Agents
                             from u in db.Users
                             where a.Id == postId
                             select new Agent
                             {
                                 Id = a.Id,
                                 AgentName = a.AgentName,
                                 UserId = a.UserId,
                                 Affiliate = a.Affiliate
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async  Task UpdatePost(Agent post)
        {
            if (db != null)
            {
                //Delete that post
                db.Agents.Update(post);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public GetAgentsResponse GetAgent(ListGeneralModel page)
        {
            try
            {
                GetAgentsResponse response = new GetAgentsResponse();

                using (var db = new D_OContext())
                {
                    var query = db.Agents
                        .Select(x => new CreateAgentsRequest
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            AgentName = x.AgentName,
                            Affiliate = x.Affiliate,
                           
                        })
                      .AsQueryable();
                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.AgentName.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.AgentName);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.AgentName) : query.OrderBy(x => x.AgentName);
                            break;
                        case 1:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Affiliate) : query.OrderBy(x => x.Affiliate);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Agents = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();

                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
