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

namespace Group_Management
{
    public partial class MainForm : Form
    {
        public List<Group> groups = new List<Group>();
        public List<Child> children = new List<Child>();
        private bool isGroupsMode = true;
        private String currentGroup;
        public MainForm()
        {
            InitializeComponent();
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }    //OK

        private void addButton_Click(object sender, EventArgs e)
        {
            if (isGroupsMode)
            {
                AddGroupForm addGroupForm = new AddGroupForm(this, listBox);
                addGroupForm.Show();
            }
            else
            {               
                AddChildForm addChildForm = new AddChildForm(this, listBox);
                addChildForm.Show();
            }
            this.Enabled = false;
        }//OK

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            updateCurrentGroup();
            DeleteForm deleteForm = new DeleteForm(this, listBox, isGroupsMode);
            deleteForm.Show();
        }//OK

        private void openClouseButton_Click(object sender, EventArgs e)
        {
            isGroupsMode = !isGroupsMode;
            if (isGroupsMode)
            {
                Init();
            }
            else
            {
                updateCurrentGroup();
                deleteButton.Enabled = false;
                changeParamButton.Enabled = false;
                openClouseButton.Enabled = true;
                moveButton.Visible = true;
                moveButton.Enabled = false;

                label1.Text = "Группа: " + currentGroup;
                label2.Text = "Имя/Возраст/Дата рождения";
                openClouseButton.Text = "Назад";

                listBox.Items.Clear();


                StreamReader streamReader = new StreamReader("Data\\" + currentGroup + "\\Names.txt", true);
                StreamReader streamReader1 = new StreamReader("Data\\" + currentGroup + "\\Age.txt", true);
                StreamReader streamReader2 = new StreamReader("Data\\" + currentGroup + "\\BDD.txt", true);               

                string name;
                int age;
                String bdd;                                               

                while (true)
                {
                    name = streamReader.ReadLine();
                    if (name == null)
                    {
                        break;
                    }

                    age = Convert.ToInt32(streamReader1.ReadLine());
                    bdd = streamReader2.ReadLine();
                    listBox.Items.Add(name + "   |   " + age + "   |   " + bdd);                    

                }
                
                streamReader.Close();
                streamReader1.Close();
                streamReader2.Close();
                LimitCheck();
            }
        }

        public void LimitCheck()
        {
            StreamReader streamReader = new StreamReader("Data\\" + currentGroup + "\\Names.txt", true);
            StreamReader streamReaderForNames = new StreamReader("Data\\Names.txt", true);
            StreamReader streamReaderForMaxAmount = new StreamReader("Data\\MaxA.txt", true);

            int childCounter = 0;
            int indexCounter = 0;
            int localCounter = 0;
            String line;
            String name;
            int maxAmountOfChildren;

            while (true)
            {
                name = streamReader.ReadLine();
                if (name == null)
                {
                    break;
                }
                childCounter++;
            }

            while (true)
            {
                line = streamReaderForNames.ReadLine();
                if (line == currentGroup)
                {
                    break;
                }
                indexCounter++;
            }

            while (true)
            {
                maxAmountOfChildren = Convert.ToInt32(streamReaderForMaxAmount.ReadLine());
                if (localCounter == indexCounter)
                {
                    break;
                }
                localCounter++;
            }

            if (maxAmountOfChildren == childCounter)
            {
                addButton.Enabled = false;
            }
            else
            {
                addButton.Enabled = true;
            }

            streamReader.Close();
            streamReaderForNames.Close();
            streamReaderForMaxAmount.Close();
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
        }//OK

        private void Init()
        {
            listBox.Items.Clear();

            deleteButton.Enabled = false;
            changeParamButton.Enabled = false;
            openClouseButton.Enabled = false;
            moveButton.Visible = false;
            moveButton.Enabled = false;

            label1.Text = "Список групп";
            label2.Text = "Название/Направление/Возраст/Кол-во детей";

            openClouseButton.Text = "Просмотреть";

            try
            {
                Directory.CreateDirectory("Data\\");

                FileStream fileStreamOfNames = null;
                FileStream fileStreamOfCourses = null;
                FileStream fileStreamOfMin = null;
                FileStream fileStreamOfMax = null;
                FileStream fileStreamOfMaxA = null;

                FileInfo fileInfo = new FileInfo("Data\\Names.txt");
                if (!fileInfo.Exists)
                {
                    fileStreamOfNames = fileInfo.Create();
                    fileStreamOfNames.Close();
                }

                FileInfo fileInfo1 = new FileInfo("Data\\Course.txt");
                if (!fileInfo1.Exists)
                {
                    fileStreamOfCourses = fileInfo1.Create();
                    fileStreamOfCourses.Close();
                }

                FileInfo fileInfo2 = new FileInfo("Data\\Min.txt");
                if (!fileInfo2.Exists)
                {
                    fileStreamOfMin = fileInfo2.Create();
                    fileStreamOfMin.Close();
                }

                FileInfo fileInfo3 = new FileInfo("Data\\Max.txt");
                if (!fileInfo3.Exists)
                {
                    fileStreamOfMax = fileInfo3.Create();
                    fileStreamOfMax.Close();
                }

                FileInfo fileInfo4 = new FileInfo("Data\\MaxA.txt");
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
                
                listBox.Items.Add(groupName 
                    + "   |   " + curse 
                    + "   |   " + min + " - " + max 
                    + "   |   " + counter + "/" + maxA);
            }
            streamWriterOfNames.Close();
            streamWriterOfCourses.Close();
            streamWriterOfMin.Close();
            streamWriterOfMax.Close();
            streamWriterOfMaxA.Close();
        }//OK       

        public String getCurrentGroup()
        {
            return currentGroup;
        }//OK

        private void updateCurrentGroup() 
        {
            int counter = 0;
            using(StreamReader streamReader = new StreamReader("Data\\Names.txt"))
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
        }//OK

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
                updateCurrentGroup();
                ChangeParamFormForChild changeParamFormForChild = new ChangeParamFormForChild(this, listBox);
                changeParamFormForChild.Show();
            }
        }//OK

        private void moveButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ChoiсeGroupForm choiсeGroupForm = new ChoiсeGroupForm(this, listBox);
            choiсeGroupForm.Show();
        }//OK
    }
}
