using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Views
{
    public class SearchView
    {
        Manager _manager;
        Menu _menu;

        public SearchView(Manager setManager, Menu setMenu)
        {
            _manager = setManager;
            _menu = setMenu;
        }

        public void SearchByID()
        {
            int.TryParse(_menu.ReadStringInput("Please enter student ID: "), out int id);

            if (_manager.GetStudentByID(id) != null)
            {
                Console.WriteLine(_manager.GetStudentByID(id));
            }
            else
            {
                Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            }
            Console.ReadKey();
        }// End SearchByID()

        public void SearchByFirstName()
        {
            var students = _manager.GetStundentsByFirstName(_menu.ReadStringInput("Please enter student First Name, to search: "));
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student(s) doesn't exist!");
            Console.ReadKey();
        }// End SearchByFirstName()

        public void SearchByLastName()
        {
            var students = _manager.GetStundentsByLastName(_menu.ReadStringInput("Please enter student Last Name, to search: "));
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student(s) doesn't exist!");
            Console.ReadKey();
        }// End SearchByLastName()

        public void SearchByCity()
        {
            var students = _manager.GetStundentsByCity(_menu.ReadStringInput("Please enter student City, to search: "));
            if (students.Count > 0)// != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student(s) doesn't exist!");
            Console.ReadKey();
        }// End SearchByCity()
    }
}
