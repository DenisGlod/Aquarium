using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Model.Entity
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }

        public Plant()
        {
            Statistics = new List<Statistic>();
        }
    }
}
