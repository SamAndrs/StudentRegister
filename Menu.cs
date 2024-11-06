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
                switch(ReadStringInput("->").ToUpper())
                {
                    case "1": // List All Students
                        ListAllStudents();
                        break;
                    case "2": // Add New Student
                        PrintCreateNewMenu();
                        break;
                    case "3": // Edit Student Data
                        PrintEditMenu();
                        break;
                    case "4":
                        PrintRemoveMenu();
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
                        return;
                        break;
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

        private void SearchByID()
        {
            Int32.TryParse(ReadStringInput("Please enter student ID: "), out int id);

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
            var students = _manager.GetStundentsByFirstName(ReadStringInput("Please enter student First Name, to search: "));
            if (students != null)
            {
                foreach(var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            Console.ReadKey();
        }// End SearchByFirstName()

        private void SearchByLastName()
        {
            var students = _manager.GetStundentsByLastName(ReadStringInput("Please enter student Last Name, to search: "));
            if (students != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            Console.ReadKey();
        }// End SearchByLastName()

        private void SearchByCity()
        {
            var students = _manager.GetStundentsByCity(ReadStringInput("Please enter student City, to search: "));
            if (students != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            Console.ReadKey();
        }// End SearchByCity()

        private void PrintCreateNewMenu()
        {
            bool active = true;

            List<string> newData = new List<string>();

            while (active)
            {
                Console.Clear();
                Console.WriteLine("---- Register New Student ----\n");
                Console.WriteLine("Add student data: ");
                string fName = ReadStringInput("Add Student First Name: ");
                string lName = ReadStringInput("Add Student Last Name: ");
                string city = ReadStringInput("Add Student City Name: ");

                if(_manager.RegisterNewStudent(fName, lName, city))
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

        private void PrintEditMenu()
        {
            Console.Clear();
            Console.WriteLine("---- Change Student Information ----\n");
            if (Int32.TryParse(ReadStringInput("Enter Student ID: "), out int sID))
            {
                Student toUpdate = _manager.GetStudentByID(sID);
                Console.WriteLine("This Student: " + toUpdate);
                PrintEditOptions(toUpdate);
            }
            else
            {
                Console.WriteLine("## ERROR ##: Please enter a valid Student ID!");
            }
        }// End PrintEditMenu()

        private void PrintEditOptions(Student thisStudent)
        {             
            bool editData = true;
            while (editData)
            {
                Console.WriteLine("Change what information?\n");
                Console.WriteLine("1. Change Student First Name");
                Console.WriteLine("2. Change Student Last Name");
                Console.WriteLine("3. Change Student City\n");
                Console.WriteLine("Q. Abort.");

                switch (ReadStringInput("->").ToUpper())
                {
                    case "1":
                        EnterFirstName(thisStudent); 
                        break;
                    case "2":
                        EnterLastName(thisStudent);
                        break;
                    case "3":
                        EnterCityName(thisStudent);
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

        private void EnterFirstName(Student thisStudent)
        {
            if (_manager.ChangeStudentFirstName(thisStudent, ReadStringInput("Enter new student First Name: ")))
            {
                Console.WriteLine($"Name of Student {thisStudent.StudentId} changed to: {thisStudent.FirstName} {thisStudent.LastName}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterFirstName()

        private void EnterLastName(Student thisStudent)
        {
            if (_manager.ChangeStudentLastName(thisStudent, ReadStringInput("Enter new student Last Name: ")))
            {
                Console.WriteLine($"Name of Student {thisStudent.StudentId} changed to: {thisStudent.FirstName} {thisStudent.LastName}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterLastName()

        private void EnterCityName(Student thisStudent)
        {
            if (_manager.ChangeStudentCity(thisStudent, ReadStringInput("Enter new student City: ")))
            {
                Console.WriteLine($"City of Student {thisStudent.StudentId} changed to: {thisStudent.City}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterCityName()

        private void PrintRemoveMenu()
        {
            Console.Clear();
            Int32.TryParse(ReadStringInput("Please enter ID of student to remove: "), out int id);

            if (_manager.GetStudentByID(id) != null)
            {
                Console.WriteLine(_manager.RemoveStudentByID(id));
            }
            else
            {
                Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            }
            Console.ReadLine();
        }// End PrintRemoveMenu()

        public string ReadStringInput(string prompt)
        {
            //string text= Console.ReadLine();

            string value;
            while (true)
            {
                //Console.Write($"{inputText}: ");
                Console.Write(prompt + "->");
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