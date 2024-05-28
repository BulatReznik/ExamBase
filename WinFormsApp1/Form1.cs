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
                FirstName = "Никита",
                Mass = 75,
                Sex = 1, // Мужик
                Surname = "Симонов"
            });

            list.Add(new Patient
            {
                Age = 21,
                FirstName = "Евгений",
                Mass = 65,
                Sex = 1, // Мужик
                Surname = "Сергеев"
            });

            list.Add(new Patient
            {
                Age = 22,
                FirstName = "Даша",
                Mass = 46,
                Sex = 0, // Вумэн
                Surname = "Верина"
            });

            list.Add(new Patient
            {
                Age = 21,
                FirstName = "Дима",
                Mass = 99.99,
                Sex = 1, // Мужик
                Surname = "Антонов"
            });

            foreach (var patient in list)
            {
                // Вывод данных для проверки
                Console.WriteLine($"FirstName: {patient.FirstName}, Age: {patient.Age}");
            }

            dataGridView1.DataSource = list;
        }

        public void SaveIntoFile()
        {
            // Сериализация объекта в JSON строку
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);

            // Запись JSON строки в файл
            File.WriteAllText("person.json", jsonString);

            dataGridView1.DataSource = null;
            list.Clear();
        }

        public void DownloadIntoFile()
        {
            // Чтение JSON строки из файла
            var jsonString = File.ReadAllText("person.json");

            // Десериализация JSON строки в объект
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