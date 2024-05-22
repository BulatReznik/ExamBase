using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace C_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var filename = "Json.json";

            var agencyList = new List<Agency>();

            using (var fileStream = new FileStream(filename, FileMode.Open))
            {
                agencyList = JsonSerializer.Deserialize<List<Agency>>(fileStream) ?? new List<Agency>();
            }

            List<Tour> allTours = new List<Tour>();

            // Перебираем каждое агентство
            foreach (var agency in agencyList)
            {
                // Перебираем туры внутри агентства
                foreach (var tour in agency.Tours)
                {
                    // Устанавливаем AgencyId для каждого тура равным Id текущего агентства
                    tour.AgencyId = agency.Id;
                    allTours.Add(tour);
                }
            }

            Application.Run(new Form1(allTours));
        }
    }
}