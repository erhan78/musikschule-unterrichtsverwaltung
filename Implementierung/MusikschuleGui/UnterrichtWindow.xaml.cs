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
    /// Interaktionslogik für UnterrichtWindow.xaml
    /// </summary>
    public partial class UnterrichtWindow : Window
    {
        private readonly MusikschuleContext _db = new();

        private ObservableCollection<Unterrichtsstunde> _stunden = new ObservableCollection<Unterrichtsstunde>();

        private ObservableCollection<Schueler> _schueler = new ObservableCollection<Schueler>();

        private ObservableCollection<Lehrer> _lehrer = new ObservableCollection<Lehrer>();
        
        public UnterrichtWindow()
        {
            InitializeComponent();
            LadeStammdaten();
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


        private void Neu_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
