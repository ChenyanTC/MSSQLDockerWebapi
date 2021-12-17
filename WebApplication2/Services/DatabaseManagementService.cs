using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Services;

public static class DatabaseManagementService
{
    public static void MigrationInitializasation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
}