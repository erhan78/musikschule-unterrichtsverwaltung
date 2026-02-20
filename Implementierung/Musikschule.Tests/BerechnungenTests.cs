using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusikschuleGui.Data;
using MusikschuleGui.Services;
using System.Collections.Generic;

namespace Musikschule.Tests
{
    [TestClass]
    public class BerechnungenTests
    {
        [TestMethod]
        public void BerechneBetrag_45Min_40Euro_Returns30()
        {
            var result = Berechnungen.BerechneBetrag(45, 40m);
            Assert.AreEqual(30.00m, result);
        }

        [TestMethod]
        public void BerechneBetrag_60Min_35Euro_Returns35()
        {
            var result = Berechnungen.BerechneBetrag(60, 35m);
            Assert.AreEqual(35.00m, result);
        }

        [TestMethod]
        public void BerechneBetrag_30Min_30Euro_Returns15()
        {
            var result = Berechnungen.BerechneBetrag(30, 30m);
            Assert.AreEqual(15.00m, result);
        }

        [TestMethod]
        public void SummeAlle_ReturnsSumOfAllBetrag()
        {
            var stunden = new List<Unterrichtsstunde>
            {
                new Unterrichtsstunde { DauerMinuten = 60, PreisProStunde = 40m, Zahlungsstatus = "offen" },   // 40
                new Unterrichtsstunde { DauerMinuten = 30, PreisProStunde = 40m, Zahlungsstatus = "bezahlt" }  // 20
            };

            var sum = Berechnungen.SummeAlle(stunden);
            Assert.AreEqual(60.00m, sum);
        }

        [TestMethod]
        public void SummeOffen_ReturnsOnlyOpenSum()
        {
            var stunden = new List<Unterrichtsstunde>
            {
                new Unterrichtsstunde { DauerMinuten = 60, PreisProStunde = 40m, Zahlungsstatus = "offen" },   // 40
                new Unterrichtsstunde { DauerMinuten = 30, PreisProStunde = 40m, Zahlungsstatus = "bezahlt" }  // 20
            };

            var sumOffen = Berechnungen.SummeOffen(stunden);
            Assert.AreEqual(40.00m, sumOffen);
        }
    }
}