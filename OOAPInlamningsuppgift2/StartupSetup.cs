using Microsoft.EntityFrameworkCore;

namespace OOAPInlamningsuppgift2
{
    public static class StartupSetup
    {
        //Configures sql server to be added in the IServiceCollection
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HusRumDbContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
