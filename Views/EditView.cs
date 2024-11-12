using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegister.RegistryClasses;

namespace StudentRegister.Views
{
    public class EditView
    {
        private Manager _manager;

        private Menu _menu;

        public EditView(Manager setManager, Menu setMenu)
        {
            _manager = setManager;

            _menu = setMenu;
        }

        public void PrintEditView()
        {
            Console.Clear();
            Console.WriteLine("---- Change Student Information ----\n");
            if (int.TryParse(_menu.ReadStringInput("Enter Student ID: "), out int sID))
            {
                Student toUpdate = _manager.GetStudentByID(sID);
                if (toUpdate != null)
                {
                    Console.WriteLine("This Student: " + toUpdate);
                    PrintEditOptions(toUpdate);
                }
                else
                {
                    Console.WriteLine("## ERROR ##: Student with that ID does not exist!");
                }
            }
            else
            {
                Console.WriteLine("## ERROR ##: Please enter a valid Student ID!");
            }
            Console.ReadKey();
        }// End PrintEditView()

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

                switch (_menu.ReadStringInput("->").ToUpper())
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
        }// End PrintEditOptions()

        public void EnterFirstName(Student thisStudent)
        {
            if (_manager.ChangeStudentFirstName(thisStudent, _menu.ReadStringInput("Enter new student First Name: ")))
            {
                Console.WriteLine($"Name of Student {thisStudent.StudentId} changed to: {thisStudent.FirstName} {thisStudent.LastName}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterFirstName()

        public void EnterLastName(Student thisStudent)
        {
            if (_manager.ChangeStudentLastName(thisStudent, _menu.ReadStringInput("Enter new student Last Name: ")))
            {
                Console.WriteLine($"Name of Student {thisStudent.StudentId} changed to: {thisStudent.FirstName} {thisStudent.LastName}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterLastName()

        public void EnterCityName(Student thisStudent)
        {
            if (_manager.ChangeStudentCity(thisStudent, _menu.ReadStringInput("Enter new student City: ")))
            {
                Console.WriteLine($"City of Student {thisStudent.StudentId} changed to: {thisStudent.City}");
            }
            else
            {
                Console.WriteLine("## ERROR ##: Unable to update post!");
            }
        }// End EnterCityName()
    }
}
