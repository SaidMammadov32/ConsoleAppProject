
using ConsoleAppProject.Exceptions;
using ConsoleAppProject.Helpers;
using ConsoleAppProject.Models;
using ConsoleAppProject.Models.Entities;
using ConsoleAppProject.Services;
using ConsoleAppProject.Services.Interfaces;

DataService dataService = new();

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Classroom yarat");
    Console.WriteLine("2. Classroomlari goster");
    Console.WriteLine("3. Student yarat");
    Console.WriteLine("4. Butun telebeleri goster");
    Console.WriteLine("5. Secilmis sinifin telebelerini goster");
    Console.WriteLine("6. Telebe sil");
    Console.WriteLine("0. Cixis");
    Console.Write("Seciminiz: ");
    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Classroom adi (2 boyuk herf + 3 reqem): ");
                string cname = Console.ReadLine();
                while (!cname.IsValidClassroomName())
                {
                    Console.Write("Yanlis format! Yeniden daxil edin: ");
                    cname = Console.ReadLine();
                }

                Console.Write("Type (Backend/Frontend): ");
                ClassroomType type = Enum.Parse<ClassroomType>(Console.ReadLine(), true);

                var classroom = new Classroom(cname, type);
                dataService.AddClassroom(classroom);
                Console.WriteLine("Sinif yaradildi!");

                dataService.ShowAllClassrooms();
                break;

                case "2":
                    dataService.ShowAllClassrooms();
                break;

            case "3":
                if (!dataService.Classrooms.Any())
                    throw new ClassroomNotFoundException("Sinif yoxdur . Sinif yaradin! ");

                Console.Write("Telebenin adi: ");
                string name = Console.ReadLine();
                while (!name.IsCapitalizedNameAndSurname())
                {
                    Console.Write("Yanlis ad strukturu! Yeniden daxil edin: ");
                    name = Console.ReadLine();
                }

                Console.Write("Soyadi: ");
                string surname = Console.ReadLine();
                while (!surname.IsCapitalizedNameAndSurname())
                {
                    Console.Write("Yanlis soyad strukturu! Yeniden daxil edin: ");
                    surname = Console.ReadLine();
                }

                Console.Write("Hansi sinife elave edilsin (id daxil et): ");
                int cid = int.Parse(Console.ReadLine());

                var cls = dataService.GetClassroomById(cid);
                var student = new Student(name, surname);
                cls.AddStudent(student);
                dataService.UpdateClassroom(cls);
                Console.WriteLine("Telebe elave olundu!");
                break;

            case "4":
                foreach (var c in dataService.Classrooms)
                {
                    Console.WriteLine($"\n{c}");
                    foreach (var s in c.Students)
                        Console.WriteLine("   " + s);
                }
                break;

            case "5":
                Console.Write("Sinif id: ");
                int sid = int.Parse(Console.ReadLine());
                var classroomToShow = dataService.GetClassroomById(sid);

                Console.WriteLine($"\n{classroomToShow.Name} sinifinin telebeleri:");
                foreach (var s in classroomToShow.Students)
                    Console.WriteLine(s);
                break;

            case "6":
                Console.Write("Sinif id: ");
                int cid2 = int.Parse(Console.ReadLine());
                var cToDeleteFrom = dataService.GetClassroomById(cid2);

                Console.Write("Silinecek telebe id: ");
                int sid2 = int.Parse(Console.ReadLine());

                cToDeleteFrom.RemoveStudent(sid2);
                dataService.UpdateClassroom(cToDeleteFrom);
                Console.WriteLine("Telebe silindi!");
                break;
                case "0":
                    return;

            default:
                Console.WriteLine("Yanlis secim!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Nese promlem var duzelt: {ex.Message}");
    }
}