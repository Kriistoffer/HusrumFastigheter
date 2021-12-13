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
                    await husRumDbContext.Tags.AddRangeAsync(GetPreConfiguredTags());
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
                    new("0101A","LGH"),
                    new("0102A","LGH"),
                    new("0102B","LGH"),
                    new("0103A","LGH"),
                    new("0103B","LGH"),
                    new("0201A","LGH"),
                    new("0201B","LGH"),
                    new("0201C","LGH"),
                    new("0201D","LGH"),
                    new("0202A","LGH"),
                    new("0202B","LGH"),
                    new("0202C","LGH"),
                    new("0301A","LGH"),
                    new("0301B","LGH"),
                    new("0301C","LGH"),
                    new("0301D","LGH"),
                    new("0302A","LGH"),
                    new("0302B","LGH"),
                    new("0302C","LGH"),
                    new("0302D","LGH"),
                    new("VAKT01","VAKT"),

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
