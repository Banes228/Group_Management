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
        ListBox ListBox;
        bool isGroupMode;
        public DeleteForm(MainForm mainForm, ListBox listBox, bool isGroupMode)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.ListBox = listBox;
            this.isGroupMode = isGroupMode;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(isGroupMode)
            {
                List<string> names = new List<string>();
                List<string> courses = new List<string>();
                List<string> mins = new List<string>();
                List<string> maxes = new List<string>();
                List<string> maxAs = new List<string>();
                int counter = 0;
                string name = "";

                using (StreamReader streamReader = new StreamReader("Names.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            names.Add(line);
                        }
                        else
                        {
                            name = line;
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader("Course.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            courses.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader("Min.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            mins.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader("Max.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            maxes.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader("MaxA.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            maxAs.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Names.txt"))
                {
                    foreach (string item in names)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Course.txt"))
                {
                    foreach (string item in courses)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Min.txt"))
                {
                    foreach (string item in mins)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("Max.txt"))
                {
                    foreach (string item in maxes)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter("MaxA.txt"))
                {
                    foreach (string item in maxAs)
                    {
                        streamWriter.WriteLine(item);
                    }
                }
                File.Delete(name + "\\Age.TXT");
                File.Delete(name + "\\Names.TXT");
                File.Delete(name + "\\BDD.TXT");
                Directory.Delete(name + "\\");
            }
            else
            {
                List<string> names = new List<string>();
                List<string> ages = new List<string>();
                List<string> bdds = new List<string>();              
                int counter = 0;
                string name = "";

                using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\Names.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            names.Add(line);
                        }
                        else
                        {
                            name = line;
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\Age.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            ages.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
                counter = 0;
                using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\BDD.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (!(counter == ListBox.SelectedIndex))
                        {
                            bdds.Add(line);
                        }
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }              

                using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\Names.txt"))
                {
                    foreach (string item in names)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\Age.txt"))
                {
                    foreach (string item in ages)
                    {
                        streamWriter.WriteLine(item);
                    }
                }

                using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\BDD.txt"))
                {
                    foreach (string item in bdds)
                    {
                        streamWriter.WriteLine(item);
                    }
                }
                
                
            }
            
            ListBox.Items.RemoveAt(ListBox.SelectedIndex);

            mainForm.Enabled = true;
            this.Close();
        }
    }
}
