using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Group_Management
{
    public partial class ChangeParamFormForGroup : Form
    {
        private readonly MainForm mainForm;
        private readonly ListBox listBox;
        public ChangeParamFormForGroup(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }        

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            List<string> nameList = mainForm.ReadAllFile("Names.txt");
            List<string> courseList = ChangeOneInData("Course.txt");
            List<string> minList = ChangeOneInData("Min.txt");
            List<string> maxList = ChangeOneInData("Max.txt");
            List<string> maxAList = ChangeOneInData("MaxA.txt");
            int index = listBox.SelectedIndex;                        

            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + nameList[index] + "\\Names.txt"))
            {
                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }
            }

            if (!(mainForm.GroupDataCheck(nameList[index], Convert.ToInt32(minList[index]),
                Convert.ToInt32(maxList[index]), Convert.ToInt32(maxAList[index]))))
            {
                return;
            }

            mainForm.WriteAllData("Names.txt", nameList);
            mainForm.WriteAllData("Course.txt", courseList);
            mainForm.WriteAllData("Min.txt", minList);
            mainForm.WriteAllData("Max.txt", maxList);
            mainForm.WriteAllData("MaxA.txt", maxAList);
                                  
            mainForm.Enabled = true;
            mainForm.AddGroupToList(nameList[index], courseList[index], Convert.ToInt32(minList[index]), 
                Convert.ToInt32(maxList[index]), counter, Convert.ToInt32(maxAList[index]));
            this.Close();
        }

        private List<String> ChangeOneInData(String fileName)
        {
            List<String> fileData = new List<String>();
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + fileName))
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
                        if (courseTextBox.Text != "")
                        {
                            fileData.Add(courseTextBox.Text);
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
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
