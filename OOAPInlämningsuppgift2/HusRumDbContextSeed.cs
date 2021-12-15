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
                    await husRumDbContext.Logs.AddRangeAsync(GetPreConfiguredLogs());
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
                    new("UT"),
                    new("SOPRUM"),
                    new("TVÄTT"),
                    new("VAKT"),
                    new("LGH0101"),
                    new("BLK0101"),
                    new("LGH0102"),
                    new("BLK0102"),
                    new("LGH0103"),
                    new("BLK0103"),
                    new("LGH0201"),
                    new("BLK0201"),
                    new("LGH0202"),
                    new("BLK0202"),
                    new("LGH0301"),
                    new("BLK0301"),
                    new("LGH0302"),
                    new("BLK0302"),
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
            static IEnumerable<Tenant> GetPreConfiguredTenants()
            {
                return new List<Tenant>
                {
                    new("0101", "Liam", "Jönsson","0101A"),
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
                    new("VAKT", "Argus", "Filch", "VAKT01")
                };
            }
            static IEnumerable<Logs> GetPreConfiguredLogs()
            {
                return new List<Logs>
                {
                    new(new DateTime(2018, 01, 30, 08, 20, 20), "LGH0101", "Liam", "Jönsson", "DÖIN", "Dörr har öppnats inifrån", "0101A"),
                    new(new DateTime(2019, 03, 12, 14, 01, 59), "LGH0302", "Alexander", "Erlander", "FDUT", "Fel dörr - Person har försökt gå ut från en dör där taggen ej tillåter", "0201C"),
                    new(new DateTime(2020, 01, 21, 10, 25, 31), "LGH0201", "William", "Erlander", "DÖUT", "Dörr har öppnats utifrån", "0201B"),
                    new(new DateTime(2020, 02, 15, 05, 29, 29), "LGH0102", "Elias", "Petterson", "DÖIN", "Dörr har öppnats inifrån", "0102A"),
                    new(new DateTime(2020, 03, 28, 03, 32, 52), "BLK0201", "Astrid", "Erlander", "DÖUT", "Dörr har öppnats utifrån", "0201D"),
                    new(new DateTime(2021, 01, 29, 12, 46, 01), "BLK0301", "Argus", "Filch", "DÖIN", "Dörr har öppnats inifrån", "VAKT01"),
                    new(new DateTime(2021, 05, 01, 18, 39, 09), "SOPRUM", "Olivia", "Erlander", "DÖUT", "Dörr har öppnats utifrån", "0201A"),
                    new(new DateTime(2021, 07, 05, 21, 02, 24), "BLK0103", "Aaron", "Sanchez", "FDIN", "Fel dörr - Gäst har försökt öppna en dörr utan tillstånd", "0103B"),
                    new(new DateTime(2021, 07, 23, 13, 24, 21), "TVÄTT", "Lilly", "Adolfsson", "DÖIN", "Dörr har öppnats inifrån", "0202C"),
                    new(new DateTime(2021, 12, 31, 23, 58, 56), "VAKT", "Argus", "Filch", "DÖUT", "Dörr har öppnats utifrån", "VAKT01")
                };
            }
        }
    }
}
