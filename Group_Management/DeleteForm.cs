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
        MainForm mainForm;
        ListBox listBox;
        bool isGroupMode;
        public DeleteForm(MainForm mainForm, ListBox listBox, bool isGroupMode)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
            this.isGroupMode = isGroupMode;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string groupName = "";

            if (isGroupMode)
            {
                List<string> nameList = new List<string>();
                List<string> courseList = new List<string>();
                List<string> minList = new List<string>();
                List<string> maxList = new List<string>();
                List<string> maxAList = new List<string>();                

                using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            nameList.Add(line);
                        }
                        else
                        {
                            groupName = line;
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\Course.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            courseList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\Min.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            minList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\Max.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            maxList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\MaxA.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            maxAList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\Names.txt"))
                {
                    foreach (string item in nameList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\Course.txt"))
                {
                    foreach (string item in courseList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\Min.txt"))
                {
                    foreach (string item in minList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\Max.txt"))
                {
                    foreach (string item in maxList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\MaxA.txt"))
                {
                    foreach (string item in maxAList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                File.Delete("Data\\" + groupName + "\\Age.TXT");
                File.Delete("Data\\" + groupName + "\\Names.TXT");
                File.Delete("Data\\" + groupName + "\\BDD.TXT");
                Directory.Delete("Data\\" + groupName + "\\");
            }
            else
            {
                List<string> nameList = new List<string>();
                List<string> ageList = new List<string>();
                List<string> bddList = new List<string>();                             

                using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.getCurrentGroup() + "\\Names.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            nameList.Add(line);
                        }                      
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.getCurrentGroup() + "\\Age.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            ageList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                counter = 0;

                using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.getCurrentGroup() + "\\BDD.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == listBox.SelectedIndex))
                        {
                            bddList.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }  
                
                using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\Names.txt"))
                {
                    foreach (string item in nameList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\Age.txt"))
                {
                    foreach (string item in ageList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\BDD.txt"))
                {
                    foreach (string item in bddList)
                    {
                        streamWriter.WriteLine(item);
                    }
                }                               
            }
            
            listBox.Items.RemoveAt(listBox.SelectedIndex);
            mainForm.Enabled = true;
            mainForm.LimitCheck();
            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.LimitCheck();
        }
    }
}
