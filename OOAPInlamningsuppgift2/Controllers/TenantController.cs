using Microsoft.AspNetCore.Mvc;
using OOAPInlamningsuppgift2.Entities;

namespace OOAPInlamningsuppgift2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private HusRumDbContext _husRumDbContext;
        public TenantController(HusRumDbContext husRumDbContext)
        {
            _husRumDbContext = husRumDbContext;
        }


        [HttpGet("List_Tenant_At")]
        public ActionResult<List<Tenant>> ListTenantAt(string apartmentNumber, int maxEntries = 20)
        {
            var tenantList = _husRumDbContext.Tenants.Where(t => t.ApartmentNumber == apartmentNumber).ToList();
            if (tenantList.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                tenantList = tenantList.OrderBy(x => x.LastName).ToList();
                if (tenantList.Count - maxEntries > 0)
                {
                    tenantList.RemoveRange(maxEntries, tenantList.Count - maxEntries);
                }

                return Ok(tenantList);
            }
        }
    }
}
