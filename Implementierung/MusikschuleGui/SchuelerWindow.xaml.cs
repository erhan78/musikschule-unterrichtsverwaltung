using Microsoft.EntityFrameworkCore;
using MusikschuleGui.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für SchuelerWindow.xaml
    /// </summary>
    public partial class SchuelerWindow : Window
    {
        private readonly MusikschuleContext _db = new();
        private ObservableCollection<Schueler> _schuelerListe = new ObservableCollection<Schueler>();
        private Schueler? _ausgewaehlter;

        public SchuelerWindow()
        {
            InitializeComponent();
            LadeSchueler();
        }

        private void LadeSchueler()
        {
            _schuelerListe = new ObservableCollection<Schueler>(
                _db.Schueler.AsNoTracking().OrderBy(s => s.Nachname).ThenBy(s => s.Vorname));
            dgSchueler.ItemsSource = _schuelerListe;
        }
        private void SpeicherButton_Click(object sender, RoutedEventArgs e)
        {
            var neu = new Schueler
            {
                Vorname = txtVorname.Text.Trim(),
                Nachname = txtNachname.Text.Trim(),
                Instrument = txtInstrument.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim()
            };

            _db.Schueler.Add(neu);

            _db.SaveChanges();
            LadeSchueler();
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            _ausgewaehlter = null;
            txtVorname.Text = "";
            txtNachname.Text = "";
            txtInstrument.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
        }

        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (_ausgewaehlter == null)
            {
                MessageBox.Show("Bitte wählen Sie zuerst einen Schüler aus.",
                                "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (MessageBox.Show("Schüler wirklich löschen?",
                                "Bestätigung", MessageBoxButton.YesNo, MessageBoxImage.Question)
                != MessageBoxResult.Yes)
                return;

            var s = _db.Schueler.Find(_ausgewaehlter.SchuelerId);
            if (s != null)
            {
                _db.Schueler.Remove(s);
                _db.SaveChanges();
                LadeSchueler();
                Neu_Click(sender, e);
            }
        }

        private void Schliessen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgSchueler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ausgewaehlter = dgSchueler.SelectedItem as Schueler;
            if (_ausgewaehlter == null) return;

            txtVorname.Text = _ausgewaehlter.Vorname;
            txtNachname.Text = _ausgewaehlter.Nachname;
            txtInstrument.Text = _ausgewaehlter.Instrument;
            txtEmail.Text = _ausgewaehlter.Email;
            txtTelefon.Text = _ausgewaehlter.Telefon;
        }
    }
}
