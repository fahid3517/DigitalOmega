using DigitalOmega.api.Common;
using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class UsersService : IUserService
    {
        private readonly IConfiguration configuration;

        public UsersService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Tuple<LoginResponse, bool, bool> AdminLogin(LoginRequest request)
        {
            string encryptionKey = configuration.GetValue<string>("EncryptionKey"), tokenKey = configuration.GetValue<string>("Tokens:Key");

            try
            {
                var encryptedPassword = new Encryption().Encrypt(request.Password, encryptionKey);
                var response = new LoginResponse();
                bool isLogin = false,
                    isBlock = false;

                using (var db = new do_insightContext())
                {
                    var user = db.Users
                        .FirstOrDefault(x => x.UserId.ToLower().Equals(request.UserInfo.ToLower()) && x.Password.Equals(encryptedPassword));

                    if (user == null) return Tuple.Create(response, isLogin, isBlock);
                   // isBlock = user.IsBlocked;
                    if (isBlock) return Tuple.Create(response, isLogin, isBlock);

                    var authToken = new Encryption().GetToken(new AdminAuthToken { UserId = user.GId }, user.GId, tokenKey);

                    response = new LoginResponse
                    {
                        AccessToken = authToken,
                    };
                    isLogin = true;
                    return Tuple.Create(response, isLogin, isBlock);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CreateUserRequest GetEditUser(Guid userId)
        {
            try
            {
                using (var db = new do_insightContext())
                {
                    return db.Users
                        .Where(x => x.Id.Equals(userId))
                        .Select(x => new CreateUserRequest
                        {
                            Id = x.Id,
                            Name = x.Name,
                          
                            UserId = x.UserId,
                            Password = "***********",
                            Role = x.Role,
                            CreatedAt = DateTime.Now,  
                            CreatedBy= x.CreatedBy,
                            DeactivatedAt = DateTime.Now,
                            DeactivatedBy= x.DeactivatedBy,
                             Active = x.Active,
                            // GenderId = x.GenderId,
                            // GenderName = x.Gender.Name,
                           // RoleId = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).RoleId,
                           // RoleName = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).Role.Name,
                            //ProfileImage = new FileUrlResponce
                            //{
                            //    URL = x.ImageUrl,
                            //    ThumbnailbUrl = x.ImageThumbnailUrl
                            //}
                        })
                        .FirstOrDefault() ?? throw new Exception("User Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetUsersResponse GetUsers()
        {
            try
            {
                GetUsersResponse response = new GetUsersResponse();

                using (var db = new do_insightContext())
                {
                    var query = db.Users
                        .Select(x => new CreateUserRequest
                        {
                            Id = x.Id,
                            Name = x.Name,

                            UserId = x.UserId,
                            Password = "***********",
                            Role = x.Role,
                            CreatedAt = DateTime.Now,
                            CreatedBy = x.CreatedBy,
                            DeactivatedAt = DateTime.Now,
                            DeactivatedBy = x.DeactivatedBy,
                            GId = x.GId,
                            // GenderId = x.GenderId,
                            // GenderName = x.Gender.Name,
                            // RoleId = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).RoleId,
                            // RoleName = x.AdminUserRoles.FirstOrDefault(y => y.IsEnabled).Role.Name,
                            //ProfileImage = new FileUrlResponce
                            //{
                            //    URL = x.ImageUrl,
                            //    ThumbnailbUrl = x.ImageThumbnailUrl
                            //}
                        })
                      .AsQueryable();

                    //if (!string.IsNullOrEmpty(page.Search))
                    //{
                    //    var date = new DateTime();
                    //    var sdate = DateTime.TryParse(page.Search, out date);
                    //    int totalCases = -1;
                    //    var isNumber = Int32.TryParse(page.Search, out totalCases);

                    //    query = query.Where(
                    //    x => x.Name.ToLower().Contains(page.Search.ToLower())
                    //);
                   // }

                    //var orderedQuery = query.OrderByDescending(x => x.Name);
                    //switch (page.SortIndex)
                    //{
                    //    case 0:
                    //        orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                    //        break;
                       
                    //    case 1:
                    //        orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Email) : query.OrderBy(x => x.Email);
                    //        break;
                      
                    //}


                    //response.Page = page.Page;
                    //response.PageSize = page.PageSize;
                    //response.TotalRecords = orderedQuery.Count();
                    //response.Users = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveUser(CreateUserRequest createUser, Guid userId)
        {
            try
            {
                bool response = false;

               // List<AdminUserRoles> userRoles = new List<AdminUserRoles>();

                //userRoles.Add(new AdminUserRoles
                //{
                //    Id = SystemGlobal.GetId(),
                //    RoleId = createUser.RoleId,
                //    IsEnabled = true,
                //    CreatedBy = userId.ToString(),
                //    CreatedOn = DateTime.UtcNow,
                //    CreatedOnDate = DateTime.UtcNow
                //});

                if (createUser.Id == null)
                {
                    var encryptedPassword = new Encryption().Encrypt(createUser.Password, configuration.GetValue<string>("EncryptionKey"));

                    using (var db = new do_insightContext())
                    {
                        if (db.Users.Any(x => x.UserId.ToLower().Equals(createUser.UserId.ToLower()))) throw new Exception("Email Already Exists");

                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                await db.Users.AddAsync(new DTOs.User
                                {
                                    GId = SystemGlobal.GetId(),
                                    Name = createUser.Name,
                                    UserId = createUser.UserId,
                                    Password = encryptedPassword,
                                    Role = createUser.Role,
                                    Active =    createUser.Active,
                                    CreatedBy = createUser.CreatedBy,
                                    CreatedAt =DateTime.Now,
                                    DeactivatedAt = DateTime.Now,
                                    DeactivatedBy = userId.ToString(),
                                   
                                    //GenderId = createUser.GenderId,
                                  
                                    //AdminUserRoles = userRoles,
                                
                                 
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
                                var user = db.Users.Find(createUser.Id);

                                if (user == null) throw new Exception("User Not Found");

                                //delete Old One
                              //  await db.AdminUserRoles.Where(x => x.IsEnabled && x.AdminUserId.Equals(user.Id)).ForEachAsync(x => { x.IsEnabled = false; x.DeletedBy = userId.ToString(); x.DeletedOn = DateTime.UtcNow; });
                                await db.SaveChangesAsync();

                                user.Name = createUser.Name;
                                user.UserId = createUser.UserId;
                                user.CreatedBy = userId.ToString();
                                //user.UpdatedOn = DateTime.UtcNow;

                                db.Entry(user).State = EntityState.Modified;
                                await db.SaveChangesAsync();

                                //userRoles.ForEach(x => x.AdminUserId = user.Id);
                                //await db.AdminUserRoles.AddRangeAsync(userRoles);
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
    }
}
