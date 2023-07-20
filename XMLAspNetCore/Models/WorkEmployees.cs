namespace XMLAspNetCore.Models
{
    public static class WorkEmployees
    {
        public static List<Employee> Employees { get; set; }  
        public static List<Employee> GetEmployees()
        {
            Employees = new()
            {
                new Employee() { Id = 1, FirstName = "David", LastName = "Morrow", City = "Eustis", State = "FL", ZipCode = "32726" },
                new Employee() { Id = 2, FirstName = "John", LastName = "Doe", City = "Leesburg", State = "FL", ZipCode = "34748" },
                new Employee() { Id = 3, FirstName = "Kelly", LastName = "Hows", City = "Los Angeles", State = "CA", ZipCode = "90201" },
                new Employee() { Id = 4, FirstName = "Michelle", LastName = "Takey", City = "Tampa", State = "FL", ZipCode = "34788" },
                new Employee() { Id = 5, FirstName = "Jane", LastName = "Wall", City = "Canton", State = "OH", ZipCode = "44612" },
                new Employee() { Id = 6, FirstName = "Alley", LastName = "Opera", City = "Peru", State = "WA", ZipCode = "23238" }
            };
            return Employees;         
        }
    }
}
