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
            String groupName;
            String groupCourse;
            int groupMinAge;
            int groupMaxAge;
            int groupMaxAmount;           
            try
            {
                groupName = nameTextBox.Text;
                using(StreamReader streamReader = new StreamReader("Data\\Names.txt")) 
                {
                    string line = streamReader.ReadLine();
                    while(line != null)
                    {
                        if (line == groupName)
                        {
                            MessageBox.Show("Название группы должно быть уникальным!");
                            return;
                        }
                        line = streamReader.ReadLine();
                    }
                }
                groupCourse = courseTextBox.Text;
                groupMinAge = Convert.ToInt32(minAgeTextBox.Text);
                groupMaxAge = Convert.ToInt32(maxAgeTextBox.Text);
                if(groupMaxAge < 0 || groupMinAge < 0) 
                {
                    MessageBox.Show("Максимальный и минимальнй возраст должны быть больше нуля!");
                    return;
                }
                if (groupMinAge > groupMaxAge)
                {
                    MessageBox.Show("Минимальнй возраст должен быть меньше максимального!");
                    return;
                }
                groupMaxAmount = Convert.ToInt32(maxAmountTextBox.Text);
                if (groupMaxAmount < 0)
                {
                    MessageBox.Show("Максимальное число детей в группе должно быть больше нуля!");
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }     
        
            Directory.CreateDirectory("Data\\" + groupName + "\\");

            try
            {
                FileStream fileStreamOfNames = null;
                FileStream fileStreamOfAge = null;
                FileStream fileStreamOfBDD = null;

                FileInfo fileInfoOfNames = new FileInfo("Data\\" + groupName + "\\Names.txt");
                FileInfo fileInfoOfAge = new FileInfo("Data\\" + groupName + "\\Age.txt");
                FileInfo fileInfoOfBDD = new FileInfo("Data\\" + groupName + "\\BDD.txt");

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

            using (StreamWriter streamWriter = new StreamWriter("Data\\Names.txt", true))
            {
                streamWriter.Write(groupName + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\Course.txt", true))
            {
                streamWriter.Write(groupCourse + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\Min.txt", true))
            {
                streamWriter.Write(groupMinAge + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\Max.txt", true))
            {
                streamWriter.Write(groupMaxAge + "\n");

            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\MaxA.txt", true))
            {
                streamWriter.Write(groupMaxAmount + "\n");

            }

            int count = 0;

            listBox.Items.Add(groupName 
                + "   |   " + groupCourse 
                + "   |   " + groupMinAge + " - " + groupMaxAge 
                + "   |   " + count + "/" + groupMaxAmount);
            mainForm.Enabled = true;
            this.Close();
        }     
    }
}
