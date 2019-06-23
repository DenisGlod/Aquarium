using Aquarium.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Model
{
    // Класс контекст базы данных
    class AquariumContext : DbContext
    {
        // Инициализация базы данных
        static AquariumContext()
        {
            Database.SetInitializer(new AquariumInitializer());
        }

        // "DbConnection" - указывает какой connection брать из файла App.config
        public AquariumContext() : base("DbConnection") { }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Fish> Fishes { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

    }
}
