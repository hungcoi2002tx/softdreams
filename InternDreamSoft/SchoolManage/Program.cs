using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Model;
using SchoolManager.Utils;
using NHibernate.Cfg;
using Environment = System.Environment;
using NHibernate;
using SchoolManage;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using SchoolManage.Model.Mapping;

namespace SchoolManager
{
    class Program
    {

        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
            .BuildSessionFactory()
            .AddSingleton<IStudentRepository, StudentRepository>()
            .AddSingleton<IClassRepository, ClassRepository>()
            .AddSingleton<IStudentService, StudentService>()
            .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var studentService = serviceProvider.GetService<IStudentService>();
                while (true)
                {
                    menu();
                    int choose = Input.IntegerInRange("Enter your choice : ", 1, 7);
                    switch (choose)
                    {
                        case 1:
                            studentService.ListAllStudent();
                            break;
                        case 2:
                            studentService.AddNewStudent();
                            break;
                        case 3:
                            studentService.UpdateStudent();
                            break;
                        case 4:
                            studentService.DeleteStudent();
                            break;
                        case 5:
                            studentService.SortData();
                            break;
                        case 6:
                            studentService.FindStudentById();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }


        static void menu()
        {
            Console.WriteLine("Welcome to School Management");
            Console.WriteLine("");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. Add new students");
            Console.WriteLine("3. Update student's information");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Sort list student by name");
            Console.WriteLine("6. Search student by ID");
            Console.WriteLine("7. Exit");
        }
    }
    
}