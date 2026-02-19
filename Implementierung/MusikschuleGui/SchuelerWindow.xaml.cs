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

        }

        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schliessen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
