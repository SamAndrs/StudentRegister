using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string fName = _menu.ReadStringInput("Add Student First Name: ");
                string lName = _menu.ReadStringInput("Add Student Last Name: ");
                string city = _menu.ReadStringInput("Add Student City Name: ");

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
    }
}
