using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public class RemoveView
    {
        private Manager _manager;

        private Menu _menu;

        public RemoveView(Manager setManager, Menu setMenu)
        {
            _manager = setManager;

            _menu = setMenu;
        }

        public void RemoveStudent()
        {
            Console.Clear();
            Int32.TryParse(_menu.ReadStringInput("Please enter ID of student to remove: "), out int id);

            if (_manager.GetStudentByID(id) != null)
            {
                Console.WriteLine(_manager.RemoveStudentByID(id));
            }
            else
            {
                Console.WriteLine("## ERROR ## Invalid ID, or student doesn't exist!");
            }
            Console.ReadLine();
        }// End RemoveStudent()
    }
}
