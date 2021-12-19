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
        // Get Endpoint for finding entries by door
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
        // Endpoint for finding entries by event
        [HttpGet("Find_Entries_By_Event")]
        public ActionResult<List<Logs>> FindEntriesByEvent(string eventCode, int maxEntries = 20)
        {
            //Finds the eventcodes in the dbcontext where the input matches the value of code in Logs
            var eventLogs = _husRumDbContext.Logs.Where(e => e.Code  == eventCode).ToList();
            if (eventLogs.Count == 0)
            {
                return NotFound("Could not find entries");
            }
            else
            {
                //Order the list of eventlogs by datetime in descending order and then filter out how many entries 
                //that will be shown according to input parameter maxEntries
                eventLogs = eventLogs.OrderByDescending(x => x.DateTime).ToList();
                if (eventLogs.Count - maxEntries > 0)
                {
                    eventLogs.RemoveRange(maxEntries, eventLogs.Count - maxEntries);
                }
              
                return Ok(eventLogs);
            }
        }
        // Get Endpoint for finding entries by Location
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
                //Order the list of locationlogs by datetime in descending order and then filter out how many entries 
                //that will be shown according to input parameter maxEntries
                locationLogs = locationLogs.OrderByDescending(x => x.DateTime).ToList();
               
                if(locationLogs.Count - maxEntries > 0)
                {
                    locationLogs.RemoveRange(maxEntries, locationLogs.Count - maxEntries);
                }

                return Ok(locationLogs);
            }
        }

        // Get Endpoint for finding entries by Tag
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
                //Order the list of taglogs by datetime in descending order and then filter out how many entries 
                //that will be shown according to input parameter maxEntries
                tagLogs = tagLogs.OrderByDescending(x => x.DateTime).ToList();
                if (tagLogs.Count - maxEntries > 0)
                {
                    tagLogs.RemoveRange(maxEntries, tagLogs.Count - maxEntries);
                }
               
                return Ok(tagLogs);
            }
        }

        // Get Endpoint for finding entries by tenant
        [HttpGet("Find_Entries_By_Tenant")]
        public ActionResult<List<Logs>> FindEntriesByTenant(string firstName, string lastName, int maxEntries = 20)
        {
            //Order the list of tenantlogs by datetime in descending order and then filter out how many entries 
            //that will be shown according to input parameter maxEntries
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
        //Post endpoint for log entry
        [HttpPost("Log_Entry")]
        public ActionResult<Logs> LogEntry(string designation, string code, string tagId)
        {
            //Get all tenants that matches the tagId 
            var tenant = _husRumDbContext.Tenants.Where(t => t.Tag == tagId).FirstOrDefault();
            //Get all doors that matches the DoorDesignation 
            var doorDesignation = _husRumDbContext.Doors.Where(d => d.DoorDesignation == designation).FirstOrDefault();
            //Get all events that matches the code 
            var eventCode = _husRumDbContext.Events.Where(e => e.Code == code).FirstOrDefault();
            //Creates new log with parameters from the matching values from dbcontext
            var log = new Logs(DateTime.Now, doorDesignation.DoorDesignation, tenant.FirstName, tenant.LastName, eventCode.Code, eventCode.Description, tenant.Tag);
            //Adds the new log to db
            _husRumDbContext.Logs.AddAsync(log);
            //Saves changes made in the db
            _husRumDbContext.SaveChanges();
            return Ok(log);
        }

    }
}
