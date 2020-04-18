using AccountManager.DAL.DataService;
using AccountManager.DAL.DTO;
using AccountManager.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManager.DAL
{
    public static class AccountManagerDataService
    {
        public static IServiceCollection AddAccountManagerDAL(this IServiceCollection services, DbContextOptionsBuilder<AccountManagerContext> optionsBuilder)
        {
            services.AddTransient<IDataService<BalanceDTO>>(_s => new BalanceDataService(optionsBuilder));

            return services;
        }
    }
}
