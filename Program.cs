namespace StudentRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext studentRegistry = new StudentContext();

            Repository studentRepo = new Repository(studentRegistry);

            Manager manager = new Manager(studentRepo);
            manager.RunApp();
        }
    }
}
