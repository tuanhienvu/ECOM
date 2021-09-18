using System;
using ECOM.Areas.Identity.Data;
using ECOM.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ECOM.Areas.Identity.IdentityHostingStartup))]
namespace ECOM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ECOMContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ECOMContextConnection")));

                //services.AddDefaultIdentity<ECOMUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<ECOMContext>();
            });
        }
    }
}