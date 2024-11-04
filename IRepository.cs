using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public interface IRepository
    {
        public List<T> SelectAll<T>();

        public Object FindByID(int sID);

        public bool CreateNew();

        public bool Update(int sID);

        public bool Remove(int sID);


    }


}
