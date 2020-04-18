using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.DALTests
{
    [TestClass()]
    public class ConfigurationBuilderTests
    {
        [TestMethod]
        public void ConfigurationBuilderTest()
        {
            var _configuration = new ConfigurationBuilder()
                .SetBasePath(AssemblyProperties.AssemblyDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            Assert.IsNotNull(_configuration);
        }
    }
}
