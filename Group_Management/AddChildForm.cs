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
        private String groupName;
        public AddChildForm(MainForm mainForm, ListBox listBox, string groupName)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listBox = listBox;
            this.groupName = groupName;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            String childName;         
            int childAge;
            String bdd;
            try
            {
                childName = nameTextBox.Text;
                childAge = Convert.ToInt32(ageTextBox.Text);
                bdd = bddTextBox.Text;                                
            }
            catch
            {
                MessageBox.Show("Данные в полях некоректны или отсутствуют!");
                return;
            }

            Child child = new Child(childName, childAge, bdd);

            using (StreamWriter streamWriter = new StreamWriter(groupName + "\\Names.txt", true))
            {
                streamWriter.Write(childName + "\n");
            }
            using (StreamWriter streamWriter1 = new StreamWriter(groupName + "\\Age.txt", true))
            {
                streamWriter1.Write(childAge + "\n");
            }
            using (StreamWriter streamWriter2 = new StreamWriter(groupName + "\\BDD.txt", true))
            {
                streamWriter2.Write(bdd + "\n");
            }

            listBox.Items.Add(childName + "   |   " + childAge + "   |   " + bdd);

            mainForm.Enabled = true;
            this.Close();
        }
    }
}
