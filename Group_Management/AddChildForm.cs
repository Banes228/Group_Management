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
    public partial class AddChildForm : Form
    {
        MainForm mainForm;
        private ListBox listBox;
        public AddChildForm(MainForm mainForm, ListBox listBox)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            String name;
            int age;
            String bdd;
            
            try
            {
                int minAge;
                int maxAge;
                int counter = 0;

                name = nameTextBox.Text;               
                age = Convert.ToInt32(ageTextBox.Text);

                if (age < 0)
                {
                    MessageBox.Show("Возраст должен быть больше нуля!");
                    return;
                }

                using(StreamReader sr = new StreamReader("Data\\Names.txt")) 
                { 
                    string line = sr.ReadLine();
                    while(line != mainForm.getCurrentGroup()) 
                    { 
                        line= sr.ReadLine();
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
                        localCounter++;
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
                        localCounter++;
                    }
                    maxAge = Convert.ToInt32(line);
                }

                if (age < minAge || age > maxAge)
                {
                    MessageBox.Show("Возраст не соответствует группе!");
                    return;
                }     
                
                bdd = dateTimePicker1.Text;
            }
            catch
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }            

            using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\Names.txt", true))
            {
                streamWriter.Write(name + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\Age.txt", true))
            {
                streamWriter.Write(age + "\n");
            }
            using (StreamWriter streamWriter = new StreamWriter("Data\\" + mainForm.getCurrentGroup() + "\\BDD.txt", true))
            {
                streamWriter.Write(bdd + "\n");
            }            

            listBox.Items.Add(name
                + "   |   " + age
                + "   |   " + bdd);
            mainForm.Enabled = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }
    }
}
