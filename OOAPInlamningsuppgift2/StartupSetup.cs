﻿using Microsoft.EntityFrameworkCore;

namespace OOAPInlamningsuppgift2
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HusRumDbContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}