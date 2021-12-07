using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Packages;
using DigitalOmega.api.Response.Provider;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class PackageService : IPackageService
    {
        do_insightContext db;
        public PackageService(do_insightContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddPackage(CreatePackagesRequest request, Guid userId)
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
                                await db.Packages.AddAsync(new Package
                                {
                                   
                                    GId = SystemGlobal.GetId(),
                                    Name = request.Name,
                                    Abbreviation = request.Abbreviation,
                                    Psus = request.PSUs,
                                    Dvr  = request.Dvr,
                                    Box = request.Box,
                                    Modem = request.Modem,
                                    Wifi = request.Wifi,
                                    PortedHomePhone=request.PortedHomePhone,
                                    NativeHomePhone=request.NativeHomePhone,
                                    PortedMobile=request.PortedMobile,
                                    NativeMobile=request.NativeMobile,
                                    CreatedAt= DateTime.Now,
                                    CreatedBy=userId.ToString(),
                                    Active=1,   

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
                                var package = db.Packages.Find(request.Id);

                                if (package == null) throw new Exception("Package Not Found");
                                package.GId= request.GId;
                                package.Name = request.Name;
                                package.Abbreviation = request.Abbreviation;
                                package.Psus = request.PSUs;
                                package.Dvr = request.Dvr;
                                package.Box = request.Box;
                                package.Modem = request.Modem;
                                package.Wifi = request.Wifi;
                                package.PortedHomePhone = request.PortedHomePhone;
                                package.NativeHomePhone = request.NativeHomePhone;
                                package.PortedMobile = request.PortedMobile;
                                package.NativeMobile = request.NativeMobile;
                                package.DeactivatedAt = DateTime.Now;
                                package.DeactivatedBy = userId.ToString();
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

        public GetPackgesResponse GetPackage(ListGeneralModel page)
        {
            try
            {
                GetPackgesResponse response = new GetPackgesResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Packages.Select(s => new CreatePackagesRequest
                    {
                        Id =s.Id,
                        GId = s.GId,
                        Name = s.Name,
                        Abbreviation = s.Abbreviation,
                        PSUs = s.Psus,
                         Dvr = s.Dvr,
                        Box = s.Box,
                        Modem = s.Modem,
                        Wifi = s.Wifi,
                        PortedHomePhone = s.PortedHomePhone,
                        NativeHomePhone = s.NativeHomePhone,
                        PortedMobile = s.PortedMobile,
                        NativeMobile = s.NativeMobile,
                        CreatedBy = s.CreatedBy,
                        CreatedAt = s.CreatedAt,
                        Active=s.Active,
                        DeactivatedAt = s.DeactivatedAt,
                        DeactivatedBy = s.DeactivatedBy,
                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Name.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.Name);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                            break;
                        case 1:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Abbreviation) : query.OrderBy(x => x.Abbreviation);
                            break;
                        case 2:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.PSUs) : query.OrderBy(x => x.PSUs);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Packages = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<Package> GetPackageByID(Guid? packageGId)
        {
            if (db != null)
            {
                return await db.Packages.Where(x => x.GId == packageGId).Select(s => new Package
                {
                    Id = s.Id,
                    GId = s.GId,
                    Name = s.Name,
                    Abbreviation = s.Abbreviation,
                    Psus = s.Psus,
                    Dvr = s.Dvr,
                    Box = s.Box,
                    Modem = s.Modem,
                    Wifi = s.Wifi,
                    PortedHomePhone = s.PortedHomePhone,
                    NativeHomePhone = s.NativeHomePhone,
                    PortedMobile = s.PortedMobile,
                    NativeMobile = s.NativeMobile,
                    CreatedAt= s.CreatedAt,
                    CreatedBy= s.CreatedBy,

                }).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Package>> GetPackages()
        {
            throw new NotImplementedException();
        }
    }
}
