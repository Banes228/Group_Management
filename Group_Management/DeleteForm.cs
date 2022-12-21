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

namespace Group_Management
{
    public partial class DeleteForm : Form
    {
        private readonly MainForm mainForm;
        private readonly ListBox listBox;
        public DeleteForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (mainForm.getIsGroupsMode())
            {
                List<String> nameList = mainForm.ReadAllFile("Names.txt");
                List<String> courseList = mainForm.ReadAllFile("Course.txt");
                List<String> minList = mainForm.ReadAllFile("Min.txt");
                List<String> maxList = mainForm.ReadAllFile("Max.txt");
                List<String> maxAList = mainForm.ReadAllFile("MaxA.txt");                                

                mainForm.WriteAllData("Names.txt", nameList);
                mainForm.WriteAllData("Course.txt", courseList);
                mainForm.WriteAllData("Min.txt", minList);
                mainForm.WriteAllData("Max.txt", maxList);
                mainForm.WriteAllData("MaxA.txt", maxAList);


                File.Delete("Data\\" + mainForm.getCurrentGroup() + "\\Age.TXT");
                File.Delete("Data\\" + mainForm.getCurrentGroup() + "\\Names.TXT");
                File.Delete("Data\\" + mainForm.getCurrentGroup() + "\\BDD.TXT");
                Directory.Delete("Data\\" + mainForm.getCurrentGroup() + "\\");
            }
            else
            {
                List<string> nameList = mainForm.ReadAllFile("Names.txt");
                List<string> ageList = mainForm.ReadAllFile("Age.txt");
                List<string> bddList = mainForm.ReadAllFile("BDD.txt");                                            
                
                mainForm.WriteAllData("Names.txt", nameList);
                mainForm.WriteAllData("Age.txt", nameList);
                mainForm.WriteAllData("BDD.txt", nameList);
            }            
            listBox.Items.RemoveAt(listBox.SelectedIndex);
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
            if (!mainForm.getIsGroupsMode())
            {
                mainForm.LimitCheck();
            }
        }
    }
}
