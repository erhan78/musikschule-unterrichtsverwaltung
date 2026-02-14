using MusikschuleGui.Data;
using System;
using System.Collections.Generic;
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

        public SchuelerWindow()
        {
            InitializeComponent();
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
        }
    }
}
