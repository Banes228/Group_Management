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
    public partial class MainForm : Form
    {
        public List<Group> groups = new List<Group>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            AddForm addForm = new AddForm(this, addButton);
            addForm.Show();
            this.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fileStream = null;
                FileStream fileStream1 = null;
                FileStream fileStream2 = null;
                FileStream fileStream3 = null;
                FileStream fileStream4 = null;

                FileInfo fileInfo = new FileInfo("Names.txt");
                if (!fileInfo.Exists) 
                {
                    fileStream = fileInfo.Create();
                    fileStream.Close();
                }

                FileInfo fileInfo1 = new FileInfo("Course.txt");
                if (!fileInfo1.Exists)
                {
                    fileStream1 = fileInfo1.Create();
                    fileStream1.Close();
                }

                FileInfo fileInfo2 = new FileInfo("Min.txt");
                if (!fileInfo2.Exists)
                {
                    fileStream2 = fileInfo2.Create();
                    fileStream2.Close();
                }

                FileInfo fileInfo3 = new FileInfo("Max.txt");
                if (!fileInfo3.Exists)
                {
                    fileStream3 = fileInfo3.Create();
                    fileStream3.Close();
                }

                FileInfo fileInfo4 = new FileInfo("MaxA.txt");
                if (!fileInfo4.Exists)
                {
                    fileStream4 = fileInfo4.Create();
                    fileStream4.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            StreamReader streamWriter = new StreamReader("Names.txt", true);
            StreamReader streamWriter1 = new StreamReader("Course.txt", true);
            StreamReader streamWriter2 = new StreamReader("Min.txt", true);
            StreamReader streamWriter3 = new StreamReader("Max.txt", true);
            StreamReader streamWriter4 = new StreamReader("MaxA.txt", true);

            while (true)
            {
                string name = streamWriter.ReadLine();
                if (name == null)
                {
                    break;
                }
                string curse = streamWriter1.ReadLine();
                int min = Convert.ToInt32(streamWriter2.ReadLine());
                int max = Convert.ToInt32(streamWriter3.ReadLine());
                int count = 0; //TODO Сделать счётчик детей
                int maxA = Convert.ToInt32(streamWriter4.ReadLine()); 

                Group group = new Group(name, curse, min, max, maxA);   
                groups.Add(group);

                listBox.Items.Add(name + " " + curse + " " + min + " - " + max + " " + count + "/" + maxA);
            }

            streamWriter.Close();
            streamWriter1.Close();
            streamWriter2.Close();
            streamWriter3.Close();
            streamWriter4.Close();      
        }
    }
}
