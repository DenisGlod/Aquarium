using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Model.Entity
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string LivingСonditions { get; set; }
        [Required]
        public string Nutrition { get; set; }
        [Required]
        public int Population { get; set; }
        public int? FishId { get; set; }
        public virtual Fish Fish { get; set; }

        public int? PlantId { get; set; }
        public virtual Plant Plant { get; set; }

    }
}
