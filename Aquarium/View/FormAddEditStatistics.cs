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
using Aquarium.Model;
using Aquarium.Model.Entity;

namespace Aquarium.View
{
    public partial class FormAddEditStatistics : Form
    {
        private readonly FormStart fsClass;
        private readonly ActionParameters param;
        private readonly DataGridViewSelectedCellCollection selectedCells;

        // Инициализация формы
        public FormAddEditStatistics(FormStart fsClass, ActionParameters param)
        {
            InitializeComponent();
            this.fsClass = fsClass;
            this.param = param;
            switch (param)
            {
                case ActionParameters.AddStatistics:
                    Text = "Добавить";
                    Icon = Icon.FromHandle(Properties.Resources.plus.GetHicon());
                    break;
                case ActionParameters.EditStatistics:
                    Text = "Редактировать";
                    Icon = Icon.FromHandle(Properties.Resources.edit.GetHicon());
                    break;
            }
        }

        // Инициализация формы если выбрана строка в DataGridView на форме FormStart
        public FormAddEditStatistics(FormStart fsClass, ActionParameters param, DataGridViewSelectedCellCollection selectedCells) : this(fsClass, param)
        {
            this.selectedCells = selectedCells;
            TBDateTime.Text = selectedCells[1].Value.ToString();
            TBLivingСonditions.Text = selectedCells[2].Value.ToString();
            TBNutrition.Text = selectedCells[3].Value.ToString();
            TBPopulation.Text = selectedCells[4].Value.ToString();
            var fish = selectedCells[5].Value;
            var plant = selectedCells[7].Value;

            if (fish != null)
            {
                RBFish.Checked = true;
            }
            if (plant != null)
            {
                RBPlant.Checked = true;
            }
        }

        // Сохранение данных
        private void BSave_Click(object sender, EventArgs e)
        {
            var dateTime = TBDateTime.Text;
            var livingСonditions = TBLivingСonditions.Text;
            var nutrition = TBNutrition.Text;
            var population = TBPopulation.Text;
            var key = TreeView.SelectedNode != null ? int.Parse(TreeView.SelectedNode.Name) : -1;
            if (dateTime.Equals("") || livingСonditions.Equals("") || nutrition.Equals("") || population.Equals("") || key == -1)
            {
                MessageBox.Show("Укажите все параметры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var stat = new Statistic();
            using (var context = new AquariumContext())
            {
                switch (param)
                {
                    case ActionParameters.AddStatistics:
                        stat.DateTime = Convert.ToDateTime(dateTime);
                        stat.LivingСonditions = livingСonditions;
                        stat.Nutrition = nutrition;
                        stat.Population = int.Parse(population);
                        if (RBFish.Checked) stat.FishId = key;
                        if (RBPlant.Checked) stat.PlantId = key;
                        context.Statistics.Add(stat);
                        break;
                    case ActionParameters.EditStatistics:
                        stat = context.Statistics.Find(selectedCells[0].Value);
                        stat.DateTime = Convert.ToDateTime(dateTime);
                        stat.LivingСonditions = livingСonditions;
                        stat.Nutrition = nutrition;
                        stat.Population = int.Parse(population);
                        if (RBFish.Checked) { stat.FishId = key; stat.PlantId = null; }
                        if (RBPlant.Checked) { stat.PlantId = key; stat.FishId = null; }
                        break;
                }
                context.SaveChanges();
            }
            Hide();
            fsClass.InitDGVStatistics();
        }

        // Выбор Node'ы в TreeView
        private void SelectedNode(TreeNode node)
        {
            if (node != null)
            {
                TreeView.Select();
                TreeView.SelectedNode = node;
            }
        }

        // Действие при смене RadioButton
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new AquariumContext())
            {
                TreeView.Nodes.Clear();
                if (RBFish.Checked)
                {
                    var listFish = context.Fishes.ToList();
                    switch (param)
                    {
                        case ActionParameters.AddStatistics:
                            listFish.ForEach(item => { TreeView.Nodes.Add(item.Id.ToString(), item.Id + " | " + item.Name + " | " + item.Type); });
                            break;
                        case ActionParameters.EditStatistics:
                            var fish = selectedCells[5].Value;
                            listFish.ForEach(item =>
                            {
                                var tn = TreeView.Nodes.Add(item.Id.ToString(), item.Id + " | " + item.Name + " | " + item.Type);
                                if (fish != null && item.Id == (int)fish)
                                {
                                    SelectedNode(tn);
                                }
                            });
                            break;
                    }
                }
                if (RBPlant.Checked)
                {
                    var listPlants = context.Plants.ToList();
                    switch (param)
                    {
                        case ActionParameters.AddStatistics:
                            listPlants.ForEach(item => { TreeView.Nodes.Add(item.Id.ToString(), item.Id + " | " + item.Name + " | " + item.Type); });
                            break;
                        case ActionParameters.EditStatistics:
                            var plants = selectedCells[7].Value;
                            listPlants.ForEach(item =>
                            {
                                var tn = TreeView.Nodes.Add(item.Id.ToString(), item.Id + " | " + item.Name + " | " + item.Type);
                                if (plants != null && RBPlant.Checked && item.Id == (int)plants)
                                {
                                    SelectedNode(tn);
                                }
                            });
                            break;
                    }
                }
            }
        }
    }
}
