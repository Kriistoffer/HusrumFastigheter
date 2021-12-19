using Microsoft.AspNetCore.Mvc;
using OOAPInlamningsuppgift2.Entities;
using System.Linq;

namespace OOAPInlamningsuppgift2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private HusRumDbContext _husRumDbContext;
        public LogController(HusRumDbContext husRumDbContext)
        {
            _husRumDbContext = husRumDbContext;
        }

        [HttpGet("Find_Entries_By_Door")]
        public ActionResult<List<Logs>> FindEntriesByDoor(string doorDesignation, int maxEntries = 20)
        {
            var doorLogs = _husRumDbContext.Logs.Where(d => d.Designation == doorDesignation).ToList();
            if (doorLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            } 
            else
            {
                doorLogs = doorLogs.OrderByDescending(x => x.DateTime).ToList();
                if (doorLogs.Count - maxEntries > 0)
                {
                    doorLogs.RemoveRange(maxEntries, doorLogs.Count - maxEntries);
                }
               
                return Ok(doorLogs);
            }
        }

        [HttpGet("Find_Entries_By_Event")]
        public ActionResult<List<Logs>> FindEntriesByEvent(string eventCode, int maxEntries = 20)
        {
            var eventLogs = _husRumDbContext.Logs.Where(e => e.Code  == eventCode).ToList();
            if (eventLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                eventLogs = eventLogs.OrderByDescending(x => x.DateTime).ToList();
                if (eventLogs.Count - maxEntries > 0)
                {
                    eventLogs.RemoveRange(maxEntries, eventLogs.Count - maxEntries);
                }
              
                return Ok(eventLogs);
            }
        }

        [HttpGet("Find_Entries_By_Location")]
        public ActionResult<List<Logs>> FindEntriesByLocation(string location, int maxEntries = 20)
        {
            var locationLogs = _husRumDbContext.Logs.Where(l => l.Designation.Contains(location)).ToList();
            if (locationLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                locationLogs = locationLogs.OrderByDescending(x => x.DateTime).ToList();
               
                if(locationLogs.Count - maxEntries > 0)
                {
                    locationLogs.RemoveRange(maxEntries, locationLogs.Count - maxEntries);
                }

                return Ok(locationLogs);
            }
        }

        [HttpGet("Find_Entries_By_Tag")]
        public ActionResult<List<Logs>> FindEntriesByTag(string tag, int maxEntries = 20)
        {
            var tagLogs = _husRumDbContext.Logs.Where(t => t.TagId == tag).ToList();
            if (tagLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                tagLogs = tagLogs.OrderByDescending(x => x.DateTime).ToList();
                if (tagLogs.Count - maxEntries > 0)
                {
                    tagLogs.RemoveRange(maxEntries, tagLogs.Count - maxEntries);
                }
               
                return Ok(tagLogs);
            }
        }

        [HttpGet("Find_Entries_By_Tenant")]
        public ActionResult<List<Logs>> FindEntriesByTenant(string firstName, string lastName, int maxEntries = 20)
        {
            var tenantLogs = _husRumDbContext.Logs.Where(t => t.FirstName == firstName && t.LastName == lastName).ToList();
            if (tenantLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                tenantLogs = tenantLogs.OrderByDescending(x => x.DateTime).ToList();
                if (tenantLogs.Count - maxEntries > 0)
                {
                    tenantLogs.RemoveRange(maxEntries, tenantLogs.Count - maxEntries);
                }
               
                return Ok(tenantLogs);
            }
        }
        [HttpPost("Log_Entry")]
        public ActionResult<Logs> LogEntry(string designation, string code, string tagId)
        {
            var tenant = _husRumDbContext.Tenants.Where(t => t.Tag == tagId).FirstOrDefault();
            var doorDesignation = _husRumDbContext.Doors.Where(d => d.DoorDesignation == designation).FirstOrDefault();
            var eventCode = _husRumDbContext.Events.Where(e => e.Code == code).FirstOrDefault();

            var log = new Logs(DateTime.Now, doorDesignation.DoorDesignation, tenant.FirstName, tenant.LastName, eventCode.Code, eventCode.Description, tenant.Tag);

            _husRumDbContext.Logs.AddAsync(log);
            _husRumDbContext.SaveChanges();
            return Ok(log);
        }

    }
}
