using Aquarium.Model;
using Aquarium.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquarium
{
    public partial class FormAddEdit : Form
    {
        private readonly FormStart fsClass;
        private readonly ActionParameters param;
        private readonly DataGridViewSelectedCellCollection selectedCells;

        // Начальная инициаллизыция формы
        public FormAddEdit(FormStart fsClass, ActionParameters param)
        {
            InitializeComponent();
            this.fsClass = fsClass;
            this.param = param;
            switch (param)
            {
                case ActionParameters.AddFish:
                case ActionParameters.AddPlant:
                    Text = "Добавить";
                    Icon = Icon.FromHandle(Properties.Resources.plus.GetHicon());
                    break;
                case ActionParameters.EditFish:
                case ActionParameters.EditPlant:
                    Text = "Редактировать";
                    Icon = Icon.FromHandle(Properties.Resources.edit.GetHicon());
                    break;
            }
        }

        // Инициализация формы если выбрана строка в DataGridView на форме FormStart
        public FormAddEdit(FormStart fsClass, ActionParameters param, DataGridViewSelectedCellCollection selectedCells) : this(fsClass, param)
        {
            this.selectedCells = selectedCells;
            switch (param)
            {
                case ActionParameters.EditFish:
                case ActionParameters.EditPlant:
                    TBName.Text = selectedCells[1].Value.ToString();
                    TBType.Text = selectedCells[2].Value.ToString();
                    break;
            }
        }

        // Кнопка сохранения данных
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var name = TBName.Text;
            var type = TBType.Text;
            using (var context = new AquariumContext())
            {
                switch (param)
                {
                    case ActionParameters.AddFish:
                        context.Fishes.Add(new Fish { Name = name, Type = type });
                        break;
                    case ActionParameters.AddPlant:
                        context.Plants.Add(new Plant { Name = name, Type = type });
                        break;
                    case ActionParameters.EditFish:
                        var fish = context.Fishes.Find(selectedCells[0].Value);
                        fish.Name = name;
                        fish.Type = type;
                        context.Entry(fish).State = EntityState.Modified;
                        break;
                    case ActionParameters.EditPlant:
                        var plant = context.Plants.Find(selectedCells[0].Value);
                        plant.Name = name;
                        plant.Type = type;
                        context.Entry(plant).State = EntityState.Modified;
                        break;
                }
                context.SaveChanges();
            }
            Hide();
            switch (param)
            {
                case ActionParameters.AddFish:
                case ActionParameters.EditFish:
                    fsClass.InitDGVFish();
                    break;
                case ActionParameters.AddPlant:
                case ActionParameters.EditPlant:
                    fsClass.InitDGVPlants();
                    break;
            }
            
        }
    }
}
