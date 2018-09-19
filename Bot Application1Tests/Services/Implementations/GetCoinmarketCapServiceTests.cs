using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot_Application1.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1.Services.Implementations.Tests
{
    [TestClass()]
    public class GetCoinmarketCapServiceTests
    {
        [TestMethod()]
        public void GetMarketCapTest()
        {
            var a = new GetCoinmarketCapService();

            var returnValue = a.GetMarketCap();

            Assert.Fail();
        }
    }
}