namespace XMLAspNetCore.Models
{
    public class WorkEmployees
    {
        public List<Employee> Employees { get; set; }
        public WorkEmployees()
        {
            Employees = new()
            {
                new Employee() { Id = 1, FirstName = "David", LastName = "Morrow", City = "Eustis", State = "FL", ZipCode = "32726" },
                new Employee() { Id = 2, FirstName = "John", LastName = "Doe", City = "Leesburg", State = "FL", ZipCode = "34748" }
            };
        }
    }
}
