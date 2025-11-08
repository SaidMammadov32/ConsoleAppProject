using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Exceptions
{
    public class ClassroomNotFoundException : Exception
    {
        public ClassroomNotFoundException(int classroomId)
            : base($"Classroom with ID {classroomId} not found.")
        {
        }
    }
}
