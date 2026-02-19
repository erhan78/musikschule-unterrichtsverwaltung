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

                // TODO: Seed initial data
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}
