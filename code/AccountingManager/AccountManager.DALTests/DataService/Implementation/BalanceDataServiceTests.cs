using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountManager.DAL.DataService;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using AccountManager.DALTests;
using AccountManager.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DAL.DataService.Tests
{
    [TestClass()]
    public class BalanceDataServiceTests
    {
        [TestMethod()]
        public void GetItemByIDTest()
        {
            var _configuration = new ConfigurationBuilder()
                            .SetBasePath(AssemblyProperties.AssemblyDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AccountManagerLocalDB"));

            var balanceDataService = new BalanceDataService(optionsBuilder);
            var elementFound = balanceDataService.GetItemByID(1);
            elementFound.Wait();
            var elementNotFound = balanceDataService.GetItemByID(-1);
            elementNotFound.Wait();

            Assert.IsNotNull(balanceDataService);
            Assert.IsNotNull(elementFound.Result);
            Assert.IsNull(elementNotFound.Result);
        }
    }
}