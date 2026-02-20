using Microsoft.EntityFrameworkCore;
using MusikschuleGui.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusikschuleGui
{
    /// <summary>
    /// Interaktionslogik für UnterrichtWindow.xaml
    /// </summary>
    public partial class UnterrichtWindow : Window
    {
        private readonly MusikschuleContext _db = new();

        private ObservableCollection<Unterrichtsstunde> _stunden = new ObservableCollection<Unterrichtsstunde>();

        private ObservableCollection<Schueler> _schueler = new ObservableCollection<Schueler>();

        private ObservableCollection<Lehrer> _lehrer = new ObservableCollection<Lehrer>();

        private Unterrichtsstunde? _ausgewaehlteStunde;
        public UnterrichtWindow()
        {
            InitializeComponent();
            LadeStammdaten();
            LadeUnterrichtsstunden();
        }

        private void LadeStammdaten()
        {
            _schueler = new ObservableCollection<Schueler>(
                _db.Schueler.AsNoTracking()
                    .OrderBy(s => s.Nachname).ThenBy(s => s.Vorname));
            _lehrer = new ObservableCollection<Lehrer>(
                _db.Lehrer.AsNoTracking()
                    .OrderBy(l => l.Nachname).ThenBy(l => l.Vorname));

            cbSchueler.ItemsSource = _schueler;
            cbLehrer.ItemsSource = _lehrer;
        }

        private void LadeUnterrichtsstunden()
        {
            _stunden = new ObservableCollection<Unterrichtsstunde>(
                _db.Unterrichtsstunden
                    .Include(u => u.Schueler)
                    .Include(u => u.Lehrer)
                    .AsNoTracking()
                    .OrderBy(u => u.DatumUhrzeit));

            dgStunden.ItemsSource = _stunden;
        }

        private void NeuFormular()
        {
            _ausgewaehlteStunde = null;
            dpDatum.SelectedDate = DateTime.Today;
            txtUhrzeit.Text = "15:00";
            txtDauer.Text = "45";
            txtPreis.Text = "40,00";
            cbStatus.SelectedIndex = 0;
            cbZahlung.SelectedIndex = 0;
            cbSchueler.SelectedIndex = _schueler.Any() ? 0 : -1;
            cbLehrer.SelectedIndex = _lehrer.Any() ? 0 : -1;
        }



        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            NeuFormular();
        }
        private bool PruefeEingaben(out Schueler schueler, out Lehrer lehrer,
                                    out DateTime datumUhrzeit,
                                    out int dauer, out decimal preis,
                                    out string status, out string zahlung)
        {
            schueler = null!;
            lehrer = null!;
            datumUhrzeit = DateTime.MinValue;
            dauer = 0;
            preis = 0;
            status = "";
            zahlung = "";

            if (cbSchueler.SelectedItem is not Schueler s)
            {
                MessageBox.Show("Bitte wählen Sie einen Schüler aus.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (cbLehrer.SelectedItem is not Lehrer l)
            {
                MessageBox.Show("Bitte wählen Sie einen Lehrer aus.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (dpDatum.SelectedDate == null)
            {
                MessageBox.Show("Bitte wählen Sie ein Datum.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!TimeSpan.TryParse(txtUhrzeit.Text, out var zeit))
            {
                MessageBox.Show("Bitte geben Sie eine gültige Uhrzeit ein.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            datumUhrzeit = dpDatum.SelectedDate.Value.Date + zeit;

            if (!int.TryParse(txtDauer.Text, out dauer) || dauer <= 0 || dauer > 300)
            {
                MessageBox.Show("Die Dauer muss eine positive Zahl zwischen 1 und 300 Minuten sein.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!decimal.TryParse(txtPreis.Text, NumberStyles.Number,
                    CultureInfo.GetCultureInfo("de-DE"), out preis) || preis <= 0 || preis > 200)
            {
                MessageBox.Show("Der Preis pro Stunde muss eine positive Zahl sein.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (cbStatus.SelectedItem is ComboBoxItem statusItem)
                status = statusItem.Content?.ToString() ?? "geplant";
            else
                status = "geplant";

            if (cbZahlung.SelectedItem is ComboBoxItem zahlungItem)
                zahlung = zahlungItem.Content?.ToString() ?? "offen";
            else
                zahlung = "offen";

            schueler = s;
            lehrer = l;
            return true;
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
                if (!PruefeEingaben(out var schueler, out var lehrer, out var datumUhrzeit,
                    out var dauer, out var preis, out var status, out var zahlung))
                {
                    return;
            }

            if (_ausgewaehlteStunde == null)
            {
                var neu = new Unterrichtsstunde
                {
                    SchuelerId = schueler.SchuelerId,
                    LehrerId = lehrer.LehrerId,
                    DatumUhrzeit = datumUhrzeit,
                    DauerMinuten = dauer,
                    PreisProStunde = preis,
                    Status = status,
                    Zahlungsstatus = zahlung
                };
                _db.Unterrichtsstunden.Add(neu);
            }
            else
            {
                var u = _db.Unterrichtsstunden.Find(_ausgewaehlteStunde.UnterrichtsstundeId);
                if (u == null)
                {
                    MessageBox.Show("Die ausgewählte Unterrichtsstunde existiert nicht mehr.",
                        "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    LadeUnterrichtsstunden();
                    NeuFormular();
                    return;
                }

                u.SchuelerId = schueler.SchuelerId;
                u.LehrerId = lehrer.LehrerId;
                u.DatumUhrzeit = datumUhrzeit;
                u.DauerMinuten = dauer;
                u.PreisProStunde = preis;
                u.Status = status;
                u.Zahlungsstatus = zahlung;
            }

            _db.SaveChanges();
            LadeUnterrichtsstunden();
            NeuFormular();
        }

        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (_ausgewaehlteStunde == null)
            {
                MessageBox.Show("Bitte wählen Sie zuerst eine Unterrichtsstunde aus.",
                    "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (MessageBox.Show("Unterrichtsstunde wirklich löschen?",
                    "Bestätigung", MessageBoxButton.YesNo, MessageBoxImage.Question)
                != MessageBoxResult.Yes)
                return;

            var u = _db.Unterrichtsstunden.Find(_ausgewaehlteStunde.UnterrichtsstundeId);
            if (u != null)
            {
                _db.Unterrichtsstunden.Remove(u);
                _db.SaveChanges();
                LadeUnterrichtsstunden();
                NeuFormular();
            }
        }

        private void Schliessen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgStunden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ausgewaehlteStunde = dgStunden.SelectedItem as Unterrichtsstunde;
            if (_ausgewaehlteStunde == null) return;

            var u = _db.Unterrichtsstunden
                .Include(x => x.Schueler)
                .Include(x => x.Lehrer)
                .FirstOrDefault(x => x.UnterrichtsstundeId == _ausgewaehlteStunde.UnterrichtsstundeId);

            if (u == null) return;

            cbSchueler.SelectedItem = _schueler.First(s => s.SchuelerId == u.SchuelerId);
            cbLehrer.SelectedItem = _lehrer.First(l => l.LehrerId == u.LehrerId);
            dpDatum.SelectedDate = u.DatumUhrzeit.Date;
            txtUhrzeit.Text = u.DatumUhrzeit.ToString("HH:mm");
            txtDauer.Text = u.DauerMinuten.ToString(CultureInfo.InvariantCulture);
            txtPreis.Text = u.PreisProStunde.ToString("F2", CultureInfo.GetCultureInfo("de-DE"));
            cbStatus.SelectedItem = cbStatus.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(i => (string)i.Content == u.Status);
            cbZahlung.SelectedItem = cbZahlung.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(i => (string)i.Content == u.Zahlungsstatus);
        }
    }
}
