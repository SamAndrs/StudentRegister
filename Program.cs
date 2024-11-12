using Microsoft.EntityFrameworkCore;
using StudentRegister.RegistryClasses;

namespace StudentRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext studentRegistry = new StudentContext();

            ClassRepository classRepo = new ClassRepository(studentRegistry);

            StudentRepository studentRepo = new StudentRepository(studentRegistry);

            Manager manager = new Manager(studentRepo, classRepo);
            manager.RunApp();
        }
    }
}
