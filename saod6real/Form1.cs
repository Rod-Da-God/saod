namespace saod6real
{
    public partial class Form1 : Form
    {
        Programmer programmer1 = new Programmer()
        {
            Languages = new HashSet<string> { "C#", "C++", "C", "Java", "Kotlin" },
            OS = new HashSet<string> { "Windows", "Linux", "macOS" },
            DB = new HashSet<string> { "PostrgeSQL", "MySQL" },
            Qualities = new HashSet<string> { "������������� ����� ���", "��������� �����", "�������� ��������", "����������", "������������ � �������", "����������", "�������������" }

        };
        Programmer programmer2 = new Programmer()
        {
            Languages = new HashSet<string> { "Pyrhon", "C++", "Ruby", "Java", "Kotlin" },
            OS = new HashSet<string> { "Windows", "Linux", "macOS" },
            DB = new HashSet<string> { "PostrgeSQL", "MySQL", "MongoDB" },
            Qualities = new HashSet<string> { "������������� ����� ���", "��������� �����", "�������� ��������", "����������", "������������ � �������", "����������", "�������������", "�������������" }

        };




        public Form1()
        {
            InitializeComponent();
            DisplayResume(programmer1, listBox1, "����������� �����");
            DisplayResume(programmer2, listBox1, "����������� ����");

            DisplaySimSkills(programmer1, programmer2, listBox2);

            DisplayDifSkills(programmer1, programmer2, listBox3);

            string result = printSkills(programmer1, programmer2);
            textBox1.Text = result;
        }

        void DisplayResume(Programmer programmer, ListBox listBox, string s)
        {

            listBox.Items.Add(s);
            listBox.Items.Add("��: " + string.Join(", ", programmer.Languages));
            listBox.Items.Add("��: " + string.Join(", ", programmer.OS));
            listBox.Items.Add("��: " + string.Join(", ", programmer.DB));
            listBox.Items.Add("��������: " + string.Join(", ", programmer.Qualities));
            listBox.Items.Add(" ");
        }

        void DisplaySimSkills(Programmer programmer, Programmer programmer2, ListBox listBox)
        {
            HashSet<string> lang = new HashSet<string>(programmer.Languages);
            HashSet<string> os = new HashSet<string>(programmer.OS);
            HashSet<string> db = new HashSet<string>(programmer.DB);
            HashSet<string> qualitirs = new HashSet<string>(programmer.Qualities);

            lang.IntersectWith(programmer2.Languages);
            os.IntersectWith(programmer2.OS);
            db.IntersectWith(programmer2.DB);
            qualitirs.IntersectWith(programmer2.Qualities);

            listBox.Items.Add("����������� �����: " + string.Join(", ", lang));
            listBox.Items.Add("����������� ��: " + string.Join(", ", os));
            listBox.Items.Add("����������� ��: " + string.Join(", ", db));
            listBox.Items.Add("����������� ��������: " + string.Join(", ", qualitirs));


        }

        void DisplayDifSkills(Programmer programmer, Programmer programmer2, ListBox listBox)
        {
            HashSet<string> lang = new HashSet<string>(programmer.Languages);
            HashSet<string> os = new HashSet<string>(programmer.OS);
            HashSet<string> db = new HashSet<string>(programmer.DB);
            HashSet<string> qualitirs = new HashSet<string>(programmer.Qualities);

            lang.SymmetricExceptWith(programmer2.Languages);
            os.SymmetricExceptWith(programmer2.OS);
            db.SymmetricExceptWith(programmer2.DB);
            qualitirs.SymmetricExceptWith(programmer2.Qualities);

            listBox.Items.Add("������ �����: " + string.Join(", ", lang));
            listBox.Items.Add("������ ��: " + string.Join(", ", os));
            listBox.Items.Add("������ ��: " + string.Join(", ", db));
            listBox.Items.Add("������ ��������: " + string.Join(", ", qualitirs));


        }

        int count(HashSet<string> p1, HashSet<string> p2)
        {
            HashSet<string> unique = new HashSet<string>(p1);
            unique.ExceptWith(p2);
            return unique.Count;
        }

        int countSkills(Programmer programmer, Programmer programmer2)
        {
            int coun1t = 0;
            coun1t += count(programmer1.Languages, programmer2.Languages);
            coun1t += count(programmer1.OS, programmer2.OS);
            coun1t += count(programmer1.DB, programmer2.DB);
            coun1t += count(programmer1.Qualities, programmer2.Qualities);
            return coun1t;
        }

        string printSkills(Programmer programmer, Programmer programmer2)
        {
            int skill1 = countSkills(programmer, programmer2);
            int skill2 = countSkills(programmer2, programmer);

            if (skill1 > skill2)
                return "������ ����������� ����� ���������";
            else if (skill1 < skill2)
                return "������ ����������� ����� ���������";
            else
                return "������������ �� ���������� ������";


        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}