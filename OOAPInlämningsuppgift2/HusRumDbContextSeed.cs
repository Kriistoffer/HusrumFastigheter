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
                    await husRumDbContext.Doors.AddRangeAsync(GetPreConfiguredDoors());
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Events.AnyAsync())
                {
                    await husRumDbContext.Events.AddRangeAsync(GetPreConfiguredEvents());
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
                    new("LGH", "LGH0101"),
                    new("BLK", "BLK0101"),
                    new("SOPRUM", "001"),
                    new("UT", "001"),
                    new("TVÄTT", "001"),
                    new("VAKT", "001"),
                };
            }
            static IEnumerable<Event> GetPreConfiguredEvents()
            {
                return new List<Event>
                {
                    new("DÖUT", "Dörr har öppnats utifrån"),
                    new("DÖIN", "Dörr har öppnats inifrån"),
                    new("FDIN", "Fel dörr - Gäst har försökt öppna en dörr utan tillstånd"),
                    new("FDUT", "Fel dörr - Person har försökt gå ut från en dör där taggen ej tillåter")
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

                };
            }
        }
    }
}
