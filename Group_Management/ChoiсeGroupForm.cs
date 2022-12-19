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
    public partial class ChoiсeGroupForm : Form
    {
        MainForm mainForm;
        ListBox listBox;

        public ChoiсeGroupForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }

        private void ChoiсeGroupForm_Load(object sender, EventArgs e)
        {
            confirmButton.Enabled = false;
            StreamReader streamWriterOfNames = new StreamReader("Data\\Names.txt", true);
            StreamReader streamWriterOfCourses = new StreamReader("Data\\Course.txt", true);
            StreamReader streamWriterOfMin = new StreamReader("Data\\Min.txt", true);
            StreamReader streamWriterOfMax = new StreamReader("Data\\Max.txt", true);
            StreamReader streamWriterOfMaxA = new StreamReader("Data\\MaxA.txt", true);

            while (true)
            {
                string groupName = streamWriterOfNames.ReadLine();
                if (groupName == null)
                {
                    break;
                }
                string curse = streamWriterOfCourses.ReadLine();
                string min = streamWriterOfMin.ReadLine();
                string max = streamWriterOfMax.ReadLine();
                int counter = 0;
                string maxA = streamWriterOfMaxA.ReadLine();

                using (StreamReader streamReader = new StreamReader("Data\\" + groupName + "\\Names.txt"))
                {
                    while (streamReader.ReadLine() != null)
                    {
                        counter++;
                    }
                }

                if (!(Convert.ToInt32(maxA) == counter) && !(groupName == mainForm.getCurrentGroup()))
                {
                    choiceListBox.Items.Add(groupName + "   |   " + curse + "   |   " + min + " - "
                        + max + "   |   " + counter + "/" + maxA);
                }
            }

            streamWriterOfNames.Close();
            streamWriterOfCourses.Close();
            streamWriterOfMin.Close();
            streamWriterOfMax.Close();
            streamWriterOfMaxA.Close();
        }

        private void choiceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirmButton.Enabled = true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            List<string> nameList = new List<string>();
            List<string> ageList = new List<string>();
            List<string> bddList = new List<string>();
            int counter = 0;
            string groupName = "";
            string name = "";
            string age = "";
            string bdd = "";

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
                        name = line;
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
                        age = line;
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
                    else
                    {
                        bdd = line;
                    }
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
            {
                groupName = streamReader.ReadLine();
                while (groupName != null)
                {
                    if (counter == choiceListBox.SelectedIndex)
                    {
                        break;
                    }
                    groupName = streamReader.ReadLine();
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

            using (StreamWriter streamWriter = new StreamWriter("Data\\" + groupName + "\\Names.txt", true))
            {
                streamWriter.Write(name + "\n");
            }
            using (StreamWriter streamWriter1 = new StreamWriter("Data\\" + groupName + "\\Age.txt", true))
            {
                streamWriter1.Write(age + "\n");
            }
            using (StreamWriter streamWriter2 = new StreamWriter("Data\\" + groupName + "\\BDD.txt", true))
            {
                streamWriter2.Write(bdd + "\n");
            }



            listBox.Items.RemoveAt(listBox.SelectedIndex);
            mainForm.Enabled = true;
            this.Close();
        }        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChoiсeGroupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
