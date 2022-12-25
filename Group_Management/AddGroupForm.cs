using System;
using System.Windows.Forms;
using System.IO;

namespace Group_Management
{
    public partial class AddGroupForm : Form
    {
        private readonly MainForm mainForm;
        public AddGroupForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
      
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            String name;
            String course;
            int minAge;
            int maxAge;
            int maxAmount;       
            
            try
            {
                name = nameTextBox.Text;        
                course = courseTextBox.Text;
                minAge = Convert.ToInt32(minAgeTextBox.Text);
                maxAge = Convert.ToInt32(maxAgeTextBox.Text);
                maxAmount = Convert.ToInt32(maxAmountTextBox.Text);

            }
            catch 
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }

            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (line == name)
                    {
                        MessageBox.Show("Название группы должно быть уникальным!");
                        return;
                    }
                    line = streamReader.ReadLine();
                }
            }

            if (!(mainForm.GroupDataCheck( minAge, maxAge, maxAmount)))
            {
                return;
            }
        
            Directory.CreateDirectory("Data\\" + name + "\\");

            try
            {
                FileStream fileStreamOfNames = null;
                FileStream fileStreamOfAge = null;
                FileStream fileStreamOfBDD = null;

                FileInfo fileInfoOfNames = new FileInfo("Data\\" + name + "\\Names.txt");
                FileInfo fileInfoOfAge = new FileInfo("Data\\" + name + "\\Age.txt");
                FileInfo fileInfoOfBDD = new FileInfo("Data\\" + name + "\\BDD.txt");

                fileStreamOfNames = fileInfoOfNames.Create();
                fileStreamOfAge = fileInfoOfAge.Create();
                fileStreamOfBDD = fileInfoOfBDD.Create();

                fileStreamOfNames.Close();
                fileStreamOfAge.Close();
                fileStreamOfBDD.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            AddData("Names.txt", name);
            AddData("Course.txt", course);
            AddData("Min.txt", minAge.ToString());
            AddData("Max.txt", maxAge.ToString());
            AddData("MaxA.txt", maxAmount.ToString());

            int count = 0;

            mainForm.AddGroupToList(name, course, minAge, maxAge, count, maxAmount);

            mainForm.Enabled = true;
            this.Close();
        }

        public void AddData(String fileName, String data)
        {           
            using (StreamWriter streamWriter = new StreamWriter("Data\\" + fileName, true))
            {
                streamWriter.Write(data + "\n");
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }
        private void FormClose(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
