using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Management
{
    public partial class AddChildForm : Form
    {
        private readonly MainForm mainForm;
        public AddChildForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            String name;
            int age;
            String bdd;
            
            try
            {
                name = nameTextBox.Text;               
                age = Convert.ToInt32(ageTextBox.Text);               
                bdd = dateTimePicker1.Text;
            }
            catch
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }

            if (!(mainForm.ChildDataCheck(age)))
            {
                return;
            }

            AddData("Names.txt", name);
            AddData("Age.txt", age.ToString());
            AddData("BDD.txt", bdd);

            mainForm.AddChildToList(name, age, bdd);
            mainForm.LimitCheck();

            mainForm.Enabled = true;
            this.Close();
        }

        private void AddData(String fileName, String data)
        {
            using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\" + fileName, true))
            {
                streamWriter.Write(data + "\n");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
