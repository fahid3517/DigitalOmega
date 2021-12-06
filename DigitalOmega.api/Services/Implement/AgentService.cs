using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Agent;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class AgentService : IAgentService
    {
        do_insightContext db;
        public AgentService(do_insightContext _db)
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
                    using (var db = new do_insightContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                await db.Agents.AddAsync(new Agent
                                {

                                    GId = SystemGlobal.GetId(),
                                    AgentName = request.AgentName,
                                    UserId = request.UserId,
                                    Affiliate = request.Affiliate,
                                    AgentId = request.AgentId,
                                    RealName = request.RealName,
                                    Live=0,
                                    LiveDate=DateTime.Now,
                                    DialerId=request.DialerId,
                                    Active=1,
                                    CreatedAt=DateTime.Now,
                                    CreatedBy=userId.ToString(),
                                   DeactivatedAt=DateTime.Now,
                                   DeactivatedBy=userId.ToString(), 
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

                                agent.UserId = request.UserId;
                                agent.AgentName = request.AgentName;
                                agent.Affiliate = request.Affiliate;
                                agent.AgentId = request.AgentId;
                                agent.RealName = request.RealName;
                                //agent.Live = request.Live;
                                agent.LiveDate = DateTime.Now;
                                agent.DialerId = request.DialerId;
                                agent.Active = request.Active;
                                agent.DeactivatedAt = DateTime.Now;
                                agent.DeactivatedBy = userId.ToString();
                                agent.GId = request.GId;
                               
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

        public async Task<Agent> GetAgentByID(Guid? agentId)
        {
            if (db != null)
            {
                return await db.Agents.Where(x=>x.GId == agentId).Select(x => new Agent
                             {
                                 Id = x.Id,
                                 AgentName = x.AgentName,
                                 UserId = x.UserId,
                                 Affiliate = x.Affiliate,
                                 AgentId=x.AgentId,
                                 RealName = x.RealName,
                                 Live=x.Live,
                                 LiveDate=x.LiveDate,
                                 DialerId=x.DialerId,
                                 Active=x.Active,
                                 GId = x.GId,
                                 
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async  Task UpdatePost(DTOs.Agent post)
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

                using (var db = new do_insightContext())
                {
                    var query = db.Agents
                        .Select(x => new CreateAgentsRequest
                        {
                            Id = x.Id,
                            AgentId = x.AgentId,
                            UserId = x.UserId,
                            AgentName = x.AgentName,
                            Affiliate = x.Affiliate,
                            GId = x.GId,
                            Live = x.Live,
                            DialerId = x.DialerId,
                            
                           
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
                        case 2:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.AgentId) : query.OrderBy(x => x.AgentId);
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
