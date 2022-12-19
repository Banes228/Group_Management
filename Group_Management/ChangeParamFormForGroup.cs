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

            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    nameList.Add(line);                
                    line = streamReader.ReadLine();                   
                }
            }

            using (StreamReader streamReader = new StreamReader("Data\\Course.txt"))
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

            using (StreamReader streamReader = new StreamReader("Data\\Min.txt"))
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

            using (StreamReader streamReader = new StreamReader("Data\\Max.txt"))
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

            using (StreamReader streamReader = new StreamReader("Data\\MaxA.txt"))
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

            using (StreamReader streamReader = new StreamReader("Data\\" + nameList[index] + "\\Names.txt"))
            {
                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }
            }

            if (Convert.ToInt32(maxList[index]) < 0 || Convert.ToInt32(minList[index]) < 0)
            {
                MessageBox.Show("Максимальный и минимальнй возраст должны быть больше нуля!");
                return;
            }
            if (Convert.ToInt32(minList[index]) > Convert.ToInt32(maxList[index]))
            {
                MessageBox.Show("Минимальнй возраст должен быть меньше максимального!");
                return;
            }
            if (Convert.ToInt32(maxAList[index]) < 1)
            {
                MessageBox.Show("Максимальное число детей в группе должно быть больше нуля!");
                return;
            }
            if (Convert.ToInt32(maxAList[index]) < counter)
            {
                MessageBox.Show("Максимальное число детей быть больше, чем уже в группе!");
                return;
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

            mainForm.Enabled = true;
            listBox.Items[index] = nameList[index] 
                + "   |   " + courseList[index] 
                + "   |   " + minList[index] + " - " + maxList[index] 
                + "   |   " + counter + "/" + maxAList[index];

            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
