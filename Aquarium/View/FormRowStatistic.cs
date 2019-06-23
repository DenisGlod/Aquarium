using Aquarium.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquarium.View
{
    public partial class FormRowStatistic : Form
    {
        // Инициализыция формы
        public FormRowStatistic(string table, DataGridViewSelectedCellCollection selectedCells)
        {
            InitializeComponent();
            using (var context = new AquariumContext())
            {
                int key = int.Parse(selectedCells[0].Value.ToString());
                switch (table)
                {
                    case "Fish":
                        DataGridView.DataSource = context.Statistics.Where(s => s.FishId == key).ToList();
                        break;
                    case "Plant":
                        DataGridView.DataSource = context.Statistics.Where(s => s.PlantId == key).ToList();
                        break;
                }
                DataGridView.Columns["Fish"].Visible = false;
                DataGridView.Columns["Plant"].Visible = false;
                DataGridView.Columns["Plant"].Visible = false;
                DataGridView.Columns["Id"].HeaderText = "№";
                DataGridView.Columns["DateTime"].HeaderText = "Дата/Время";
                DataGridView.Columns["LivingСonditions"].HeaderText = "Условия обитания";
                DataGridView.Columns["Nutrition"].HeaderText = "Питание";
                DataGridView.Columns["Population"].HeaderText = "Популяция";
                DataGridView.Columns["FishId"].Visible = false;
                DataGridView.Columns["PlantId"].Visible = false;
                DataGridView.Refresh();
            }
        }
    }
}
