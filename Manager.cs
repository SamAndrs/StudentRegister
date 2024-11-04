using System;
using System.Collections.Generic;
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

        private List<Student> FetchStudentList() // <--- ändra så man kan sätta in DBContext här?
        {
            //_studentRepo.SelectAll();
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
            /*
            var students = _studentRepo.StudentList.Where(s => s.FirstName == searchName).OrderByDescending(n => n.LastName);
            foreach(var student in students)
            {
                Console.WriteLine(student.ToString());
            }*/
        } // End GetStundentsByFirstName()

        public List<Student> GetStundentsByLastName(string searchName)
        {
            return _studentRepo.FindByLastName(searchName);
            /*
            var students = _studentRepo.StudentList.Where(s => s.LastName == searchName).OrderByDescending(n => n.FirstName);
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }*/
        } // End GetStundentsByFirstName()

        public List<Student> GetStundentsByCity(string searchName)
        {
            return _studentRepo.FindByCity(searchName);
            /*
            var students = _studentRepo.StudentList.Where(s => s.City == searchName).OrderByDescending(n => n.LastName).ThenBy(n=>n.FirstName);
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }*/
        } // End GetStundentsByFirstName()

        public void RegisterNewStudent(string fName, string lName, string city)
        {
            Student newStudent = new Student(fName, lName, city);
            AddToRepo(_studentRepo, newStudent);

        }// End RegisterNewStudent()

        private void AddToRepo(Repository thisRepo, Student thisStudent)
        {
            thisRepo.StudentList.Add(thisStudent);

        }// End AddToRepo()

        public void ChangeStudentFirstName(Repository thisRepo, int studentID)
        {
            thisRepo.StudentList.ElementAt(studentID).FirstName = Console.ReadLine();
        }


    }
}
