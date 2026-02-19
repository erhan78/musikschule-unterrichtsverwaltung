using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikschuleGui.Data
{
    public class MusikschuleContext : DbContext
    {
        public DbSet<Schueler> Schueler { get; set; }
        public DbSet<Lehrer> Lehrer { get; set; }
        public DbSet<Unterrichtsstunde> Unterrichtsstunden { get; set; }

        private readonly string _dbPath;

        public MusikschuleContext()
        {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Musikschule");

            Directory.CreateDirectory(folder);
            _dbPath = Path.Combine(folder, "musikschule.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
