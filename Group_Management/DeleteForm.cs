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
        public DeleteForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.ListBox = listBox;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
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

            Directory.Delete(name + "\\");

            ListBox.Items.RemoveAt(ListBox.SelectedIndex);

            mainForm.Enabled = true;
            this.Close();
        }
    }
}
