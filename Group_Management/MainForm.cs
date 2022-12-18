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
        public List<Child> children = new List<Child>();
        private bool isGroupsMode = true;
        private String currentGroup;
        int indexOfcurentGroup;
        public MainForm()
        {
            InitializeComponent();
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }     

        private void addButton_Click(object sender, EventArgs e)
        {
            if (isGroupsMode)
            {
                AddGroupForm addGroupForm = new AddGroupForm(this, addButton, listBox);
                addGroupForm.Show();
            }
            else
            {
                using (StreamReader streamReader = new StreamReader("Names.txt"))
                {
                    int counter = 0;
                    while (true)
                    {
                        currentGroup = streamReader.ReadLine();
                        if (counter == indexOfcurentGroup) { break; }
                        counter++;
                    }
                }
                AddChildForm addChildForm = new AddChildForm(this, listBox, currentGroup);
                addChildForm.Show();
            }
            this.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DeleteForm deleteForm = new DeleteForm(this, listBox, isGroupsMode);
            deleteForm.Show();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            List<string> sortParamList = new List<string>();
            int sortMode = comboBox1.SelectedIndex;
            bool isNoFirst = false;

            if (isGroupsMode)
            {
                switch (sortMode)
                {
                    case 0:
                        listBox.Items.Clear();
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

                                    using (StreamWriter streamWriter = new StreamWriter("Names.txt", isNoFirst)) { streamWriter.WriteLine(group.name); }
                                    using (StreamWriter streamWriter = new StreamWriter("Course.txt", isNoFirst)) { streamWriter.WriteLine(group.course); }
                                    using (StreamWriter streamWriter = new StreamWriter("Min.txt", isNoFirst)) { streamWriter.WriteLine(group.minAge); }
                                    using (StreamWriter streamWriter = new StreamWriter("Max.txt", isNoFirst)) { streamWriter.WriteLine(group.maxAge); }
                                    using (StreamWriter streamWriter = new StreamWriter("MaxA.txt", isNoFirst)) { streamWriter.WriteLine(group.maxAmounOfChildren); }
                                    isNoFirst = true;
                                }
                            }
                        }
                        break;
                    case 1:
                        listBox.Items.Clear();
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
                        string curentCourse = "";
                        foreach (string course in sortParamList)
                        {
                            foreach (Group group in groups)
                            {
                                if (curentCourse == group.course)
                                {
                                    continue;
                                }
                                if (group.course == course)
                                {
                                    listBox.Items.Add(group.name + "   |   " + group.course + "   |   "
                                        + group.minAge.ToString() + " - " + group.maxAge.ToString()
                                        + "   |   " + group.amounOfChildren.ToString()
                                        + "/" + group.maxAmounOfChildren.ToString());

                                    using (StreamWriter streamWriter = new StreamWriter("Names.txt", isNoFirst)) { streamWriter.WriteLine(group.name); }
                                    using (StreamWriter streamWriter = new StreamWriter("Course.txt", isNoFirst)) { streamWriter.WriteLine(group.course); }
                                    using (StreamWriter streamWriter = new StreamWriter("Min.txt", isNoFirst)) { streamWriter.WriteLine(group.minAge); }
                                    using (StreamWriter streamWriter = new StreamWriter("Max.txt", isNoFirst)) { streamWriter.WriteLine(group.maxAge); }
                                    using (StreamWriter streamWriter = new StreamWriter("MaxA.txt", isNoFirst)) { streamWriter.WriteLine(group.maxAmounOfChildren); }
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
                            List<Group> groupsOfCurrentMin = new List<Group>();
                            List<int> maxList = new List<int>();
                            foreach (Group group in groups)
                            {

                                if (curentMin == group.minAge)
                                {
                                    continue;
                                }
                                if (group.minAge == Convert.ToInt32(min))
                                {
                                    groupsOfCurrentMin.Add(group);
                                    maxList.Add(group.maxAge);
                                }
                            }

                            maxList.Sort();
                            int curentMax = -1;

                            foreach (int max in maxList)
                            {
                                foreach (Group groupOfCurrentMin in groupsOfCurrentMin)
                                {
                                    if (curentMax == groupOfCurrentMin.maxAge)
                                    {
                                        continue;
                                    }
                                    if (groupOfCurrentMin.maxAge == max)
                                    {
                                        InitGroup();
                                        int counter = 0;
                                        using (StreamReader streamReader = new StreamReader(groupOfCurrentMin.name + "\\Names.txt"))
                                        {
                                            while (streamReader.ReadLine() != null)
                                            {
                                                counter++;
                                            }
                                        }

                                        listBox.Items.Add(groupOfCurrentMin.name + "   |   " + groupOfCurrentMin.course + "   |   "
                                        + groupOfCurrentMin.minAge.ToString() + " - " + groupOfCurrentMin.maxAge.ToString()
                                        + "   |   " + counter.ToString()
                                        + "/" + groupOfCurrentMin.maxAmounOfChildren.ToString());

                                        using (StreamWriter streamWriter = new StreamWriter("Names.txt", isNoFirst)) { streamWriter.WriteLine(groupOfCurrentMin.name); }
                                        using (StreamWriter streamWriter = new StreamWriter("Course.txt", isNoFirst)) { streamWriter.WriteLine(groupOfCurrentMin.course); }
                                        using (StreamWriter streamWriter = new StreamWriter("Min.txt", isNoFirst)) { streamWriter.WriteLine(groupOfCurrentMin.minAge); }
                                        using (StreamWriter streamWriter = new StreamWriter("Max.txt", isNoFirst)) { streamWriter.WriteLine(groupOfCurrentMin.maxAge); }
                                        using (StreamWriter streamWriter = new StreamWriter("MaxA.txt", isNoFirst)) { streamWriter.WriteLine(groupOfCurrentMin.maxAmounOfChildren); }
                                        isNoFirst = true;
                                    }
                                }
                                curentMax = max;
                            }
                            curentMin = Convert.ToInt32(min);
                        }
                        break;
                }
            }
            else
            {
                switch (sortMode)
                {
                    case 0:
                        listBox.Items.Clear();
                        using (StreamReader streamReader = new StreamReader(currentGroup + "\\Names.txt"))
                        {
                            string line = streamReader.ReadLine();
                            while (line != null)
                            {
                                sortParamList.Add(line);
                                line = streamReader.ReadLine();
                            }
                        }

                        sortParamList.Sort();                       
                        String currentName = "";

                        foreach (string name in sortParamList)
                        {
                            foreach (Child child in children)
                            {
                                if (currentName == child.name)
                                {
                                    continue;
                                }
                                if (child.name == name)
                                {
                                    listBox.Items.Add(child.name + "   |   " + child.age + "   |   "+ child.bdd);
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\Names.txt", isNoFirst)) { streamWriter.WriteLine(child.name); }
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\Age.txt", isNoFirst)) { streamWriter.WriteLine(child.age); }
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\BDD.txt", isNoFirst)) { streamWriter.WriteLine(child.bdd); }                                  
                                    isNoFirst = true;
                                }
                            }
                            currentName = name;

                        }
                        break;
                    case 1:
                        listBox.Items.Clear();
                        using (StreamReader streamReader = new StreamReader(currentGroup + "\\Age.txt"))
                        {
                            string line = streamReader.ReadLine();
                            while (line != null)
                            {
                                sortParamList.Add(line);
                                line = streamReader.ReadLine();
                            }
                        }

                        sortParamList.Sort();
                        String currentAge = "";

                        foreach (string age in sortParamList)
                        {
                            foreach (Child child in children)
                            {
                                if (currentAge == child.age.ToString())
                                {
                                    continue;
                                }
                                if (child.age.ToString() == age)
                                {
                                    listBox.Items.Add(child.name + "   |   " + child.age + "   |   "+ child.bdd);
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\Names.txt", isNoFirst)) { streamWriter.WriteLine(child.name); }
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\Age.txt", isNoFirst)) { streamWriter.WriteLine(child.age); }
                                    using (StreamWriter streamWriter = new StreamWriter(currentGroup + "\\BDD.txt", isNoFirst)) { streamWriter.WriteLine(child.bdd); }
                                    isNoFirst = true;
                                }
                            }
                            currentAge = age;
                        }
                        break;
                }
            }            
        }

        private void openClouseButton_Click(object sender, EventArgs e)
        {
            isGroupsMode = !isGroupsMode;
            if (isGroupsMode)
            {
                Init();
            }
            else
            {
                deleteButton.Enabled = false;
                changeParamButton.Enabled = false;
                openClouseButton.Enabled = true;
                moveButton.Enabled = false;

                label1.Text = "Список детей в группе";
                label2.Text = "Имя/Возраст/Дата рождения";
                openClouseButton.Text = "Назад";

                int counter = 0;

                using (StreamReader streamReader = new StreamReader("Names.txt"))
                {
                    while (true)
                    {
                        currentGroup = streamReader.ReadLine();
                        if (counter == listBox.SelectedIndex)
                        {
                            break;
                        }
                        counter++;
                    }
                }

                indexOfcurentGroup = listBox.SelectedIndex;
                listBox.Items.Clear();
                comboBox1.Items.Clear();
                comboBox1.Items.Add("По имени");
                comboBox1.Items.Add("По возрасту");
                comboBox1.Items.Add("По дате рождения");
                comboBox1.SelectedIndex = 0;
                InitGroup();

                StreamReader streamWriter = new StreamReader(currentGroup + "\\Names.txt", true);
                StreamReader streamWriter1 = new StreamReader(currentGroup + "\\Age.txt", true);
                StreamReader streamWriter2 = new StreamReader(currentGroup + "\\BDD.txt", true);

                while (true)
                {
                    string name = streamWriter.ReadLine();
                    if (name == null)
                    {
                        break;
                    }
                    int age = Convert.ToInt32(streamWriter1.ReadLine());
                    String bdd = streamWriter2.ReadLine();

                    Child child = new Child(name, age, bdd);
                    children.Add(child);
                    listBox.Items.Add(name + "   |   " + age + "   |   " + bdd);
                }

                streamWriter.Close();
                streamWriter1.Close();
                streamWriter2.Close();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            changeParamButton.Enabled = true;
            openClouseButton.Enabled = true;
            if (!isGroupsMode)
            {
                moveButton.Enabled = true;
            }
        }

        private void Init()
        {
            listBox.Items.Clear();

            deleteButton.Enabled = false;
            changeParamButton.Enabled = false;
            openClouseButton.Enabled = false;
            moveButton.Enabled = false;

            label1.Text = "Список групп";
            label2.Text = "Название/Направление/Возраст/Кол-во детей";

            openClouseButton.Text = "Просмотреть";

            comboBox1.Items.Clear();
            comboBox1.Items.Add("По имени");
            comboBox1.Items.Add("По направлению");
            comboBox1.Items.Add("По возрасту");

            comboBox1.SelectedIndex = 0;

            try
            {
                FileStream fileStreamOfNames = null;
                FileStream fileStreamOfCourses = null;
                FileStream fileStreamOfMin = null;
                FileStream fileStreamOfMax = null;
                FileStream fileStreamOfMaxA = null;

                FileInfo fileInfo = new FileInfo("Names.txt");
                if (!fileInfo.Exists)
                {
                    fileStreamOfNames = fileInfo.Create();
                    fileStreamOfNames.Close();
                }

                FileInfo fileInfo1 = new FileInfo("Course.txt");
                if (!fileInfo1.Exists)
                {
                    fileStreamOfCourses = fileInfo1.Create();
                    fileStreamOfCourses.Close();
                }

                FileInfo fileInfo2 = new FileInfo("Min.txt");
                if (!fileInfo2.Exists)
                {
                    fileStreamOfMin = fileInfo2.Create();
                    fileStreamOfMin.Close();
                }

                FileInfo fileInfo3 = new FileInfo("Max.txt");
                if (!fileInfo3.Exists)
                {
                    fileStreamOfMax = fileInfo3.Create();
                    fileStreamOfMax.Close();
                }

                FileInfo fileInfo4 = new FileInfo("MaxA.txt");
                if (!fileInfo4.Exists)
                {
                    fileStreamOfMaxA = fileInfo4.Create();
                    fileStreamOfMaxA.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            StreamReader streamWriterOfNames = new StreamReader("Names.txt", true);
            StreamReader streamWriterOfCourses = new StreamReader("Course.txt", true);
            StreamReader streamWriterOfMin = new StreamReader("Min.txt", true);
            StreamReader streamWriterOfMax = new StreamReader("Max.txt", true);
            StreamReader streamWriterOfMaxA = new StreamReader("MaxA.txt", true);

            while (true)
            {
                string name = streamWriterOfNames.ReadLine();
                if (name == null)
                {
                    break;
                }
                string curse = streamWriterOfCourses.ReadLine();
                int min = Convert.ToInt32(streamWriterOfMin.ReadLine());
                int max = Convert.ToInt32(streamWriterOfMax.ReadLine());
                int counter = 0;
                int maxA = Convert.ToInt32(streamWriterOfMaxA.ReadLine());

                FileStream fileStream5;
                FileInfo fileInfo5 = new FileInfo(name + "\\Names.txt");
                if (!fileInfo5.Exists)
                {
                    fileStream5 = fileInfo5.Create();
                    fileStream5.Close();
                }

                using (StreamReader streamReader = new StreamReader(name + "\\Names.txt"))
                {
                    while (streamReader.ReadLine() != null)
                    {
                        counter++;
                    }
                }

                Group group = new Group(name, curse, min, max, maxA)
                {
                    amounOfChildren = counter
                };
                groups.Add(group);
                listBox.Items.Add(name + "   |   " + curse + "   |   " + min + " - "
                    + max + "   |   " + counter + "/" + maxA);
            }

            streamWriterOfNames.Close();
            streamWriterOfCourses.Close();
            streamWriterOfMin.Close();
            streamWriterOfMax.Close();
            streamWriterOfMaxA.Close();
        }

        private void InitGroup()
        {
            try
            {
                FileStream fileStream = null;
                FileStream fileStream1 = null;
                FileStream fileStream2 = null;

                FileInfo fileInfo = new FileInfo(currentGroup + "\\Names.txt");
                if (!fileInfo.Exists)
                {
                    fileStream = fileInfo.Create();
                    fileStream.Close();
                }

                FileInfo fileInfo1 = new FileInfo(currentGroup + "\\Age.txt");
                if (!fileInfo1.Exists)
                {
                    fileStream1 = fileInfo1.Create();
                    fileStream1.Close();
                }

                FileInfo fileInfo2 = new FileInfo(currentGroup + "\\BDD.txt");
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
        }

        public String getCurrentGroup()
        {
            return currentGroup;
        }

        private void changeParamButton_Click(object sender, EventArgs e)
        {
            if(isGroupsMode)
            {
                this.Enabled = false;
                ChangeParamFormForGroup changeParamForm = new ChangeParamFormForGroup(this, listBox);
                changeParamForm.Show();
            }
            else
            {
                this.Enabled = false;
                ChangeParamFormForChild changeParamFormForChild = new ChangeParamFormForChild(this, listBox, currentGroup);
                changeParamFormForChild.Show();
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ChoiсeGroupForm choiсeGroupForm = new ChoiсeGroupForm(this, listBox);
            choiсeGroupForm.Show();
        }
    }
}
