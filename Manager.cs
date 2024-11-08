using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using StudentRegister.RegistryClasses;

namespace StudentRegister
{
    public class Manager
    {
        private Menu _menu;

        private Repository _studentRepo;

        public Manager(Repository studentRepo)
        {
            _studentRepo = new Repository(new StudentContext());
        }

        public void RunApp()
        {
            _menu = new Menu(this);
            _menu.PrintMenu();
        }

        private List<Student> FetchStudentList()
        {
            _studentRepo.SelectAll();
            return _studentRepo.StudentList;
        }// End FetchStudentList()

        public void PrintStudentList()
        {
            foreach (var student in FetchStudentList())
            {
                Console.WriteLine(student);
            }
        }// PrintStudentList()

        public Student GetStudentByID(int sID)
        {
            return (Student)_studentRepo.FindByID(sID);
        }// End GetStudentByID

        public List<Student> GetStundentsByFirstName(string searchName)
        {
            return _studentRepo.FindByFirstName(searchName);
        } // End GetStundentsByFirstName()

        public List<Student> GetStundentsByLastName(string searchName)
        {
            return _studentRepo.FindByLastName(searchName);
        } // End GetStundentsByFirstName()

        public List<Student> GetStundentsByCity(string searchName)
        {
            return _studentRepo.FindByCity(searchName);
        } // End GetStundentsByFirstName()

        public bool RegisterNewStudent(string fName, string lName, string city)
        {
            var student = new Student() { FirstName=fName, LastName=lName, City=city};
            if(_studentRepo.CreateNew(student))
            {
                return true;
            }
            return false;
        }// End RegisterNewStudent()

        public bool ChangeStudentFirstName(Student thisStudent, string updateData)
        {
            thisStudent.FirstName = updateData;
            if(_studentRepo.Update(thisStudent))
            {
                return true;
            }
            else
            { 
                return false;
            }
        }// End ChangeStudentFirstName()

        public bool ChangeStudentLastName(Student thisStudent, string updateData)
        {
            thisStudent.LastName = updateData;
            if (_studentRepo.Update(thisStudent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }// End ChangeStudentLastName()

        public bool ChangeStudentCity(Student thisStudent, string updateData)
        {
            thisStudent.City = updateData;
            if (_studentRepo.Update(thisStudent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }// End ChangeStudentCity()

        public bool RemoveStudentByID(int sID)
        {
            if(_studentRepo.Remove(sID))
            {
                return true;
            }
            return false;

        }
    }
}
