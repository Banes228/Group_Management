using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group_Management
{
    public partial class ChangeParamFormForChild : Form
    {
        private MainForm mainForm;
        private ListBox listBox;
        public ChangeParamFormForChild(MainForm mainForm, ListBox listBox)
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
            List<string> ageList = new List<string>();
            List<string> bddList = new List<string>();

            int counter = 0;
            int index = listBox.SelectedIndex;

            using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.getCurrentGroup() + "\\Names.txt"))
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
                        if (nameTextBox.Text != "")
                        {
                            nameList.Add(nameTextBox.Text);
                        }
                        else
                        {
                            nameList.Add(line);
                        }
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
                    else
                    {
                        if (ageTextBox.Text != "")
                        {
                            ageList.Add(ageTextBox.Text);
                        }
                        else
                        {
                            ageList.Add(line);
                        }
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
                    bddList.Add(line);
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            if(Convert.ToInt32(ageList[index]) < 0)
            {
                MessageBox.Show("Возраст должен быть больше нуля!");
                return;
            }

            int minAge;
            int maxAge;
            counter = 0;

            using (StreamReader sr = new StreamReader("Data\\Names.txt"))
            {
                string line = sr.ReadLine();
                while (line != mainForm.getCurrentGroup())
                {
                    line = sr.ReadLine();
                    counter++;
                }
            }

            using (StreamReader sr = new StreamReader("Data\\Min.txt"))
            {
                int localCounter = 0;
                string line = sr.ReadLine();
                while (localCounter != counter)
                {
                    line = sr.ReadLine();
                }
                minAge = Convert.ToInt32(line);
            }

            using (StreamReader sr = new StreamReader("Data\\Max.txt"))
            {
                int localCounter = 0;
                string line = sr.ReadLine();
                while (localCounter != counter)
                {
                    line = sr.ReadLine();
                }
                maxAge = Convert.ToInt32(line);
            }

            if (Convert.ToInt32(ageList[index]) < minAge || Convert.ToInt32(ageList[index]) > maxAge)
            {
                MessageBox.Show("Возраст не соответствует группе!");
                return;
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

            mainForm.Enabled = true;
            listBox.Items[index] = nameList[index]
                + "   |   " + ageList[index]
                + "   |   " + bddList[index];

            this.Close();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
