namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new("Marucus", "W");
            Student student = new("Marucus", "W");
            teacher.SetDepartment("CIT");

            SendEmail sendEmail = new();

            string message = sendEmail.Send(student);
            Console.WriteLine(message);
            //Console.WriteLine($"Department: {teacher.DepartmentName}");
            //Console.WriteLine($"InterfaceInfo: {teacher.GetInterfaceInfo()}");
        }
    }
}
