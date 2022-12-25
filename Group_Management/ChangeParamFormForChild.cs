using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            List<string> nameList = ChangeOneInData("Names.txt", nameTextBox);
            List<string> ageList = ChangeOneInData("Age.txt", ageTextBox);
            List<string> bddList = new List<string>();
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.GetCurrentGroup() + "\\BDD.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    bddList.Add(line);
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            int index = listBox.SelectedIndex;
           
            if (!(mainForm.ChildDataCheck(Convert.ToInt32(ageList[index]))))
            {
                return;
            }

            mainForm.WriteAllData("Names.txt", nameList);
            mainForm.WriteAllData("Age.txt", ageList);
            mainForm.WriteAllData("BDD.txt", bddList);                      

            mainForm.Enabled = true;
            listBox.Items[index] = nameList[index]
                + "   |   " + ageList[index]
                + "   |   " + bddList[index];

            this.Close();
        }

        private List<String> ChangeOneInData(String fileName, TextBox textBox)
        {
            List<String> fileData = new List<String>();
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.GetCurrentGroup() + "\\" + fileName))
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
                        if (textBox.Text != "")
                        {
                            fileData.Add(textBox.Text);
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
