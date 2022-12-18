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

namespace Group_Management
{
    public partial class ChangeParamFormForChild : Form
    {
        private MainForm mainForm;
        private ListBox listBox;
        private String currentGroup;
        public ChangeParamFormForChild(MainForm mainForm, ListBox listBox, string currentGroup)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
            this.currentGroup = currentGroup;
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

            using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\Names.txt"))
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
            using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\Age.txt"))
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
            using (StreamReader streamReader = new StreamReader(mainForm.getCurrentGroup() + "\\BDD.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    bddList.Add(line);
                    line = streamReader.ReadLine();
                    counter++;
                }
            }           

            using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\Names.txt"))
            {
                foreach (string item in nameList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\Age.txt"))
            {
                foreach (string item in ageList)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(mainForm.getCurrentGroup() + "\\BDD.txt"))
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
    }
}
