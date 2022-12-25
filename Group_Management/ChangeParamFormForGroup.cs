using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

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
            List<String> nameList = new List<String>();
            List<String> courseList = ChangeOneInData("Course.txt", courseTextBox);
            List<String> minList = ChangeOneInData("Min.txt", minAgeTextBox);
            List<String> maxList = ChangeOneInData("Max.txt", maxAgeTextBox);
            List<String> maxAList = ChangeOneInData("MaxA.txt", maxAmountTextBox);
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    nameList.Add(line);
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            int index = listBox.SelectedIndex;                        

            counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + nameList[index] + "\\Names.txt"))
            {
                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }
            }

            if (!(mainForm.GroupDataCheck(Convert.ToInt32(minList[index]),
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

            listBox.Items[index] = nameList[index]
               + "   |   " + courseList[index]
               + "   |   " + minList[index] + " - " + maxList[index]
               + "   |   " + counter + "/" + maxAList[index];
            

            this.Close();
        }

        private List<String> ChangeOneInData(String fileName, TextBox textBox)
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
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
