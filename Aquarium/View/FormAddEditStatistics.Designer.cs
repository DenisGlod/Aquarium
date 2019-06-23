namespace Aquarium.View
{
    partial class FormAddEditStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBLivingСonditions = new System.Windows.Forms.TextBox();
            this.TBNutrition = new System.Windows.Forms.TextBox();
            this.TBPopulation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.RBPlant = new System.Windows.Forms.RadioButton();
            this.RBFish = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBDateTime = new System.Windows.Forms.MaskedTextBox();
            this.BSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBLivingСonditions
            // 
            this.TBLivingСonditions.Location = new System.Drawing.Point(116, 38);
            this.TBLivingСonditions.Name = "TBLivingСonditions";
            this.TBLivingСonditions.Size = new System.Drawing.Size(100, 20);
            this.TBLivingСonditions.TabIndex = 1;
            // 
            // TBNutrition
            // 
            this.TBNutrition.Location = new System.Drawing.Point(116, 64);
            this.TBNutrition.Name = "TBNutrition";
            this.TBNutrition.Size = new System.Drawing.Size(100, 20);
            this.TBNutrition.TabIndex = 2;
            // 
            // TBPopulation
            // 
            this.TBPopulation.Location = new System.Drawing.Point(116, 90);
            this.TBPopulation.Name = "TBPopulation";
            this.TBPopulation.Size = new System.Drawing.Size(100, 20);
            this.TBPopulation.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TreeView);
            this.groupBox1.Controls.Add(this.RBPlant);
            this.groupBox1.Controls.Add(this.RBFish);
            this.groupBox1.Location = new System.Drawing.Point(16, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(6, 43);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(188, 91);
            this.TreeView.TabIndex = 3;
            // 
            // RBPlant
            // 
            this.RBPlant.AutoSize = true;
            this.RBPlant.Location = new System.Drawing.Point(101, 16);
            this.RBPlant.Name = "RBPlant";
            this.RBPlant.Size = new System.Drawing.Size(73, 17);
            this.RBPlant.TabIndex = 2;
            this.RBPlant.TabStop = true;
            this.RBPlant.Text = "Растения";
            this.RBPlant.UseVisualStyleBackColor = true;
            this.RBPlant.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RBFish
            // 
            this.RBFish.AutoSize = true;
            this.RBFish.Location = new System.Drawing.Point(32, 16);
            this.RBFish.Name = "RBFish";
            this.RBFish.Size = new System.Drawing.Size(54, 17);
            this.RBFish.TabIndex = 1;
            this.RBFish.TabStop = true;
            this.RBFish.Text = "Рыбы";
            this.RBFish.UseVisualStyleBackColor = true;
            this.RBFish.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата/Время:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Условия обиания:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Питание:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Популяция:";
            // 
            // TBDateTime
            // 
            this.TBDateTime.Location = new System.Drawing.Point(116, 12);
            this.TBDateTime.Mask = "00/00/0000 90:00";
            this.TBDateTime.Name = "TBDateTime";
            this.TBDateTime.Size = new System.Drawing.Size(100, 20);
            this.TBDateTime.TabIndex = 9;
            this.TBDateTime.ValidatingType = typeof(System.DateTime);
            // 
            // BSave
            // 
            this.BSave.Image = global::Aquarium.Properties.Resources.save;
            this.BSave.Location = new System.Drawing.Point(16, 265);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(200, 27);
            this.BSave.TabIndex = 10;
            this.BSave.Text = "Сохранить";
            this.BSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // FormAddEditStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 302);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.TBDateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TBPopulation);
            this.Controls.Add(this.TBNutrition);
            this.Controls.Add(this.TBLivingСonditions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddEditStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddEditStatistics";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBLivingСonditions;
        private System.Windows.Forms.TextBox TBNutrition;
        private System.Windows.Forms.TextBox TBPopulation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBPlant;
        private System.Windows.Forms.RadioButton RBFish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TBDateTime;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.TreeView TreeView;
    }
}