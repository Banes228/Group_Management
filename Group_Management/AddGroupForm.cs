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
        private Button addButton;
        private ListBox listBox;
        public AddGroupForm(MainForm mainForm, Button addButton, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.addButton = addButton;
            this.listBox = listBox;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            addButton.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            String groupName;
            String groupCourse;
            int groupMinAge;
            int groupMaxAge;
            int groupMaxAmount;           
            try
            {
                groupName = nameTextBox.Text;
                groupCourse = courseTextBox.Text;
                groupMinAge = Convert.ToInt32(minAgeTextBox.Text);
                groupMaxAge = Convert.ToInt32(maxAgeTextBox.Text);
                groupMaxAmount = Convert.ToInt32(maxAmountTextBox.Text);
            }
            catch 
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }

            Group group = new Group(groupName, groupCourse, groupMinAge, 
                groupMaxAge, groupMaxAmount);
            mainForm.groups.Add(group);

            String path = groupName + "\\";      
        
            Directory.CreateDirectory(path);            

            using (StreamWriter streamWriter = new StreamWriter("Names.txt", true))
            {
                streamWriter.Write(groupName + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Course.txt", true))
            {
                streamWriter.Write(groupCourse + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Min.txt", true))
            {
                streamWriter.Write(groupMinAge + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Max.txt", true))
            {
                streamWriter.Write(groupMaxAge + "\n");

            }
            using (StreamWriter streamWriter = new StreamWriter("MaxA.txt", true))
            {
                streamWriter.Write(groupMaxAmount + "\n");

            }

            int count = 0;

            listBox.Items.Add(groupName + "   |   " + groupCourse + "   |   " + groupMinAge + " - " + groupMaxAge + "   |   " + count + "/" + groupMaxAmount);
            mainForm.Enabled = true;
            addButton.Enabled = true; 
            this.Close();
        }     
    }
}
