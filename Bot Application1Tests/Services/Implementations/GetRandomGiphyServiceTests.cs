using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot_Application1.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Services.Implementations.Tests
{
    [TestClass()]
    public class GetRandomGiphyServiceTests
    {
        [TestMethod()]
        public void GetRandomGifBasedOnSearchCriteraTest()
        {
            var temp = new GetRandomGiphyService();
            var returnValue = temp.GetRandomGifBasedOnSearchCritera("kitten");
            Assert.IsInstanceOfType(returnValue, typeof(Attachment));
        }

    }
}