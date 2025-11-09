using ConsoleAppProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Models.Entities
{
    public class Classroom
    {
        private static int classroomCount = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassroomType classroomType { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        
        public Classroom(string name, ClassroomType type)
        {
            Id = classroomCount++;
            Name = name;
            classroomType = type;
        }

        public void AddStudent(Student student)
        {
            int limit = classroomType == ClassroomType.Backend ? 20 : 15;
            if (Students.Count >= limit)
                throw new Exception($"Sinif limiti ({limit}) dolub!");

            Students.Add(student);
        }

        public Student GetStudentById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                throw new StudentNotFoundException(id);
            return student;
        }

        public void RemoveStudent( int id)
        {
            var student = GetStudentById(id);
            Students.Remove(student);
        }   

        public override string ToString()
        {
            return $"Classroom ID: {Id}, Name: {Name}, Type: {classroomType}   Telebe sayi: {Students.Count}";
        }
    }
}
