namespace SuperAnalyseurDeBourse.Services
{
    // Ceci est un EXEMPLE pour montrer à quoi ressemble l'objet généré par le Mock à la création
    public class StockMarketMockedObject : IStockMarket
    {
        public int NbGetStockValueCalls { get; set; }
        public int NbGetNbStocksCalls { get; set; }

        public decimal GetStockValue(string stockTicker, DateTime date)
        {
            NbGetStockValueCalls++;
            return default;
        }

        public int GetNbStocks(string stockTicker, DateTime date)
        {
            NbGetNbStocksCalls++;
            return default;
        }
    }

    // Ceci est un EXEMPLE pour montrer à quoi ressemble l'objet généré par le Mock 
    // après un appel à Setup(x => x.GetStockValue("ABC", It.IsAny<Date>()).Returns(42.42M);
    // et un appel à Setup(x => x.GetStockValue("XYZ", It.IsAny<Date>()).Returns(33.33M);
    public class ConfiguredStockMarketMockedObject : IStockMarket
    {
        public int NbGetStockValueCalls { get; set; }
        public int NbGetNbStocksCalls { get; set; }

        public decimal GetStockValue(string stockTicker, DateTime date)
        {
            NbGetStockValueCalls++;

            // Le deuxième appel à Setup
            if (stockTicker == "XYZ")
                return 33.33M;
            // Le premier appel à Setup
            if (stockTicker == "ABC")
                return 42.42M;
            
            return default;
        }

        public int GetNbStocks(string stockTicker, DateTime date)
        {
            NbGetNbStocksCalls++;
            return default;
        }
    }

    // Ceci est un EXEMPLE pour montrer à quoi ressemble l'objet généré par le Mock 
    // après un appel à SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<Date>()).Returns(33.33M).Returns(42.42M);
    public class SequenceStockMarketMockedObject : IStockMarket
    {
        public int NbGetStockValueCalls { get; set; }
        public int NbGetNbStocksCalls { get; set; }

        public decimal GetStockValue(string stockTicker, DateTime date)
        {
            NbGetStockValueCalls++;

            if (NbGetStockValueCalls == 1)
                return 33.33M;
            if (NbGetStockValueCalls == 2)
                return 42.42M;
            
            return default;
        }

        public int GetNbStocks(string stockTicker, DateTime date)
        {
            NbGetNbStocksCalls++;
            return default;
        }
    }
}

