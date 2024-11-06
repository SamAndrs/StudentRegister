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

        public void SelectAll()
        {
            StudentList = _context.Students.Select(s => s).OrderByDescending(s => s.LastName).ToList();
        }// End SelectAll()

        public Object FindByID(int sID)
        {
            var findStudent = _context.Students.Where(s => s.StudentId == sID).FirstOrDefault();
            return findStudent;
        }// End FindByID()

        public List<Student> FindByFirstName(string name)
        {
            return _context.Students.Where(s=> s.FirstName == name).OrderByDescending(n=> n.LastName).ToList();
        }// END FindByFirstName()

        public List<Student> FindByLastName(string name)
        {
            return _context.Students.Where(s => s.LastName == name).OrderByDescending(n => n.FirstName).ToList();
        }// End FindByLastName()

        public List<Student> FindByCity(string city)
        {
            return _context.Students.Where(s => s.City == city).OrderByDescending(n => n.LastName).ToList();
        }// End FindByCity()

        public bool CreateNew(Object student)
        {
            try
            {
                _context.Students.Add((Student)student);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }// End CreateNew()

        public bool Update(Object thisStudent)
        {
            if((Student)thisStudent != null)
            {
                _context.Students.Update((Student)thisStudent);
                _context.SaveChanges();
                return true;
            }
            return false;
        }// End Update()

        public bool Remove(int sID)
        {           
            var studentToDelete = _context.Students.First(s => s.StudentId == sID);

            if(studentToDelete != null)
            {
                    _context.Students.Remove(studentToDelete);
                    _context.SaveChanges();
                    return true;   
            }
            return false;
        }// End Remove()
    }
}