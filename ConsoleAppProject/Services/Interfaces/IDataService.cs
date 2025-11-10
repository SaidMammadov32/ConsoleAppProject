using ConsoleAppProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Services.Interfaces
{
    public interface IDataService
    {
        List<Classroom> Classrooms { get; }


        public void LoadFromFile();
        public void SaveToFile();
        public void AddClassroom(Classroom classroom);
        public void ShowAllClassrooms();
        public Classroom GetClassroomById(int id);
        public void UpdateClassroom(Classroom updated);
    }
}
