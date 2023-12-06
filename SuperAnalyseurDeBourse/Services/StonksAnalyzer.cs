namespace SuperAnalyseurDeBourse.Services
{
    public enum AnalysisResult
    {
        Yuck,
        Meeeh,
        BUYYY
    }

    public class StonksAnalyzer
    {
        private IStockMarket _stockMarket;

        

        public StonksAnalyzer(IStockMarket stockMarket) {
            _stockMarket = stockMarket;
        }

        public bool IsGoodStonk(string stockTicker)
        {
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);
            decimal yesterdayValue = _stockMarket.GetStockValue(stockTicker, yesterday);
            decimal currentValue = _stockMarket.GetStockValue(stockTicker, now);
            return currentValue > yesterdayValue;
        }

        public AnalysisResult InDepthAnalysis(string stockTicker)
        {
            DateTime now = DateTime.Now;
            DateTime lastWeek = now.AddDays(-7);
            DateTime lastMonth = now.AddDays(-30);
            
            decimal lastMonthValue = _stockMarket.GetStockValue(stockTicker, lastMonth);
            decimal lastWeekValue = _stockMarket.GetStockValue(stockTicker, lastWeek);
            decimal currentValue = _stockMarket.GetStockValue(stockTicker, now);

            if (currentValue > lastWeekValue && lastWeekValue > lastMonthValue)
                return AnalysisResult.BUYYY;
            else if (currentValue < lastWeekValue && lastWeekValue < lastMonthValue)
                return AnalysisResult.Yuck;

            return AnalysisResult.Meeeh;
        }
    }
}
