using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Group_Management
{
    public partial class ChoiсeGroupForm : Form
    {
        private readonly MainForm mainForm;
        private readonly ListBox listBox;
        private String groupName;

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
                string course = streamWriterOfCourses.ReadLine();
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
                choiceListBox.Items.Add(groupName
                        + "   |   " + course
                        + "   |   " + min + " - " + max
                        + "   |   " + counter + "/" + maxA);
            }

            streamWriterOfNames.Close();
            streamWriterOfCourses.Close();
            streamWriterOfMin.Close();
            streamWriterOfMax.Close();
            streamWriterOfMaxA.Close();
        }

        private void ChoiceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirmButton.Enabled = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {                    
            string name = "";
            string age = "";
            string bdd = "";
            int counter = 0;

            List<string> nameList = DataPreraration("Names.txt", ref name);
            List<string> ageList = DataPreraration("Age.txt", ref age);
            List<string> bddList = DataPreraration("BDD.txt", ref bdd);

            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
            {
                groupName = streamReader.ReadLine();
                while (true)
                {
                    if (counter == choiceListBox.SelectedIndex)
                    {
                        break;
                    }
                    groupName = streamReader.ReadLine();
                    counter++;
                }
            }

            mainForm.WriteAllData("Names.txt", nameList);
            mainForm.WriteAllData("Age.txt", ageList);
            mainForm.WriteAllData("BDD.txt", bddList);                   

            MoveData("Names.txt", name);
            MoveData("Age.txt", age);
            MoveData("BDD.txt", bdd);

            listBox.Items.RemoveAt(listBox.SelectedIndex);
            mainForm.Enabled = true;
            mainForm.LimitCheck();
            this.Close();
        }   
        
        private List<String> DataPreraration(String fileName, ref String data)
        {
            List<String> fileData = new List<String>();
            int counter = 0;

            using (StreamReader streamReader = new StreamReader("Data\\" + mainForm.GetCurrentGroup() + "\\" + fileName))
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
                        data = line;
                    }
                    line = streamReader.ReadLine();
                    counter++;
                }
            }

            return fileData;
        }

        private void MoveData(String fileName, String data) 
        {
            using (StreamWriter streamWriter = new StreamWriter("Data\\" + groupName + "\\" + fileName, true))
            {
                streamWriter.Write(data + "\n");
            }
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
