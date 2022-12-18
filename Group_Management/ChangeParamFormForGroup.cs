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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Xml.Linq;

namespace Group_Management
{
    public partial class ChangeParamFormForGroup : Form
    {
        private MainForm mainForm;
        private ListBox listBox;
        public ChangeParamFormForGroup(MainForm mainForm, ListBox listBox)
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
            List<string> nameList = new List<string>();
            List<string> courseList = new List<string>();
            List<string> minList = new List<string>();
            List<string> maxList = new List<string>();
            List<string> maxAList = new List<string>();
            int counter = 0;
            int index = listBox.SelectedIndex;


            using (StreamReader streamReader = new StreamReader("Names.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    nameList.Add(line);                
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
                    if (!(counter == listBox.SelectedIndex))
                    {
                        courseList.Add(line);
                    }
                    else
                    {
                        if(courseTextBox.Text != "")
                        {
                            courseList.Add(courseTextBox.Text);
                        }
                        else
                        {
                            courseList.Add(line);
                        }
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
                    if (!(counter == listBox.SelectedIndex))
                    {
                        minList.Add(line);
                    }
                    else
                    {
                        if (minAgeTextBox.Text != "")
                        {
                            minList.Add(minAgeTextBox.Text);
                        }
                        else
                        {
                            minList.Add(line);
                        }
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
                    if (!(counter == listBox.SelectedIndex))
                    {
                        maxList.Add(line);
                    }
                    else
                    {
                        if (maxAgeTextBox.Text != "")
                        {
                            maxList.Add(maxAgeTextBox.Text);
                        }
                        else
                        {
                            maxList.Add(line);
                        }
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
                    if (!(counter == listBox.SelectedIndex))
                    {
                        maxAList.Add(line);
                    }
                    else
                    {
                        if (maxAmountTextBox.Text != "")
                        {
                            maxAList.Add(maxAmountTextBox.Text);
                        }
                        else
                        {
                            maxAList.Add(line);
                        }
                    }
                    line = streamReader.ReadLine();
                    counter++;
                }
            }
            counter = 0;

            using (StreamWriter streamWriter = new StreamWriter("Names.txt"))
            {
                foreach (string item in nameList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter("Course.txt"))
            {
                foreach (string item in courseList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter("Min.txt"))
            {
                foreach (string item in minList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter("Max.txt"))
            {
                foreach (string item in maxList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter("MaxA.txt"))
            {
                foreach (string item in maxAList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            FileStream fileStream;
            FileInfo fileInfo = new FileInfo(nameList[listBox.SelectedIndex] + "\\Names.txt");
            if (!fileInfo.Exists)
            {
                fileStream = fileInfo.Create();
                fileStream.Close();
            }

            using (StreamReader streamReader = new StreamReader(nameList[listBox.SelectedIndex] + "\\Names.txt"))
            {
                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }
            }

            mainForm.Enabled = true;
            listBox.Items[index] = nameList[index] 
                + "   |   " + courseList[index] 
                + "   |   " + minList[index] + " - " + maxList[index] 
                + "   |   " + counter + "/" + maxAList[index];

            this.Close();
        }                  
    }
}
