using System.Security.Cryptography.X509Certificates;

namespace MusikschuleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menue();
                Console.ReadLine();
                string eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        // SchülerAnlegen();
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
