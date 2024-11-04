using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine(student.ToString());
            }
        }// PrintStudentList()

        public Student GetStudentByID(int sID)
        {
            return (Student)_studentRepo.FindByID(sID);
            //return _studentRepo.StudentList.ElementAt(sID);
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

        public void RegisterNewStudent(List<string> data)
        {
            _studentRepo.CreateNew(data);
        }// End RegisterNewStudent()

        public void ChangeStudentFirstName(Student thisStudent, string updateData)
        {
            thisStudent.FirstName = updateData;
            _studentRepo.Update(thisStudent);
        }// End ChangeStudentFirstName()

        public void ChangeStudentLastName(Student thisStudent, string updateData)
        {
            thisStudent.LastName = updateData;
            _studentRepo.Update(thisStudent);
        }// End ChangeStudentLastName()

        public void ChangeStudentCity(Student thisStudent, string updateData)
        {
            thisStudent.City = updateData;
            _studentRepo.Update(thisStudent);
        }// End ChangeStudentCity()

    }
}
