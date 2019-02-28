using System;
using cAlgo;
using cAlgo.API;
using cAlgo.API.Internals;
using cAlgo.Indicators;
using cAlgo.Main;
using Moq;
using NUnit.Framework;
using static cAlgo.Main.TradeAutomation;

namespace UFxStrategyTeterUnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestMethod()
        { 
            var factoryParameters = new FactoryParameters { IndicatorType = "XX" };
            var _indicator = new IndicatorFactory().GetIndicator(factoryParameters);
            
            Assert.Multiple(() =>
            {
                Assert.IsNull(_indicator);
            });

            
        }
    }
}
