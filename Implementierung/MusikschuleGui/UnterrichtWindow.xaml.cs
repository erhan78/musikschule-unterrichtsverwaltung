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

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schliessen_Click(object sender, RoutedEventArgs e)
        {

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
