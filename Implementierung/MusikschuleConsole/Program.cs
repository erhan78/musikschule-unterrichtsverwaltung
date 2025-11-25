namespace MusikschuleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menue();
                Console.ReadLine();
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
    }
}
