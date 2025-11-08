using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Models.Entities
{
    public class Student
    {
        private static int studentCount = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student(string name, string surname)
        {
            Id = ++studentCount;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"Name: {Name} {Surname}";
        }
    }
}
