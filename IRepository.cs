using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public interface IRepository
    {
        public void SelectAll();

        public Object FindByID(int sID);

        public bool CreateNew(Object obj);

        public bool Update(Object obj);

        public bool Remove(int sID);


    }


}
