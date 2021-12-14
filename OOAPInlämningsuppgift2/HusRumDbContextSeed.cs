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
                    await husRumDbContext.Tags.AddRangeAsync(GetPreConfiguredTags());
                    await husRumDbContext.SaveChangesAsync();
                }
                if (!await husRumDbContext.Tenants.AnyAsync())
                {
                    await husRumDbContext.Tenants.AddRangeAsync(GetPreConfiguredTenants());
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
                    new("0101", "Liam", "Jönsson", "0101A"),
                    new("0102", "Elias", "Petterson", "0102A"),
                    new("0102", "Wilma", "Johansson", "0102B"),
                    new("0103", "Alicia", "Sanchez", "0103A"),
                    new("0103", "Aaron", "Sanchez", "0103B"),
                    new("0201", "Olivia", "Erlander", "0201A"),
                    new("0201", "William", "Erlander", "0201B"),
                    new("0201", "Alexander", "Erlander", "0201C"),
                    new("0201", "Astrid", "Erlander", "0201D"),
                    new("0202", "Lucas", "Adolfsson", "0202A"),
                    new("0202", "Ebba", "Adolfsson", "0202B"),
                    new("0202", "Lilly", "Adolfsson", "0202C"),
                    new("0301", "Ella", "Ahlström", "0301A"),
                    new("0301", "Alma", "Ahlström", "0301B"),
                    new("0301", "Elsa", "Ahlström", "0301C"),
                    new("0301", "Maja", "Ahlström", "0301D"),
                    new("0302", "Noah", "Almgren", "0302A"),
                    new("0302", "Adam", "Andersen", "0302B"),
                    new("0302", "Kattis", "Backman", "0302C"),
                    new("0302", "Oscar", "Chen", "0302D"),
                    new("VAKT", "Vaktmätare", "Vaktmätare", "VAKT01")
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
