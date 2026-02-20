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

        private void cbSchueler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
