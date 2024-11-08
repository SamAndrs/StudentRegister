using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegister.RegistryClasses;

namespace StudentRegister.Views
{
    public class CreateView
    {
        Manager _manager;

        Menu _menu;

        public CreateView(Manager setManager, Menu setMenu)
        {
            _manager = setManager;

            _menu = setMenu;
        }

        public void CreateNew()
        {
            bool active = true;
            while (active)
            {
                Console.Clear();
                Console.WriteLine("---- Register New Student ----\n");
                Console.WriteLine("Add student data: ");
                string fName = _menu.ReadStringInput("Enter Student First Name: ");
                string lName = _menu.ReadStringInput("Enter Student Last Name: ");
                string city = _menu.ReadStringInput("Enter Student City Name: ");

                ListStudentClasses();

                int sClass = Convert.ToInt32((_menu.ReadStringInput("Enter Student Class ID: ")));

                if (_manager.RegisterNewStudent(fName, lName, city))
                {
                    Console.WriteLine($"\nNew Student: {fName} registered.");
                }
                else
                {
                    Console.WriteLine("## ERROR ##: Could not create new post");
                }
                Console.ReadLine();
                active = false;
            }
        }// End PrintCreateNewMenu()

        private void ListStudentClasses(List<StudentClass> studentClasses)
        {
            foreach(var sClass in studentClasses)
            {
                Console.WriteLine($"{sClass.StudentClassId} - {sClass.ClassName}");
            }
        }
    }
}
