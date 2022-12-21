using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.Mime.MediaTypeNames;

namespace Group_Management
{
    public partial class AddGroupForm : Form
    {
        MainForm mainForm;
        private ListBox listBox;
        public AddGroupForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            String name;
            String course;
            int minAge;
            int maxAge;
            int maxAmount;       
            
            try
            {
                name = nameTextBox.Text;        
                course = courseTextBox.Text;
                minAge = Convert.ToInt32(minAgeTextBox.Text);
                maxAge = Convert.ToInt32(maxAgeTextBox.Text);
                maxAmount = Convert.ToInt32(maxAmountTextBox.Text);

            }
            catch 
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }     

            if(!(mainForm.GroupDataCheck(name, minAge, maxAge, maxAmount)))
            {
                return;
            }
        
            Directory.CreateDirectory("Data\\" + name + "\\");

            try
            {
                FileStream fileStreamOfNames = null;
                FileStream fileStreamOfAge = null;
                FileStream fileStreamOfBDD = null;

                FileInfo fileInfoOfNames = new FileInfo("Data\\" + name + "\\Names.txt");
                FileInfo fileInfoOfAge = new FileInfo("Data\\" + name + "\\Age.txt");
                FileInfo fileInfoOfBDD = new FileInfo("Data\\" + name + "\\BDD.txt");

                fileStreamOfNames = fileInfoOfNames.Create();
                fileStreamOfAge = fileInfoOfAge.Create();
                fileStreamOfBDD = fileInfoOfBDD.Create();

                fileStreamOfNames.Close();
                fileStreamOfAge.Close();
                fileStreamOfBDD.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            mainForm.AddData("Names.txt", name);
            mainForm.AddData("Course.txt", course);
            mainForm.AddData("Min.txt", minAge);
            mainForm.AddData("Max.txt", maxAge);
            mainForm.AddData("MaxA.txt", maxAmount);

            mainForm.AddGroudToList(name, course, minAge, maxAge, maxAmount);

            mainForm.Enabled = true;
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
