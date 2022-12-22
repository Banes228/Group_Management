using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group_Management
{
    public partial class ChangeParamFormForChild : Form
    {
        private readonly MainForm mainForm;
        private readonly ListBox listBox;
        public ChangeParamFormForChild(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }        

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            List<string> nameList = ChangeOneInData("Names.txt");
            List<string> ageList = ChangeOneInData("Age.txt");
            List<string> bddList = mainForm.ReadAllFile("BDD.txt");
            int index = listBox.SelectedIndex;
           
            if (!(mainForm.ChildDataCheck(Convert.ToInt32(ageList[index]))))
            {
                return;
            }

            mainForm.WriteAllData("Names.txt", nameList);
            mainForm.WriteAllData("Age.txt", nameList);
            mainForm.WriteAllData("BDD.txt", nameList);                      

            mainForm.Enabled = true;
            listBox.Items[index] = nameList[index]
                + "   |   " + ageList[index]
                + "   |   " + bddList[index];

            this.Close();
        }

        private List<String> ChangeOneInData(String fileName)
        {
            List<String> fileData = new List<String>();
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.getCurrentGroup() + "\\" + fileName))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (!(counter == listBox.SelectedIndex))
                    {
                        fileData.Add(line);
                    }
                    else
                    {
                        if (nameTextBox.Text != "")
                        {
                            fileData.Add(nameTextBox.Text);
                        }
                        else
                        {
                            fileData.Add(line);
                        }
                    }
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            return fileData;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
