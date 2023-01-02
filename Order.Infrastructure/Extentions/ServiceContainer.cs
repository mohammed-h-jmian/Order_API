using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Services.Categories;
using Order.Infrastructure.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
