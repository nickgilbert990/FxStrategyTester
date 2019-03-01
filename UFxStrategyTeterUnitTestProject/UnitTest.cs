using System;
using cAlgo;
using cAlgo.API;
using cAlgo.API.Indicators;
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
        private double _currentSlowMa;
        private double _currentFastMa;
        private double _previousSlowMa;
        private double _previousFastMa;

        [Test]
        public void Test_MovingAverageCrossover_Returns_Long_Alert()
        {
            _currentSlowMa  = 1.2;
            _currentFastMa  = 1.3;
            _previousSlowMa = 1.3;
            _previousFastMa = 1.2;

            var movingAverageTest = new MovingAverageCrossOver(_currentSlowMa, _currentFastMa, _previousSlowMa, _previousFastMa);
            Assert.AreEqual("AlertLong", movingAverageTest.IndicatorAlert());     
        }

        [Test]
        public void Test_MovingAverageCrossover_Returns_Short_Alert()
        {
            _currentSlowMa  = 1.3;
            _currentFastMa  = 1.2;
            _previousSlowMa = 1.2;
            _previousFastMa = 1.3;

            var movingAverageTest = new MovingAverageCrossOver(_currentSlowMa, _currentFastMa, _previousSlowMa, _previousFastMa);
            Assert.AreEqual("AlertShort", movingAverageTest.IndicatorAlert());
        }

        [Test]
        public void Test_MovingAverageCrossover_Returns_Null()
        {
            _currentSlowMa  = 1.2;
            _currentFastMa  = 1.2;
            _previousSlowMa = 1.2;
            _previousFastMa = 1.2;

            var movingAverageTest = new MovingAverageCrossOver(_currentSlowMa, _currentFastMa, _previousSlowMa, _previousFastMa);
            Assert.AreEqual(null, movingAverageTest.IndicatorAlert());
        }
    }
}

//
//            var mockMA = new Mock<MovingAverage>();
//            mockMA.SetupProperty(x => x.Result.Last(0), 1.2345);
//            mockMA.SetupProperty(x => x.Result.Last(1), 1.3345);
//            
//            Assert.Multiple(() =>
//            {
//                Assert.IsNull(_indicator);
//                Assert.IsInstanceOf(typeof(MovingAverageCrossOver), _indicator);
//            });


