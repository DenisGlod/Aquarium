using Aquarium.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Model
{
    class AquariumInitializer : DropCreateDatabaseAlways<AquariumContext>
    {
        // Инициализируем базу данных начальными значениями
        protected override void Seed(AquariumContext context)
        {
            var fish1 = new Fish { Name = "Карась", Type = "Серебряный карась" };
            var fish2 = new Fish { Name = "Сазан", Type = "Пресноводная" };
            var fish3 = new Fish { Name = "Гуппи", Type = "Пресноводная" };
            var plant1 = new Plant { Name = "Водоросли", Type = "Ундария перистая" };
            var plant2 = new Plant { Name = "Водоросли", Type = "Диатомовые водоросли" };
            var plant3 = new Plant { Name = "Водоросли", Type = "Фукус пузырчатый" };
            context.Fishes.Add(fish1);
            context.Fishes.Add(fish2);
            context.Fishes.Add(fish3);
            context.Plants.Add(plant1);
            context.Plants.Add(plant2);
            context.Plants.Add(plant3);
            context.SaveChanges();
            var stat1 = new Statistic { DateTime = DateTime.UtcNow, Population = 10, Nutrition = "3 раза в день", LivingСonditions = "Нормальная", FishId = 1, Fish = fish1 };
            var stat2 = new Statistic { DateTime = DateTime.UtcNow, Population = 9, Nutrition = "3 раза в день", LivingСonditions = "Нормальная", PlantId = 1, Plant = plant1 };
            context.Statistics.Add(stat1);
            context.Statistics.Add(stat2);
            context.SaveChanges();
        }
    }
}
