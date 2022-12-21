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
        MainForm mainForm;
        private ListBox listBox;
        public AddChildForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }

        private void confirmButton_Click(object sender, EventArgs e)
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

            mainForm.AddData("Names.txt", name);
            mainForm.AddData("Age.txt", age);
            mainForm.AddData("BDD.txt", bdd);
          
            listBox.Items.Add(name
                + "   |   " + age
                + "   |   " + bdd);

            mainForm.LimitCheck();

            mainForm.Enabled = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
