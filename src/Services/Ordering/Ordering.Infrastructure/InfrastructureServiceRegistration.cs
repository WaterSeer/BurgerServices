using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastractureService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));


            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
