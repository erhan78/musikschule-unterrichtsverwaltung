using MusikschuleGui.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MusikschuleGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = new MusikschuleContext())
            {
                db.Database.EnsureCreated();

                if (!db.Lehrer.Any())
                {
                    SeedDaten(db);
                }
            }
        }



        private void SeedDaten(MusikschuleContext db)
        {
            var l1 = new Lehrer { Vorname = "Anna", Nachname = "Meier", Fachgebiet = "Klavier" };
            var l2 = new Lehrer { Vorname = "Thomas", Nachname = "Schulz", Fachgebiet = "Gitarre" };
            var l3 = new Lehrer { Vorname = "Laura", Nachname = "Weber", Fachgebiet = "Violine" };

            db.Lehrer.AddRange(l1, l2, l3);

            var s1 = new Schueler { Vorname = "Max", Nachname = "Müller", Instrument = "Klavier" };
            var s2 = new Schueler { Vorname = "Sophie", Nachname = "Schneider", Instrument = "Gitarre" };
            var s3 = new Schueler { Vorname = "Leon", Nachname = "Fischer", Instrument = "Violine" };

            db.Schueler.AddRange(s1, s2, s3);
            db.SaveChanges();

            db.Unterrichtsstunden.Add(new Unterrichtsstunde
            {
                SchuelerId = s1.SchuelerId,
                LehrerId = l1.LehrerId,
                DatumUhrzeit = DateTime.Today.AddHours(15),
                DauerMinuten = 45,
                PreisProStunde = 40m,
                Status = "durchgeführt",
                Zahlungsstatus = "bezahlt"
            });

            db.Unterrichtsstunden.Add(new Unterrichtsstunde
            {
                SchuelerId = s2.SchuelerId,
                LehrerId = l2.LehrerId,
                DatumUhrzeit = DateTime.Today.AddDays(1).AddHours(16),
                DauerMinuten = 60,
                PreisProStunde = 35m,
                Status = "geplant",
                Zahlungsstatus = "offen"
            });

            db.Unterrichtsstunden.Add(new Unterrichtsstunde
            {
                SchuelerId = s3.SchuelerId,
                LehrerId = l3.LehrerId,
                DatumUhrzeit = DateTime.Today.AddDays(2).AddHours(17),
                DauerMinuten = 30,
                PreisProStunde = 30m,
                Status = "geplant",
                Zahlungsstatus = "offen"
            });

            db.SaveChanges();
        }
    
    }

}
