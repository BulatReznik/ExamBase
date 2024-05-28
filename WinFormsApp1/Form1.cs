using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Patient> list = new List<Patient>();

        public Form1()
        {
            InitializeComponent();
            list.Add(new Patient
            {
                Age = 22,
                FirstName = "������",
                Mass = 75,
                Sex = 1, // �����
                Surname = "�������"
            });

            list.Add(new Patient
            {
                Age = 21,
                FirstName = "�������",
                Mass = 65,
                Sex = 1, // �����
                Surname = "�������"
            });

            list.Add(new Patient
            {
                Age = 22,
                FirstName = "����",
                Mass = 46,
                Sex = 0, // �����
                Surname = "������"
            });

            list.Add(new Patient
            {
                Age = 21,
                FirstName = "����",
                Mass = 99.99,
                Sex = 1, // �����
                Surname = "�������"
            });

            foreach (var patient in list)
            {
                // ����� ������ ��� ��������
                Console.WriteLine($"FirstName: {patient.FirstName}, Age: {patient.Age}");
            }

            dataGridView1.DataSource = list;
        }

        public void SaveIntoFile()
        {
            // ������������ ������� � JSON ������
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);

            // ������ JSON ������ � ����
            File.WriteAllText("person.json", jsonString);

            dataGridView1.DataSource = null;
            list.Clear();
        }

        public void DownloadIntoFile()
        {
            // ������ JSON ������ �� �����
            var jsonString = File.ReadAllText("person.json");

            // �������������� JSON ������ � ������
            list = JsonConvert.DeserializeObject<List<Patient>>(jsonString);
            dataGridView1.DataSource = list;
        }

        private void FilteredList(int sex)
        {
            var fl = from l in list
                     where l.Sex == sex
                     select l;

            var res = fl.ToList();

            
            dataGridView1.DataSource = res;               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveIntoFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadIntoFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var sex = int.Parse(textBox1.Text);

                FilteredList(sex);
            }
            catch (Exception ex)
            {

            }
            FilteredList(0);
        }
    }
}