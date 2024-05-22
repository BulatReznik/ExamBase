namespace C_
{
    public partial class Form1 : Form
    {
        public List<Tour> Tours { get; set; }

        public Form1(List<Tour>? tours)
        {
            InitializeComponent();
            Tours = tours ?? new List<Tour>();
            LoadData(Tours);
        }

        private void LoadData(List<Tour> tours)
        {
            dataGridView1.Rows.Clear();  // Очищаем старые данные
            foreach (var tour in tours)
            {
                dataGridView1.Rows.Add(tour.Id, tour.Name, tour.Country, tour.ResponsiblePerson);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tour = new Tour
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Country = textBox3.Text,
                ResponsiblePerson = textBox4.Text,
            };

            Tours.Add(tour);

            var linqTourId = from t in Tours
                where t.Id >= 2
                orderby t.Name
                select t.Id;

            var linqLamdaTourId = Tours
                .Where(t => t.Id >= 2)
                .OrderBy(t => t.Name)
                .ToList();

            dataGridView1.Rows.Add(tour.Id, tour.Name, tour.Country, tour.ResponsiblePerson);  
        }
    }
}