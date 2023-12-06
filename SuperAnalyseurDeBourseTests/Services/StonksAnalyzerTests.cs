using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperAnalyseurDeBourse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAnalyseurDeBourse.Services.Tests
{
    [TestClass()]
    public class StonksAnalyzerTests
    {
        [TestMethod()]
        public void IsGoodStonkGoodStockTest()
        {
            var stock_Mock = new Mock<IStockMarket>();
            var analyzer = new StonksAnalyzer(stock_Mock.Object);

            stock_Mock.SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(33.33M).Returns(42.00M);

            bool result = analyzer.IsGoodStonk("ABC");

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsGoodStonkBadStockTest()
        {
            var stock_Mock = new Mock<IStockMarket>();
            var analyzer = new StonksAnalyzer(stock_Mock.Object);

            stock_Mock.SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(42.00M).Returns(33.33M);

            bool result = analyzer.IsGoodStonk("ABC");

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InDepthAnalysisYuckTest()
        {
            var stock_Mock = new Mock<IStockMarket>();
            var analyzer = new StonksAnalyzer(stock_Mock.Object);

            stock_Mock.SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(42.00M).Returns(33.33M).Returns(18.45M);

            var result = analyzer.InDepthAnalysis("ABC");

            Assert.AreEqual(AnalysisResult.Yuck, result);
        }

        [TestMethod()]
        public void InDepthAnalysisMeehTest()
        {
            var stock_Mock = new Mock<IStockMarket>();
            var analyzer = new StonksAnalyzer(stock_Mock.Object);

            stock_Mock.SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(42.00M).Returns(18.45M).Returns(33.33M);

            var result = analyzer.InDepthAnalysis("ABC");

            Assert.AreEqual(AnalysisResult.Meeeh, result);
        }

        [TestMethod()]
        public void InDepthAnalysisBuyTest()
        {
            var stock_Mock = new Mock<IStockMarket>();
            var analyzer = new StonksAnalyzer(stock_Mock.Object);

            stock_Mock.SetupSequence(x => x.GetStockValue(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(18.45M).Returns(33.33M).Returns(42.00M);

            var result = analyzer.InDepthAnalysis("ABC");

            Assert.AreEqual(AnalysisResult.BUYYY, result);
        }
    }

}