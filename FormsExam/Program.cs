namespace FormsExam
{
    internal static class Program
    {
        public static List<Patient> list = new List<Patient>();
        /// <summary> 
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}