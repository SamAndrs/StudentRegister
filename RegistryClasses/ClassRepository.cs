using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.RegistryClasses
{
    public class ClassRepository : IRepository
    {
        private StudentContext _context;

        public List<StudentClass>? StudentClassList { get; set; }


        public ClassRepository(StudentContext dbContext)
        {
            _context = dbContext;
        }


        public bool CreateNew(object obj)
        {
            throw new NotImplementedException();
        }

        public object FindByID(int sID)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int sID)
        {
            throw new NotImplementedException();
        }

        public void SelectAll()
        {
            StudentClassList = new List<StudentClass>();
            foreach(var sClass in _context.StudentClasses.Select(c=>c))
            {
                StudentClassList.Add(sClass);
            }
            StudentClassList.OrderBy(sc=>sc.StudentClassId).ThenBy(c=>c.ClassName);
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
