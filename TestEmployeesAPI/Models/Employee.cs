namespace TestEmployeesAPI.Models
{
    /*
     * The following class is used to show the attributes/properties of an employee.
     */
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dept { get; set; }
        public int YearsOfService { get; set; }
    }
}
