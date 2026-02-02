using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikschuleGui.Data
{
    public class Lehrer
    {
        public int LehrerId { get; set; }
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public string Fachgebiet { get; set; } = "";
        public string? Email { get; set; }
        public string? Telefon { get; set; }

        public ICollection<Unterrichtsstunde> Unterrichtsstunden { get; set; } = new List<Unterrichtsstunde>();
    }
}
