using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentRegister
{
    public class Menu
    {
        private Manager _manager;

        private SearchView _searchView;

        private CreateView _createView;

        private EditView _editView;

        private RemoveView _removeView;

        public Menu(Manager setManager)
        {
            _manager = setManager;
            _searchView = new SearchView(_manager, this);
            _createView = new CreateView(_manager, this);
            _editView = new EditView(_manager, this);
            _removeView = new RemoveView(_manager, this);
        }

        bool active = true;
        public void PrintMenu()
        {
            while (active)
            {
                PrintMainMenu();
                switch(ReadStringInput("->").ToUpper())
                {
                    case "1": // List All Students
                        ListAllStudents();
                        break;
                    case "2": // Add New Student
                        _createView.CreateNew();
                        break;
                    case "3": // Edit Student Data
                        _editView.PrintEditView();
                        break;
                    case "4":
                        _removeView.RemoveStudent();
                        break;
                    case "Q": // Quit Application
                        Console.WriteLine("Closing Program");
                        Console.ReadLine();
                        active = false;
                        break;

                    default:
                        Console.WriteLine("## ERROR ##: Please enter a valid menu option!");
                        break;
                }
            }
        }// End PrintMenu()

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"---- Menu ---- ");
            Console.WriteLine("1. List All Students");
            Console.WriteLine("2. Add New Student");
            Console.WriteLine("3. Edit Student Data");
            Console.WriteLine("4. Remove Student from Registry\n");
            Console.WriteLine("Q. Quit Application shop\n");
        }// End PrintMainMenu()

        private void ListAllStudents()
        {
            while (true)
            {
                ListAllMenu();
                switch (ReadStringInput("->").ToUpper())
                {
                    case "1": // Search by ID
                        _searchView.SearchByID();
                        break;

                    case "2": // Search by First Name
                        _searchView.SearchByFirstName();
                        break;

                    case "3": // Search by Last Name
                        _searchView.SearchByLastName();
                        break;

                    case "4": //Search by City Name
                        _searchView.SearchByCity();
                        break;

                    case "Q":
                        return;
                        //break;
                    default:
                        Console.WriteLine("## ERROR ##: Please enter a valid menu option!");
                        break;
                }
            }
        }// End 

        private void ListAllMenu()
        {
            Console.Clear();
            Console.WriteLine("{0, -8}{1,-15}{2,-25}{3,-10}", "ID", "First Name", "Last Name", "City");
            Console.WriteLine(new string('=', 60) + "\n");
            // List All Students
            _manager.PrintStudentList();
            Console.WriteLine("\n1. Find Student By ID");
            Console.WriteLine("2. List Students With First Name");
            Console.WriteLine("3. List Students With Last Name");
            Console.WriteLine("4. List Students From City\n");
            Console.WriteLine("Q. Return to Main Menu\n");
        }// End ListAllMenu()

        public string ReadStringInput(string prompt)
        {
            string value;
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Invalid input, try again.");
                    continue;
                }
                return value;
            }
        }// End ReadStringInput()
    }
}