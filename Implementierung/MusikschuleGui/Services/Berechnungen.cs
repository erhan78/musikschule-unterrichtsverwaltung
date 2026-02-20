using System;
using System.Collections.Generic;
using System.Linq;
using MusikschuleGui.Data;

namespace MusikschuleGui.Services
{
    public static class Berechnungen
    {
        public static decimal BerechneBetrag(int dauerMinuten, decimal preisProStunde)
        {
            if (dauerMinuten <= 0) throw new ArgumentOutOfRangeException(nameof(dauerMinuten));
            if (preisProStunde <= 0) throw new ArgumentOutOfRangeException(nameof(preisProStunde));

            return Math.Round(dauerMinuten / 60m * preisProStunde, 2);
        }

        public static decimal SummeAlle(IEnumerable<Unterrichtsstunde> stunden)
        {
            if (stunden == null) throw new ArgumentNullException(nameof(stunden));
            return stunden.Sum(s => s.Betrag);
        }

        public static decimal SummeOffen(IEnumerable<Unterrichtsstunde> stunden)
        {
            if (stunden == null) throw new ArgumentNullException(nameof(stunden));
            return stunden
                .Where(s => string.Equals(s.Zahlungsstatus, "offen", StringComparison.OrdinalIgnoreCase))
                .Sum(s => s.Betrag);
        }
    }
}