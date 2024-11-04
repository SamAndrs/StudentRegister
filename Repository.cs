using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public class Repository : IRepository
    {
        private StudentContext _context;

        public List<Student>? StudentList { get; set; }
        


        public Repository(StudentContext dbContext)
        {
            _context = dbContext;
        }

        public List<T> SelectAll<T>()
        {
            // StudentList? = _context.Students.Select(s => s).OrderByDescending(s => s.LastName).ToList();

            List<T> fakeList = new List<T>();
            return fakeList;
        }

        public Object FindByID(int sID)
        {
            // var findStudent = _context.Students.Where(s => s.StudentId == sID).FirstOrDefault();
            Student fakeStudent = new Student("", "", "");
            return fakeStudent;
        }

        public List<Student> FindByFirstName(string name)
        {
            // StudentList? = _context.Students.Where(s=> s.FirstName == name).OrderByDescending(n=> n.LastName).ToList();
            List<Student> fakeList = new List<Student>();
            return fakeList;
        }

        public List<Student> FindByLastName(string name)
        {
            // StudentList? = _context.Students.Where(s=> s.LastName == name).OrderByDescending(n=> n.FirstName).ToList();
            List<Student> fakeList = new List<Student>();
            return fakeList;
        }

        public List<Student> FindByCity(string city)
        {
            // StudentList? = _context.Students.Where(s=> s.City == city).OrderByDescending(n=> n.LastName).ToList();
            List<Student> fakeList = new List<Student>();
            return fakeList;
        }

        public bool CreateNew()   //(string fName, string lName, string cName)
        {
            //Student newStudent = new Student(fName, lName, cName);
            try
            {
                // _context.Students.Add(newStudent);
                // _context.SaveChanges();
                return true;
            }
            catch
            {
                Console.WriteLine("## ERROR ##: Unable to add new post!");
                return false;
            }
        }

        public bool Update(int sID)
        {
            /*var studentToUpdate = _context.Students.First(s=> s.studentId == sID);
            
            if(studentToUpdate != null)
            {
                _context.Students.Update(studentToUpdate);
                _context.SaveChanges();
                return true;
            }*/
            Console.WriteLine("## ERROR ##: Could not update post. Not a valid ID!");
            return false;
        }

        public bool Remove(int sID)
        {
            // int toDelete = (int)_context.Students.SelectedItem(sID);
            /*
            var studentToDelete = _context.Students.First(s => s.StudentId == sID);

            if(studentToDelete != null)
            {
                    _context.Students.Remove(studentToDelete);
                    _context.SaveChanges();
                    return true;
                
            }*/
            Console.WriteLine("## ERROR ##: Unable to delete post. Not a valid ID!");
            return false;

        }
    }
}