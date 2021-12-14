using Microsoft.EntityFrameworkCore;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2
{
    public class HusRumDbContextSeed
    {
        public static async Task SeedAsync(HusRumDbContext husRumDbContext, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (husRumDbContext.Database.IsSqlServer())
                {
                    husRumDbContext.Database.Migrate();
                }
                if (!await husRumDbContext.Doors.AnyAsync())
                {
                    await husRumDbContext.Doors.AddRangeAsync();
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Events.AnyAsync())
                {
                    await husRumDbContext.Events.AddRangeAsync();
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Logs.AnyAsync())
                {
                    await husRumDbContext.Logs.AddRangeAsync();
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Tags.AnyAsync())
                {
                    await husRumDbContext.Tags.AddRangeAsync();
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Tenants.AnyAsync())
                {
                    await husRumDbContext.Tenants.AddRangeAsync();
                    await husRumDbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                
            }

            static IEnumerable<Door> GetPreConfiguredDoors()
            {
                return new List<Door>
                {
                    new("", "")
                };
            }
            static IEnumerable<Event> GetPreConfiguredEvents()
            {
                return new List<Event>
                {

                };
            }
            static IEnumerable<Tag> GetPreConfiguredTags()
            {
                return new List<Tag>
                {

                };
            }
            static IEnumerable<Tenant> GetPreConfiguredTenants()
            {
                return new List<Tenant>
                {

                };
            }
            static IEnumerable<Logs> GetPreConfiguredLogs()
            {
                return new List<Logs>
                {
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId"),
                    new(3, new DateTime(1995, 01, 30, 08, 20, 20), "Des", "First", "Last", "Code", "Desc", "TagId")
                };
            }
        }
    }
}
