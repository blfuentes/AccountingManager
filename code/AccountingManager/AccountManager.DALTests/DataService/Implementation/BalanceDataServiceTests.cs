using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountManager.DAL.DataService;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using AccountManager.DALTests;
using AccountManager.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.DAL.DataService.Tests
{
    [TestClass()]
    public class BalanceDataServiceTests
    {
        [TestMethod()]
        [DataRow(1)]
        public void AddItemTest(int id)
        {
            var _configuration = new ConfigurationBuilder()
                            .SetBasePath(AssemblyProperties.AssemblyDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("AccountManagerLocalDB"));

            var balanceDataService = new BalanceDataService(optionsBuilder);
            var tmpTask = balanceDataService.AddItem(new DTO.BalanceDTO()
            {
                BalanceID = id,
                Date = DateTime.Now,
                DateClosed = null,
                FinalAmount = 100.0M,
                InitialAmount = 500.0M,
                MonthName = "",
                MonthSort = 0,
                PercentVariation = 10,
                Variation = 50

            });

            Assert.IsNotNull(balanceDataService);
            Assert.IsNotNull(balanceDataService.GetItemByID(id).Result);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(200, -200)]
        public void GetItemByIDTest(int found, int notfound)
        {
            var _configuration = new ConfigurationBuilder()
                            .SetBasePath(AssemblyProperties.AssemblyDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("AccountManagerLocalDB"));

            var balanceDataService = new BalanceDataService(optionsBuilder);
            var tmpTask = balanceDataService.AddItem(new DTO.BalanceDTO()
            {
                BalanceID = found,
                Date = DateTime.Now,
                DateClosed = null,
                FinalAmount = 100.0M,
                InitialAmount = 500.0M,
                MonthName = "",
                MonthSort = 0,
                PercentVariation = 10,
                Variation = 50

            });

            var elementFound = balanceDataService.GetItemByID(found);
            elementFound.Wait();
            var elementNotFound = balanceDataService.GetItemByID(notfound);
            elementNotFound.Wait();

            Assert.IsNotNull(balanceDataService);
            Assert.IsNotNull(elementFound.Result);
            Assert.IsNull(elementNotFound.Result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            var _configuration = new ConfigurationBuilder()
                .SetBasePath(AssemblyProperties.AssemblyDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("AccountManagerLocalDB"));

            var balanceDataService = new BalanceDataService(optionsBuilder);

            for (int idx = 10; idx <= 20; idx++)
            {
                var tmpTask = balanceDataService.AddItem(new DTO.BalanceDTO()
                {
                    BalanceID = idx,
                    Date = DateTime.Now,
                    DateClosed = null,
                    FinalAmount = 100.0M,
                    InitialAmount = 500.0M,
                    MonthName = "",
                    MonthSort = 0,
                    PercentVariation = 10,
                    Variation = 50

                });
                tmpTask.Wait();
            }

            var elements = balanceDataService.GetCollection().ToList();
            Assert.IsNotNull(balanceDataService);
            Assert.IsTrue(elements.Any());
        }

        [TestMethod()]
        [DataRow(2017, 2018)]
        public void GetBalancesByYearTest(int year2017, int year2018)
        {
            var _configuration = new ConfigurationBuilder()
                .SetBasePath(AssemblyProperties.AssemblyDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("AccountManagerLocalDB"));

            var balanceDataService = new BalanceDataService(optionsBuilder);

            for (int idx = 30; idx < 40; idx++)
            {
                var tmpTask = balanceDataService.AddItem(new DTO.BalanceDTO()
                {
                    BalanceID = idx,
                    Date = idx % 3 == 0 ? DateTime.Now.AddYears(-2) : DateTime.Now.AddYears(-3),
                    DateClosed = null,
                    FinalAmount = 100.0M,
                    InitialAmount = 500.0M,
                    MonthName = "",
                    MonthSort = 0,
                    PercentVariation = 10,
                    Variation = 50

                });
                tmpTask.Wait();
            }

            var balance2017 = balanceDataService.GetBalancesByYear(year2017);
            balance2017.Wait();
            var balance2018 = balanceDataService.GetBalancesByYear(year2018);
            balance2018.Wait();

            Assert.IsNotNull(balanceDataService);
            Assert.IsTrue(balance2017.Result.Count == 6, $"Expected 6, found {balance2017.Result.Count}");
            Assert.IsTrue(balance2018.Result.Count == 4, $"Expected 4, found {balance2018.Result.Count}");
        }
    }
}