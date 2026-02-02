using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikschuleGui.Data
{
    public class Unterrichtsstunde
    {
        public int UnterrichtsstundeId { get; set; }

        public int SchuelerId { get; set; }
        public Schueler? Schueler { get; set; }

        public int LehrerId { get; set; }
        public Lehrer? Lehrer { get; set; }

        public DateTime DatumUhrzeit { get; set; }
        public int DauerMinuten { get; set; }
        public decimal PreisProStunde { get; set; }

        public string Zahlungsstatus { get; set; } = "offen";       // offen / bezahlt
        public string Status { get; set; } = "geplant";             // geplant / durchgeführt / abgesagt
    }
}
}
