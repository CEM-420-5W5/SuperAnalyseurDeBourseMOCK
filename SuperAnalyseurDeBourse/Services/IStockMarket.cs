namespace SuperAnalyseurDeBourse.Services
{
    public interface IStockMarket
    {
        decimal GetStockValue(string stockTicker, DateTime date);

        int GetNbStocks(string stockTicker, DateTime date);
    }
}
