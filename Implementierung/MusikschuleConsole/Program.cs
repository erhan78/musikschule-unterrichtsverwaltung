using System.Globalization;
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
                        UnterrichtsstundeAnlegen();
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

            List<Schueler> schuler = LadeSchueler();

            if (schuler.Count == 0)
            {
                Console.WriteLine("Keine Schüler vorhanden. Bitte legen Sie zuerst einen Schüler an.");
                return;
            }

            Console.WriteLine("Verfügbare Schüler:");
            foreach (var s in schuler)
            {
                Console.WriteLine($"[{s.Id}] {s.Vorname} {s.Nachname} - {s.Instrument}");
            }

            int schuelerId = LeseIntMitWiederholung("Geben Sie die ID des Schülers ein: ");

            Console.WriteLine("Lehrername: ");
            string lehrer = Console.ReadLine();

            DateTime datum;
            while (true)
            {
                Console.Write("Datum und Uhrzeit (z.B. 25.01.2025 15:30): ");
                string datumText = Console.ReadLine();
                if (DateTime.TryParseExact(
                        datumText,
                        "dd.MM.yyyy HH:mm",
                        CultureInfo.GetCultureInfo("de-DE"),
                        DateTimeStyles.None,
                        out datum))
                {
                    break;
                }
                Console.WriteLine("Ungültiges Datumsformat. Bitte erneut eingeben.");
            }

            int dauer = LeseIntMitWiederholung("Dauer in Minuten: ");

            decimal preis;
            while (true)
            {
                Console.Write("Preis pro Stunde (z.B. 30.00): ");
                string preisText = Console.ReadLine();
                if (decimal.TryParse(preisText, NumberStyles.Currency, CultureInfo.GetCultureInfo("de-DE"), out preis))
                {
                    break;
                }
                Console.WriteLine("Ungültiges Preisformat. Bitte erneut eingeben.");
            }

            Console.WriteLine("Zahlungsstatus [1]offen - [2]bezahlt: ");
            string zahlungsstatus = "";
            if (Console.ReadLine() == "2")
            {
                zahlungsstatus = "bezahlt";
            }
            else
            {
                zahlungsstatus = "offen";
            }
            Console.Write("Status der Stunde [1]geplant / [2]durchgeführt / [3]abgesagt): ");
            string status = "";
            if(Console.ReadLine() == "2")
            {
                status = "durchgeführt";
            }
            else if (Console.ReadLine() == "3")
            {
                status = "abgesagt";
            }
            else
            {
                status = "geplant";
            }

            int neueId = ErmittleNaechsteId(StundenDatei);

            string zeile = string.Join(";", neueId, schuelerId, lehrer,
                datum.ToString("s"), dauer, preis, zahlungsstatus, status);
            File.AppendAllLines(StundenDatei, new[] { zeile });

            Console.WriteLine($"Unterrichtsstunde wurde mit ID {neueId} gespeichert.");
        }


        static void UnterrichtsstundenAnzeigen()
        {
            Console.WriteLine();
            Console.WriteLine("--- Alle Unterrichtsstunden ---");

            if (!File.Exists(StundenDatei))
            {
                Console.WriteLine("Es wurden noch keine Unterrichtsstunden erfasst.");
                return;
            }
        }


        static int LeseIntMitWiederholung(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string eingabe = Console.ReadLine();
                if (int.TryParse(eingabe, out int wert))
                {
                    return wert;
                }
                Console.WriteLine("Bitte geben Sie eine gültige ganze Zahl ein.");
            }
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
