using ConsoleAppProject.Exceptions;
using ConsoleAppProject.Models.Entities;
using ConsoleAppProject.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Services
{
    public class DataService : IDataService
    {
        private readonly string filePath = @"C:\Users\HP\source\repos\ConsoleAppProject\ConsoleAppProject\Data\classrooms.json";

        public List<Classroom> Classrooms { get; private set; } = new();

        public DataService()
        {
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                    Classrooms = JsonConvert.DeserializeObject<List<Classroom>>(json);
            }
        }

        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(Classrooms, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void AddClassroom(Classroom classroom)
        {
            Classrooms.Add(classroom);
            SaveToFile();
        }

        public void ShowAllClassrooms()
        {
            if (Classrooms == null || Classrooms.Count == 0)
            {
                Console.WriteLine("Heç bir sinif yoxdur!");
                return;
            }

            Console.WriteLine("\nSinifler: ");
            foreach (var c in Classrooms)
            {
                Console.WriteLine($"Id: {c.Id}, Ad: {c.Name}, Tip: {c.classroomType}, Telebe sayi: {c.Students.Count}");
            }
        }

        public Classroom GetClassroomById(int id)
        {
            var cls = Classrooms.FirstOrDefault(c => c.Id == id);
            if (cls == null)
                throw new ClassroomNotFoundException(id);
            return cls;
        }

        public void UpdateClassroom(Classroom updated)
        {
            var index = Classrooms.FindIndex(c => c.Id == updated.Id);
            if (index != -1)
            {
                Classrooms[index] = updated;
                SaveToFile();
            }
        }
    }
}