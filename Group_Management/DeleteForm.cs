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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (mainForm.GetIsGroupsMode())
            {
                List<String> nameList = ReadAllFile("Names.txt");
                List<String> courseList = ReadAllFile("Course.txt");
                List<String> minList = ReadAllFile("Min.txt");
                List<String> maxList = ReadAllFile("Max.txt");
                List<String> maxAList = ReadAllFile("MaxA.txt");                                

                mainForm.WriteAllData("Names.txt", nameList);
                mainForm.WriteAllData("Course.txt", courseList);
                mainForm.WriteAllData("Min.txt", minList);
                mainForm.WriteAllData("Max.txt", maxList);
                mainForm.WriteAllData("MaxA.txt", maxAList);


                File.Delete("Data\\" + mainForm.GetCurrentGroup() + "\\Age.TXT");
                File.Delete("Data\\" + mainForm.GetCurrentGroup() + "\\Names.TXT");
                File.Delete("Data\\" + mainForm.GetCurrentGroup() + "\\BDD.TXT");
                Directory.Delete("Data\\" + mainForm.GetCurrentGroup() + "\\");
            }
            else
            {
                List<string> nameList = ReadAllFile("Names.txt");
                List<string> ageList = ReadAllFile("Age.txt");
                List<string> bddList = ReadAllFile("BDD.txt");                                            
                
                mainForm.WriteAllData("Names.txt", nameList);
                mainForm.WriteAllData("Age.txt", ageList);
                mainForm.WriteAllData("BDD.txt", bddList);
            }            
            listBox.Items.RemoveAt(listBox.SelectedIndex);
            this.Close();
        }

        //Метод для считывания данных параметра каждой группы
        //или каждого ребёнка в группе поочереди
        //String fileName - имя файла откуда нужно читать данные
        public List<String> ReadAllFile(String fileName)
        {
            List<String> fileData = new List<String>();
            String path;
            int counter = 0;

            if (mainForm.GetIsGroupsMode())
            {
                path = "Data\\" + fileName;
            }
            else
            {
                path = "Data\\" + mainForm.GetCurrentGroup() + "\\" + fileName;
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (!(counter == listBox.SelectedIndex))
                    {
                        fileData.Add(line);
                    }
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            return fileData;
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
            if (!mainForm.GetIsGroupsMode())
            {
                mainForm.LimitCheck();
            }
        }
    }
}
