
namespace Group_Management
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeParamButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(15, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(515, 441);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список групп";
            // 
            // sortButton
            // 
            this.sortButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortButton.Location = new System.Drawing.Point(3, 207);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(280, 45);
            this.sortButton.TabIndex = 0;
            this.sortButton.Text = "Сортировать группы";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(280, 45);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить группу";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteButton);
            this.flowLayoutPanel1.Controls.Add(this.changeParamButton);
            this.flowLayoutPanel1.Controls.Add(this.moveButton);
            this.flowLayoutPanel1.Controls.Add(this.sortButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(585, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 255);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(3, 54);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(280, 45);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить группу";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // changeParamButton
            // 
            this.changeParamButton.Enabled = false;
            this.changeParamButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeParamButton.Location = new System.Drawing.Point(3, 105);
            this.changeParamButton.Name = "changeParamButton";
            this.changeParamButton.Size = new System.Drawing.Size(280, 45);
            this.changeParamButton.TabIndex = 3;
            this.changeParamButton.Text = "Изменить параметры группы";
            this.changeParamButton.UseVisualStyleBackColor = true;
            // 
            // moveButton
            // 
            this.moveButton.Enabled = false;
            this.moveButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moveButton.Location = new System.Drawing.Point(3, 156);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(280, 45);
            this.moveButton.TabIndex = 4;
            this.moveButton.Text = "Перемесить ребёнка";
            this.moveButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "По имени",
            "По направлению",
            "По возрасту",
            "По кол-ву свободных мест"});
            this.comboBox1.Location = new System.Drawing.Point(585, 355);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(288, 31);
            this.comboBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 501);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.Text = "Ведение групп";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeParamButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

