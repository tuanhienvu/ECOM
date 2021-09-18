using ECOM.Areas.Identity.Data;
using ECOM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ECOMContext context, IServiceProvider serviceProvider,
            UserManager<ECOMUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string [] RoleNames = {"Admin", "User"};
            IdentityResult roleResult;
            foreach(var roleName  in RoleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if(!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            string Email = "admin@tuanhienvu.com";
            string password = "Admin@123";
            if(userManager.FindByEmailAsync(Email) == null)
            {
                ECOMUser user = new ECOMUser();
                user.UserName = Email;
                user.Email = Email;
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }
        }

    }
}
