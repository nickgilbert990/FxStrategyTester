using cAlgo;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.Indicators;
using cAlgo.Main;

namespace cAlgo.Indicators
{
    public class MovingAverageCrossOver : IIndicators
    {
        private MovingAverage _slowMa;
        private MovingAverage _fastMa;

        private double _currentSlowMa;
        private double _currentFastMa;
        private double _previousSlowMa;
        private double _previousFastMa; 

        private string _alert = null;

        public MovingAverageCrossOver(TradeAutomation.FactoryParameters inputParameters)
        {
            _fastMa = inputParameters.Bot.Indicators.MovingAverage(inputParameters.SourceSeries, inputParameters.FastPeriods, inputParameters.MAType);
            _slowMa = inputParameters.Bot.Indicators.MovingAverage(inputParameters.SourceSeries, inputParameters.SlowPeriods, inputParameters.MAType);

            _currentSlowMa = _slowMa.Result.Last(0);
            _currentFastMa = _fastMa.Result.Last(0);
            _previousSlowMa = _slowMa.Result.Last(1);
            _previousFastMa = _fastMa.Result.Last(1);
        }

        public MovingAverageCrossOver(double currentSlowMa, double currentfastMa, double previousSlowMa, double previousFastMa)
        {
            _currentSlowMa = currentSlowMa;
            _currentFastMa = currentfastMa;
            _previousSlowMa = previousSlowMa;
            _previousFastMa = previousFastMa;
        }

        public string IndicatorAlert()
        {

            _alert = null;

            if (_previousSlowMa > _previousFastMa && _currentSlowMa <= _currentFastMa)
            {
                _alert = "AlertLong";
            }
            else if (_previousSlowMa < _previousFastMa && _currentSlowMa >= _currentFastMa)
            {
                _alert = "AlertShort";
            }

            return _alert;
        }

    }

}