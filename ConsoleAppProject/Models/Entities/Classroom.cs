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
        public int Id { get; private set; }
        public string Name { get; set; }
        public ClassroomType classroomType { get; set; }
        public List<Student> Students { get; set; }

        public Classroom(string name, ClassroomType type)
        {
            Id = classroomCount++;
            Name = name;
            classroomType = type;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"Classroom ID: {Id}, Name: {Name}, Type: {classroomType}";
        }
    }
}
