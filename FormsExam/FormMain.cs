using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsExam
{
    public partial class FormMain : Form
    {
        public List<Patient> list = new List<Patient>();

        public FormMain()
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
        }

        public void SaveIntoFile()
        {
            // Сериализация объекта в JSON строку
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);

            // Запись JSON строки в файл
            File.WriteAllText("person.json", jsonString);
            list.Clear();
        }

        public void DownloadIntoFile()
        {
            // Чтение JSON строки из файла
            var jsonString = File.ReadAllText("person.json");

            // Десериализация JSON строки в объект
            list = JsonConvert.DeserializeObject<List<Patient>>(jsonString);
        }

        private void FilteredList()
        {
            var filteredList = list.Where(e => e.Sex != 0).ToList();

            var fl = from l in list where l.Sex == 0
                     select l;

            foreach (var e in filteredList)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
