using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountManager.DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using AccountManager.DALTests;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DAL.EF.Models.Tests
{
    [TestClass()]
    public class AccountManagerContextTests
    {
        [TestMethod()]
        public void AccountManagerContextTest()
        {
            var _configuration = new ConfigurationBuilder()
                            .SetBasePath(AssemblyProperties.AssemblyDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagerContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AccountManagerLocalDB"));
            var dbContext = new AccountManagerContext(optionsBuilder.Options);

            Assert.IsNotNull(dbContext);
        }
    }
}