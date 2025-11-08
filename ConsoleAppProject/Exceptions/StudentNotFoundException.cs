using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(int studentId)
            : base($"Student with ID {studentId} not found.")
        {
        }
    }
}
