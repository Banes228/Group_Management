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
            AddForm addForm = new AddForm(this, addButton, listBox);
            addForm.Show();
            this.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
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
            catch (Exception ex)
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

                listBox.Items.Add(name + "   |   " + curse + "   |   " + min + " - " 
                    + max + "   |   " + count + "/" + maxA);
            }

            streamWriter.Close();
            streamWriter1.Close();
            streamWriter2.Close();
            streamWriter3.Close();
            streamWriter4.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DeleteForm deleteForm = new DeleteForm(this, listBox);
            deleteForm.Show();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            changeParamButton.Enabled = true;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            List<string> sortParamList = new List<string>();
            int sortMode = comboBox1.SelectedIndex;
            bool isNoFirst = false;
            switch (sortMode)
            {
                case 0:
                    using (StreamReader streamReader = new StreamReader("Names.txt"))
                    {
                        string line = streamReader.ReadLine();
                        while (line != null)
                        {                            
                            sortParamList.Add(line);
                            line = streamReader.ReadLine();
                        }
                    }
                    sortParamList.Sort();
                    listBox.Items.Clear();
                    foreach (string name in sortParamList)
	                {
                        foreach (Group group in groups)
	                    {
                            if (group.name == name)
	                        {
                                listBox.Items.Add(group.name + "   |   " + group.course + "   |   " 
                                    + group.minAge.ToString() + " - " + group.maxAge.ToString() 
                                    + "   |   " + group.amounOfChildren.ToString() 
                                    + "/" + group.maxAmounOfChildren.ToString());
                                using (StreamWriter streamWriter = new StreamWriter("Names.txt")) { streamWriter.Write(group.name, isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Course.txt")) { streamWriter.Write(group.course, isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Min.txt")) { streamWriter.Write(group.minAge.ToString(), isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Max.txt")) { streamWriter.Write(group.maxAge.ToString(), isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("MaxA.txt")) { streamWriter.Write(group.maxAmounOfChildren.ToString(), isNoFirst); }
                                isNoFirst = true;
                            }
	                    }
	                }
                    break;
                case 1:
                    using (StreamReader streamReader = new StreamReader("Course.txt"))
                    {
                        string line = streamReader.ReadLine();
                        while (line != null)
                        {                            
                            sortParamList.Add(line);
                            line = streamReader.ReadLine();
                        }
                    }
                    sortParamList.Sort();
                    listBox.Items.Clear();
                    string curentCourse = "";
                    foreach (string course in sortParamList)
	                {
                        foreach (Group group in groups)
	                    {                           
                            if(curentCourse == group.course)
                            {
                                continue;
                            }
                            if (group.course == course)
	                        {
                                listBox.Items.Add(group.name + "   |   " + group.course + "   |   " 
                                    + group.minAge.ToString() + " - " + group.maxAge.ToString() 
                                    + "   |   " + group.amounOfChildren.ToString() 
                                    + "/" + group.maxAmounOfChildren.ToString());
                                using (StreamWriter streamWriter = new StreamWriter("Names.txt")) { streamWriter.Write(group.name, isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Course.txt")) { streamWriter.Write(group.course, isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Min.txt")) { streamWriter.Write(group.minAge.ToString(), isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("Max.txt")) { streamWriter.Write(group.maxAge.ToString(), isNoFirst); }
                                using (StreamWriter streamWriter = new StreamWriter("MaxA.txt")) { streamWriter.Write(group.maxAmounOfChildren.ToString(), isNoFirst); }
                                isNoFirst = true;
                            }
	                    }
                        curentCourse = course;
	                }
                    break;

                case 2:
                    listBox.Items.Clear();
            
                    using (StreamReader streamReader = new StreamReader("Min.txt"))
                    {
                        string line = streamReader.ReadLine();
                        while (line != null)
                        {                            
                            sortParamList.Add(line);
                            line = streamReader.ReadLine();
                        }
                    }

                    sortParamList.Sort();
                    int curentMin = -1;

                    foreach (string min in sortParamList)
	                {                   
                        List<Group> curentMinGroup = new List<Group>();
                        List<int> maxes = new List<int>();
                        foreach (Group group in groups)
	                    {
                           
                            if(curentMin == group.minAge)
                            {
                                continue;
                            }
                            if (group.minAge == Convert.ToInt32(min))
	                        {
                                curentMinGroup.Add(group);
                                maxes.Add(group.maxAge);

	                        }

                            

	                    }
                        
                        maxes.Sort();
                        int curentMax = -1;
                            
                        foreach (int max in maxes)
	                    {
                            foreach (Group specialGroup in curentMinGroup)
                            { 
                                if(curentMax == specialGroup.maxAge)
                                {
                                    continue;
                                }
                                if (specialGroup.maxAge == max)
	                            {
                                    listBox.Items.Add(specialGroup.name + "   |   " + specialGroup.course + "   |   " 
                                    + specialGroup.minAge.ToString() + " - " + specialGroup.maxAge.ToString() 
                                    + "   |   " + specialGroup.amounOfChildren.ToString() 
                                    + "/" + specialGroup.maxAmounOfChildren.ToString());
                                    using (StreamWriter streamWriter = new StreamWriter("Names.txt")) { streamWriter.Write(specialGroup.name, isNoFirst); }
                                    using (StreamWriter streamWriter = new StreamWriter("Course.txt")) { streamWriter.Write(specialGroup.course, isNoFirst); }
                                    using (StreamWriter streamWriter = new StreamWriter("Min.txt")) { streamWriter.Write(specialGroup.minAge.ToString(), isNoFirst); }
                                    using (StreamWriter streamWriter = new StreamWriter("Max.txt")) { streamWriter.Write(specialGroup.ToString(), isNoFirst); }
                                    using (StreamWriter streamWriter = new StreamWriter("MaxA.txt")) { streamWriter.Write(specialGroup.ToString(), isNoFirst); }
                                    isNoFirst = true;
                                }
                            }
                            curentMax = max;
	                    }    
                        curentMin = Convert.ToInt32(min);
	                }
                    break;       
                    
                case 3:

                    break;
            }
        }

        private void openClouseButton_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            try
            {
                FileStream fileStream = null;
                FileStream fileStream1 = null;
                FileStream fileStream2 = null;

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
            }
            catch (Exception ex)
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

                listBox.Items.Add(name + "   |   " + curse + "   |   " + min + " - "
                    + max + "   |   " + count + "/" + maxA);
            }

            streamWriter.Close();
            streamWriter1.Close();
            streamWriter2.Close();
            streamWriter3.Close();
            streamWriter4.Close();
        }
    }
}
