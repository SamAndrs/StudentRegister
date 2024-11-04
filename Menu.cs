using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.Clear();
                Console.WriteLine($"---- Menu ---- ");
                Console.WriteLine("1. List All Students");
                Console.WriteLine("2. Add New Student");
                Console.WriteLine("3. Edit Student Data\n");
                Console.WriteLine("Q. Quit Application shop\n");

                Console.Write("-> ");


                //switch(ReadStringInput().ToUpper())
                switch (Console.ReadLine().ToUpper())
                {
                    case "1": // List All Students
                        bool oneActive = true;
                        while (oneActive)
                        {
                            Console.Clear();
                            Console.WriteLine("{0, -8}{1,-15}{2,-25}{3,-10}", "ID", "First Name", "Last Name", "City");
                            Console.WriteLine(new string('=', 60) + "\n");
                            // ** List All Students
                            _manager.PrintStudentList();
                            Console.WriteLine("\n1. Find Student By ID");
                            Console.WriteLine("2. List Students With First Name");
                            Console.WriteLine("3. List Students With Last Name");
                            Console.WriteLine("4. List Students From City\n");
                            Console.WriteLine("Q. Return to Main Menu\n");

                            Console.Write("-> ");

                            //switch(ReadStringInput().ToUpper())
                            switch (Console.ReadLine().ToUpper())
                            {
                                case "1": // ** Enter ID:
                                    Console.Write("\nPlease enter student ID: ");
                                    Int32.TryParse(Console.ReadLine(), out int id);
                                    try
                                    {
                                        Console.WriteLine(_manager.GetStudentByID(id));
                                    }
                                    catch
                                    {
                                        Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
                                    }

                                    Console.ReadLine();
                                    break;

                                case "2": // ** Enter First Name
                                    Console.Write("\nPlease enter student First Name, to search: ");
                                    foreach (var student in _manager.GetStundentsByFirstName(Console.ReadLine()))
                                    {
                                        Console.WriteLine(student);
                                    }
                                    Console.ReadLine();
                                    break;

                                case "3": // ** Enter Last Name
                                    Console.Write("\nPlease enter student Last Name, to search: ");
                                    foreach (var student in _manager.GetStundentsByLastName(Console.ReadLine()))
                                    {
                                        Console.WriteLine(student);
                                    }
                                    Console.ReadLine();
                                    break;

                                case "4": //** Enter City
                                    Console.Write("\nPlease enter student City, to search: ");
                                    foreach (var student in _manager.GetStundentsByCity(Console.ReadLine()))
                                    {
                                        Console.WriteLine(student);
                                    }
                                    Console.ReadLine();
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
                        bool twoActive = true;

                        string[] newData = new string[3];

                        while (twoActive)
                        {
                            Console.Clear();
                            Console.WriteLine("---- Register New Student ----\n");
                            Console.Write("\nAdd Student First Name: ");
                            newData[0] = Console.ReadLine(); // ReadStringInput();
                            Console.Write("\nAdd Student Last Name: ");
                            newData[1] = Console.ReadLine(); //ReadStringInput();
                            Console.Write("\nAdd Student City: ");
                            newData[2] = Console.ReadLine(); // ReadStringInput();

                            _manager.RegisterNewStudent(newData[0], newData[1], newData[2]);

                            Console.WriteLine($"\nNew Student: {newData[0]} registered.");
                            Console.ReadLine();
                            twoActive = false;
                        }
                        break;
                    case "3": // Edit Student Data
                        Student id_Student = new Student();
                        Console.Clear();
                        Console.WriteLine("---- Change Student Information ----\n");
                        Console.Write("\n Enter Student ID: ");
                        //if (Int32.TryParse(ReadStringInput(), out int sID))
                        if (Int32.TryParse(Console.ReadLine(), out int sID))
                        {
                            id_Student = _manager.GetStudentByID(sID);
                            Console.WriteLine(id_Student.ToString());
                        }
                        else
                        {
                            Console.WriteLine("## ERROR ##: Please enter a valid Student ID!");
                        }
                        bool editData = true;
                        while (editData)
                        {
                            Console.WriteLine("Change what information?\n");
                            Console.WriteLine("1. Change Student First Name");
                            Console.WriteLine("2. Change Student Last Name");
                            Console.WriteLine("3. Change Student City");
                            Console.WriteLine("Q. Abort.");

                            switch (ReadStringInput().ToUpper())
                            {
                                case "1":
                                    Console.Write("\nEnter new student First Name: ");
                                    id_Student.FirstName = Console.ReadLine();//ReadStringInput();
                                    //** Change Studentlist.AT(Student);
                                    break;
                                case "2":
                                    //** Student.LastName = ReadStringInput();
                                    //** Change Studentlist.AT(Student);
                                    break;
                                case "3":
                                    //** Student.City = ReadStringInput();
                                    //** Change Studentlist.AT(Student);
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
