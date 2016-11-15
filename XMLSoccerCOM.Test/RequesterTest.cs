using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLSoccerCOM;
namespace XMLSoccerCOM.Test
{
    [TestClass]
    public class RequesterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var requester = new XMLSoccerCOM.Requester("YOURAPIKEY", true);
            var matches = requester.GetHistoricMatchesByLeagueAndSeason("34", 2016);
            Assert.IsTrue(matches.Count > 70);
        }
    }
}
