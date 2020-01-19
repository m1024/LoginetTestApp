using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestApp.Models;

namespace TestApp
{
    public static class IHostHelper
    {
        public static IHost UpdateUsers(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userService = services.GetService(typeof(UserService)) as UserService;
                var userManager = services.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;

                var users = userService.GetUsers().Result;

                foreach (var u in users)
                {
                    var user = new ApplicationUser { Email = u.Email, UserName = u.Email, UserId = u.Id };
                    // добавляем пользователя
                    var result = userManager.CreateAsync(user, "1").Result;
                }
            }

            return host;
        }
    }
}
