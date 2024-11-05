using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public class Menu
    {
        private Manager _manager;

        public Menu(Manager setManager)
        {
            _manager = setManager;
        }

        bool active = true;
        public void PrintMenu()
        {
            while (active)
            {
                PrintMainMenu();
                //switch(ReadStringInput().ToUpper())
                switch (Console.ReadLine().ToUpper())
                {
                    case "1": // List All Students
                        bool oneActive = true;
                        while (oneActive)
                        {
                            ListAllMenu();
                            //switch(ReadStringInput().ToUpper())
                            switch (Console.ReadLine().ToUpper())
                            {
                                case "1": // Search by ID
                                    SearchByID();
                                    break;

                                case "2": // Search by First Name
                                    SearchByFirstName();
                                    break;

                                case "3": // Search by Last Name
                                    SearchByLastName();
                                    break;

                                case "4": //Search by City Name
                                    SearchByCity();
                                    break;

                                case "Q":
                                    oneActive = false;
                                    break;
                                default:
                                    Console.WriteLine("## ERROR ##: Please enter a valid menu option!");
                                    break;
                            }
                        }
                        break;
                    case "2": // Add New Student
                        PrintCreateNewMenu();
                        break;
                    case "3": // Edit Student Data
                        Console.Clear();
                        Console.WriteLine("---- Change Student Information ----\n");
                        Console.Write("\n Enter Student ID: ");
                        if (Int32.TryParse(Console.ReadLine(), out int sID))
                        {
                            PrintEditMenu(sID);
                        }
                        else
                        {
                            Console.WriteLine("## ERROR ##: Please enter a valid Student ID!");
                        }
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

            Console.Write("-> ");
        }// End ListAllMenu()

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"---- Menu ---- ");
            Console.WriteLine("1. List All Students");
            Console.WriteLine("2. Add New Student");
            Console.WriteLine("3. Edit Student Data\n");
            Console.WriteLine("Q. Quit Application shop\n");

            Console.Write("-> ");
        }// End PrintMainMenu(9

        private void SearchByID()
        {
            Console.Write("\nPlease enter student ID: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            if (_manager.GetStudentByID(id) != null)
            {
                Console.WriteLine(_manager.GetStudentByID(id));
            }
            else
            {
                Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            }
            Console.ReadLine();
        }// End SearchByID()

        private void SearchByFirstName()
        {
            Console.Write("\nPlease enter student First Name, to search: ");
            foreach (var student in _manager.GetStundentsByFirstName(Console.ReadLine()))
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }// End SearchByFirstName()

        private void SearchByLastName()
        {
            Console.Write("\nPlease enter student Last Name, to search: ");
            foreach (var student in _manager.GetStundentsByLastName(Console.ReadLine()))
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }// End SearchByLastName()

        private void SearchByCity()
        {
            Console.Write("\nPlease enter student City, to search: ");
            foreach (var student in _manager.GetStundentsByCity(Console.ReadLine()))
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }// End SearchByCity()

        private void PrintCreateNewMenu()
        {
            bool active = true;

            List<string> newData = new List<string>();

            while (active)
            {
                Console.Clear();
                Console.WriteLine("---- Register New Student ----\n");
                Console.Write("\nAdd Student First Name: ");
                newData.Add(Console.ReadLine()); // ReadStringInput();
                Console.Write("\nAdd Student Last Name: ");
                newData.Add(Console.ReadLine()); //ReadStringInput();
                Console.Write("\nAdd Student City: ");
                newData.Add(Console.ReadLine()); // ReadStringInput();

                if(_manager.RegisterNewStudent(newData))
                {
                    Console.WriteLine($"\nNew Student: {newData[0]} registered.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("## ERROR ##: Could not create new post");
                }
                active = false;

            }
        }// End PrintCreateNewMenu()

        private void PrintEditMenu(int readID)
        {
            Student toUpdate = _manager.GetStudentByID(readID);
            Console.WriteLine("This Student: " + toUpdate);
            bool editData = true;
            while (editData)
            {
                PrintEditInfoMenu();

                switch (ReadStringInput().ToUpper())
                {
                    case "1":
                        Console.Write("\nEnter new student First Name: ");
                        if(_manager.ChangeStudentFirstName(toUpdate, Console.ReadLine()))
                        {
                            Console.WriteLine($"Name of Student {toUpdate.StudentId} changed to: {toUpdate.FirstName} {toUpdate.LastName}");
                        }
                        else
                        {
                            Console.WriteLine("## ERROR ##: Unable to update post!");
                        }
                        
                        break;
                    case "2":
                        Console.Write("\nEnter new student Last Name: ");
                        if(_manager.ChangeStudentLastName(toUpdate, Console.ReadLine()))
                        {
                            Console.WriteLine($"Last Name of Student {toUpdate.StudentId}: {toUpdate.FirstName} changed to {toUpdate.LastName}");
                        }
                        else
                        {
                            Console.WriteLine("## ERROR ##: Unable to update post!");
                        }
                        
                        break;
                    case "3":
                        Console.Write("\nEnter new student City: ");
                        if(_manager.ChangeStudentCity(toUpdate, Console.ReadLine()))
                        {
                            Console.WriteLine($"City of Student {toUpdate.StudentId}: {toUpdate.FirstName} {toUpdate.LastName} changed to: {toUpdate.City}");
                        }
                        else
                        {
                            Console.WriteLine("## ERROR ##: Unable to update post!");
                        }
                        
                        break;
                    case "Q":
                        Console.WriteLine("Aborting.");
                        Console.ReadLine();
                        editData = false;
                        break;
                    default:
                        Console.WriteLine("## ERROR ##: Please enter a valid menu option!");
                        break;
                }
            }
        }// End PrintEditMenu()

        private void PrintEditInfoMenu()
        {
            Console.WriteLine("Change what information?\n");
            Console.WriteLine("1. Change Student First Name");
            Console.WriteLine("2. Change Student Last Name");
            Console.WriteLine("3. Change Student City");
            Console.WriteLine("Q. Abort.");
        }// End PrintEditInfoMenu()

        public static string ReadStringInput()
        {
            string text = "";

            if (Console.ReadLine() != null)
            {
                text = Console.ReadLine();
                return text;
            }
            return text;
            /*
            else
            {
                Console.WriteLine("Invalid input");
            }
            return text;*/
        }// End ReadStringInput()
    }
}
