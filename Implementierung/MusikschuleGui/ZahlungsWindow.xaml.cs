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
    /// Interaktionslogik für ZahlungsWindow.xaml
    /// </summary>
    public partial class ZahlungsWindow : Window
    {
        private readonly MusikschuleContext _db = new();
        private ObservableCollection<Schueler> _schueler = new ObservableCollection<Schueler>();

        public ZahlungsWindow()
        {
            InitializeComponent();
            LadeSchueler();
        }

        private void LadeSchueler()
        {
            _schueler = new ObservableCollection<Schueler>(
                _db.Schueler.AsNoTracking()
                    .OrderBy(s => s.Nachname).ThenBy(s => s.Vorname));

            cbSchueler.ItemsSource = _schueler;

            if (_schueler.Any())
            {
                cbSchueler.SelectedIndex = 0;
            }
            else
            {
                txtSummeAlle.Text = "Keine Schüler vorhanden.";
                txtSummeOffen.Text = "";
            }
        }

        private void AktualisiereUebersicht()
        {
            if (cbSchueler.SelectedItem is not Schueler s)
            {
                dgStunden.ItemsSource = null;
                txtSummeAlle.Text = "";
                txtSummeOffen.Text = "";
                return;
            }

            var stunden = _db.Unterrichtsstunden
                .Include(u => u.Lehrer)
                .Where(u => u.SchuelerId == s.SchuelerId)
                .AsNoTracking()
                .OrderBy(u => u.DatumUhrzeit)
                .ToList();

            dgStunden.ItemsSource = stunden;

            decimal sumAlle = stunden.Sum(u => u.Betrag);
            decimal sumOffen = stunden
                .Where(u => string.Equals(u.Zahlungsstatus, "offen", StringComparison.OrdinalIgnoreCase))
                .Sum(u => u.Betrag);

            var culture = CultureInfo.GetCultureInfo("de-DE");
            txtSummeAlle.Text = $"Summe aller Stunden: {sumAlle.ToString("C", culture)}";
            txtSummeOffen.Text = $"Davon offen: {sumOffen.ToString("C", culture)}";
        }

        private void cbSchueler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AktualisiereUebersicht();
        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
