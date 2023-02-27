using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpsAccounting.DataModel;
using OpsAccounting.Models;

public static class SeedRoles
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            string[] roles = { "Supervisor", "Manager", "User", "QC" };
            foreach (string role in roles)
            {
                context.Roles.Add(new IdentityRole { Name = role.Trim() });
            }
            context.SaveChanges();

            var userManager = serviceProvider.GetRequiredService<UserManager<UserMaster>>();

            var user = new UserMaster
            {
                UserName = "vaibhava",
                Wnsid = "310475",
                CitrixId = "vaibhava",
               
            };

            var result = userManager.CreateAsync(user, "Abcd@1234").Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "SUPERVISOR").Wait();
            }
        }
    }

}