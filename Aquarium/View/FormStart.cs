using Aquarium.Model;
using Aquarium.View;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Aquarium
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
            InitDGVFish();
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    new FormAddEdit(this, ActionParameters.AddFish).Show();
                    break;
                case 1:
                    new FormAddEdit(this, ActionParameters.AddPlant).Show();
                    break;
                case 2:
                    new FormAddEditStatistics(this, ActionParameters.AddStatistics).Show();
                    break;
            }
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    new FormAddEdit(this, ActionParameters.EditFish, DGVFish.SelectedCells).Show();
                    break;
                case 1:
                    new FormAddEdit(this, ActionParameters.EditPlant, DGVPlant.SelectedCells).Show();
                    break;
                case 2:
                    new FormAddEditStatistics(this, ActionParameters.EditStatistics, DGVStatistics.SelectedCells).Show();
                    break;
            }
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            using (var context = new AquariumContext())
            {
                DialogResult dr = MessageBox.Show("Подтверждение удаления!", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    switch (TabControl.SelectedIndex)
                    {
                        case 0:
                            foreach (DataGridViewRow row in DGVFish.SelectedRows)
                            {
                                var deleteFish = context.Fishes.Find(row.Cells[0].Value);
                                deleteFish.Statistics.Clear();
                                context.Fishes.Remove(deleteFish);
                            }
                            context.SaveChanges();
                            InitDGVFish();
                            break;
                        case 1:
                            foreach (DataGridViewRow row in DGVPlant.SelectedRows)
                            {
                                var deletePlant = context.Plants.Find(row.Cells[0].Value);
                                deletePlant.Statistics.Clear();
                                context.Plants.Remove(deletePlant);
                            }
                            context.SaveChanges();
                            InitDGVPlants();
                            break;
                        case 2:
                            foreach (DataGridViewRow row in DGVStatistics.SelectedRows)
                            {
                                var deleteStatistics = context.Statistics.Find(row.Cells[0].Value);
                                context.Statistics.Remove(deleteStatistics);
                            }
                            context.SaveChanges();
                            InitDGVStatistics();
                            break;
                    }
                }
            }
        }

        private void MenuItemExcel_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    DGVFish.SelectAll();
                    var data0 = DGVFish.GetClipboardContent();
                    if (data0 != null)
                        Clipboard.SetDataObject(data0);
                    break;
                case 1:
                    DGVPlant.SelectAll();
                    var data1 = DGVPlant.GetClipboardContent();
                    if (data1 != null)
                        Clipboard.SetDataObject(data1);
                    break;
                case 2:
                    DGVStatistics.SelectAll();
                    var data2 = DGVStatistics.GetClipboardContent();
                    if (data2 != null)
                        Clipboard.SetDataObject(data2);
                    break;
            }
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application { Visible = true };
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Аквариум'\r\n\r\nПзволяет собирать сведения о динамике\r\nрастительного и животного мира.\r\n\r\nCopyright © 2019", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    InitDGVFish();
                    break;
                case 1:
                    InitDGVPlants();
                    break;
                case 2:
                    InitDGVStatistics();
                    break;
            }
        }

        public void InitDGVFish()
        {
            using (var context = new AquariumContext())
            {
                context.Fishes.Load();
                DGVFish.DataSource = context.Fishes.Local.ToBindingList();
                DGVFish.Columns["Statistics"].Visible = false;
                DGVFish.Columns["Id"].HeaderText = "№";
                DGVFish.Columns["Name"].HeaderText = "Название";
                DGVFish.Columns["Type"].HeaderText = "Разновидность";
                DGVFish.Refresh();
            }
        }

        public void InitDGVPlants()
        {
            using (var context = new AquariumContext())
            {
                context.Plants.Load();
                DGVPlant.DataSource = context.Plants.Local.ToBindingList();
                DGVPlant.Columns["Statistics"].Visible = false;
                DGVPlant.Columns["Id"].HeaderText = "№";
                DGVPlant.Columns["Name"].HeaderText = "Название";
                DGVPlant.Columns["Type"].HeaderText = "Разновидность";
                DGVPlant.Refresh();
            }
        }

        public void InitDGVStatistics()
        {
            using (var context = new AquariumContext())
            {
                context.Statistics.Load();
                DGVStatistics.DataSource = context.Statistics.Local.ToBindingList();
                DGVStatistics.Columns["Fish"].Visible = false;
                DGVStatistics.Columns["Plant"].Visible = false;
                DGVStatistics.Columns["Plant"].Visible = false;
                DGVStatistics.Columns["Id"].HeaderText = "№";
                DGVStatistics.Columns["DateTime"].HeaderText = "Дата/Время";
                DGVStatistics.Columns["LivingСonditions"].HeaderText = "Условия обитания";
                DGVStatistics.Columns["Nutrition"].HeaderText = "Питание";
                DGVStatistics.Columns["Population"].HeaderText = "Популяция";
                DGVStatistics.Columns["FishId"].HeaderText = "№ рыбы";
                DGVStatistics.Columns["PlantId"].HeaderText = "№ водоросли";
                DGVStatistics.Refresh();
            }
        }

        private void DGView_DoubleClick(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    new FormRowStatistic("Fish", DGVFish.SelectedCells).Show();
                    break;
                case 1:
                    new FormRowStatistic("Plant", DGVPlant.SelectedCells).Show();
                    break;
            }
        }
    }
}
