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

        //Get endpoint which lists all tenants at an apartment
        [HttpGet("List_Tenant_At")]
        public ActionResult<List<Tenant>> ListTenantAt(string apartmentNumber, int maxEntries = 20)
        {
            //Finds the tenants in the dbcontext where the input matches the value of apartmentnumbers in Tenants
            var tenantList = _husRumDbContext.Tenants.Where(t => t.ApartmentNumber == apartmentNumber).ToList();
            if (tenantList.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                //Order the list of tenants by lastname in and then filter out how many entries 
                //that will be shown according to input parameter maxEntries
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
