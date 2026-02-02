using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikschuleGui.Data
{
    public class MusikschuleContext
    {
        public DbSet<Schueler> Schueler { get; set; }
        public DbSet<Lehrer> Lehrer { get; set; }
        public DbSet<Unterrichtsstunde> Unterrichtsstunden { get; set; }
        

        public MusikschuleContext()
        {

        }
    }
}
