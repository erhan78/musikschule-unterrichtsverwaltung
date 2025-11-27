using System.Security.Cryptography.X509Certificates;

namespace MusikschuleConsole
{
    internal class Program
    {
        private const string SchuelerDatei = "schueler.csv";
        private const string StundenDatei = "stunden.csv";

        static void Main(string[] args)
        {
            while (true)
            {
                Menue();
                string eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        SchuelerAnlegen();
                        break;
                    case "2":
                        // UnterrichtsstundeAnlegen();
                        break;
                    case "3":
                        // UnterrichtsstundenAnzeigen();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                        break;
                }

            }
        }

        static void Menue()
        {
            Console.WriteLine("Hauptmenü:");
            Console.WriteLine("[1] Neuen Schüler anlegen");
            Console.WriteLine("[2] Neue Unterrichtsstunde erfassen");
            Console.WriteLine("[3] Alle Unterrichtsstunden anzeigen");
            Console.WriteLine("[0] Programm beenden");
        }
        static void SchuelerAnlegen()
        {
            Console.WriteLine();
            Console.WriteLine("--- Neuen Schüler anlegen ---");

            Console.Write("Vorname: ");
            string vorname = Console.ReadLine();

            Console.Write("Nachname: ");
            string nachname = Console.ReadLine();

            Console.Write("Instrument: ");
            string instrument = Console.ReadLine();

            Console.Write("E-Mail (optional): ");
            string email = Console.ReadLine();

            Console.Write("Telefon (optional): ");
            string telefon = Console.ReadLine();

            int neueId = ErmittleNaechsteId(SchuelerDatei);
            string zeile = string.Join(";", neueId, vorname, nachname, instrument, email, telefon);
            File.AppendAllLines(SchuelerDatei, new[] { zeile });

            Console.WriteLine($"Schüler wurde mit ID {neueId} gespeichert.");

        }

        static void UnterrichtsstundeAnlegen()
        {
            Console.WriteLine();
            Console.WriteLine("--- Neue Unterrichtsstunde erfassen ---");

        }


        static int ErmittleNaechsteId(string datei)
        {
            if (!File.Exists(datei))
            {
                return 1;
            }

            string[] zeilen = File.ReadAllLines(datei);
            int maxId = 0;

            foreach (string zeile in zeilen)
            {
                if (string.IsNullOrWhiteSpace(zeile)) continue;
                string[] teile = zeile.Split(';');
                if (teile.Length == 0) continue;

                if (int.TryParse(teile[0], out int id))
                {
                    if (id > maxId) maxId = id;
                }
            }

            return maxId + 1;
        }

        static List<Schueler> LadeSchueler()
        {
            var liste = new List<Schueler>();

            if (!File.Exists(SchuelerDatei))
            {
                return liste;
            }

            string[] zeilen = File.ReadAllLines(SchuelerDatei);

            foreach (string zeile in zeilen)
            {
                if (string.IsNullOrWhiteSpace(zeile)) continue;
                string[] teile = zeile.Split(';');
                if (teile.Length < 6) continue;

                if (!int.TryParse(teile[0], out int id)) continue;

                var s = new Schueler
                {
                    Id = id,
                    Vorname = teile[1],
                    Nachname = teile[2],
                    Instrument = teile[3],
                    Email = teile[4],
                    Telefon = teile[5]
                };
                liste.Add(s);
            }

            return liste;
        }
    }

}



    class Schueler
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Instrument { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
