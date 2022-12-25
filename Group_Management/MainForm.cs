using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Group_Management
{
    public partial class MainForm : Form
    {
        private bool isGroupsMode = true; //значение true - ведётся работа над группами; значение false - ведётся работа над детьми в группе;
        private String currentGroup; //Название группы, в/над которой ведётся работа
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        // Срабатывает когда в списке выбирается какой-то елемент,
        // после чего некоторые кнопки становяться активными
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            changeParamButton.Enabled = true;
            openClouseButton.Enabled = true;
            if (!isGroupsMode)
            {
                moveButton.Enabled = true;
            }
        }

        //Срабатывает когда пользователь нажимает кнопку "Добавить",
        //после чего взависимоти от значения поля isGroupMode,
        //вызывает либо форму для добавления группы либо форму для добавления ребёнка
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (isGroupsMode)
            {
                AddGroupForm addGroupForm = new AddGroupForm(this);
                addGroupForm.Show();
            }
            else
            {
                AddChildForm addChildForm = new AddChildForm(this);
                addChildForm.Show();
            }
            this.Enabled = false;
        }

        //Срабатывает когда пользователь нажимает кнопку "Удалить",
        //после чего вызывает форму для удаления группы или ребёнка
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            UpdateCurrentGroup();
            DeleteForm deleteForm = new DeleteForm(this, listBox);
            deleteForm.Show();
        }

        //Срабатывает когда пользователь нажимает кнопку "Просмотреть"/"Назад",
        //после чего взависимоти от значения поля isGroupMode,
        //выводит либо список всех групп либо список всех детей в выбранной группе
        private void OpenClouseButton_Click(object sender, EventArgs e)
        {
            isGroupsMode = !isGroupsMode;
            if (isGroupsMode)
            {
                Init();
            }
            else
            {
                UpdateCurrentGroup();
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
                    AddChildToList(name, age, bdd);

                }

                streamReader.Close();
                streamReader1.Close();
                streamReader2.Close();
                LimitCheck();
            }
        }

        //Срабатывает когда пользователь нажимает кнопку "Изменить параметры",
        //после чего взависимоти от значения поля isGroupMode,
        //вызывает либо форму для изменения параметров группы
        //либо вызывает форму для изменения параметров ребёнка
        private void ChangeParamButton_Click(object sender, EventArgs e)
        {
            if (isGroupsMode)
            {
                this.Enabled = false;
                ChangeParamFormForGroup changeParamForm = new ChangeParamFormForGroup(this, listBox);
                changeParamForm.Show();
            }
            else
            {
                this.Enabled = false;
                ChangeParamFormForChild changeParamFormForChild = new ChangeParamFormForChild(this, listBox);
                changeParamFormForChild.Show();
            }
        }

        //Срабатывает когда пользователь нажимает кнопку "Переместить,
        //после чего вызывает форму для выбора группы,
        //в которую будет перемещён ребёнок

        private void MoveButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ChoiсeGroupForm choiсeGroupForm = new ChoiсeGroupForm(this, listBox);
            choiсeGroupForm.Show();
        }

        //Метод для вывода всех групп в список
        private void Init()
        {
            listBox.Items.Clear();

            addButton.Enabled = true;
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

                AddGroupToList(groupName, curse, Convert.ToInt32(min), Convert.ToInt32(max), counter, Convert.ToInt32(maxA));
            }
            streamWriterOfNames.Close();
            streamWriterOfCourses.Close();
            streamWriterOfMin.Close();
            streamWriterOfMax.Close();
            streamWriterOfMaxA.Close();
        }

        //Метод для определения группы над/в которой ведётся работа
        private void UpdateCurrentGroup()
        {
            int counter = 0;
            using (StreamReader streamReader = new StreamReader("Data\\Names.txt"))
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
        }

        //Метод для проверки заполнена ли группа детьми до прдела (возвращает false) или нет (true)
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

        //Метод для записи параметра каждой группы 
        //или каждого ребёнка в группе поочереди
        //String fileName - имя файла куда нужно записывать данные
        //List<String> fileData - данные которые должны быть записаны
        public void WriteAllData(String fileName, List<String> fileData)
        {
            String path;

            if (this.isGroupsMode)
            {
                path = "Data\\" + fileName;
            }
            else
            {
                path = "Data\\" + currentGroup + "\\" + fileName;
            }

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string item in fileData)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }

        //Метод для записи параметра группы
        //или ребёнка из группы
        //String fileName - имя файла куда нужно записывать данные
        //String data - параметр который должны быть записан
        public void AddData (String fileName, String data) 
        {
            String path;

            if (this.isGroupsMode)
            {
                path = "Data\\" + fileName;
            }
            else
            {
                path = "Data\\" + currentGroup + "\\" + fileName;
            }

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.Write(data + "\n");
            }
        }

        //Метод для вывода данных группы в ListBox
        //String name - название группы
        //String course - название напрвления
        //int minAge - минимальный возраст для ребёнка в группе
        //int maxAge - максимальный возраст для ребёнка в группе
        //int counter - количество детей в группе
        //int maxAmount - максимальное количество детей в группе
        public void AddGroupToList(String name, String course, int minAge, int maxAge, int counter, int maxAmount)
        {
            listBox.Items.Add(name
               + "   |   " + course
               + "   |   " + minAge + " - " + maxAge
               + "   |   " + counter + "/" + maxAmount);
        }

        //Метод для вывода данных ребёнка в ListBox
        //String name - имя ребёнка
        //int age - возраст ребёнка       
        //String bdd - дата рождения
        public void AddChildToList(String name, int age, String bdd)
        {
            listBox.Items.Add(name
                + "   |   " + age
                + "   |   " + bdd);
        }

        //Метод для проверки корректности данных группы
        //int minAge - минимальный возраст для ребёнка в группе
        //int maxAge - максимальный возраст для ребёнка в группе
        //int maxAmount - максимальное количество детей в группе
        public bool GroupDataCheck(int minAge, int maxAge, int maxAmount)
        {            

            if (maxAge < 0 || minAge < 0)
            {
                MessageBox.Show("Максимальный и минимальнй возраст должны быть больше нуля!");
                return false;
            }

            if (minAge > maxAge)
            {
                MessageBox.Show("Минимальнй возраст должен быть меньше максимального!");
                return false;
            }

            if (maxAmount < 1)
            {
                MessageBox.Show("Максимальное число детей в группе должно быть больше нуля!");
                return false;
            }

            return true;
        }

        //Метод для проверки корректности данных ребёнка
        //int age - возраст ребёнка
        public bool ChildDataCheck(int age)
        {
            int minAge;
            int maxAge;
            int counter = 0;

            if (age < 0)
            {
                MessageBox.Show("Возраст должен быть больше нуля!");
                return false;
            }

            using (StreamReader sr = new StreamReader("Data\\Names.txt"))
            {
                string line = sr.ReadLine();
                while (line != currentGroup)
                {
                    line = sr.ReadLine();
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
                return false;
            }

            return true;
        }

        public String GetCurrentGroup()
        {
            return currentGroup;
        }

        public bool GetIsGroupsMode()
        {
            return isGroupsMode;
        }
    }
}
