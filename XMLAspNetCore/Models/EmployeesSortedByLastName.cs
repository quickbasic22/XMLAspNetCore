using System.Diagnostics;

namespace XMLAspNetCore.Models
{
    public class EmployeesSortedByLastName
    {
        SortLastName LastName;

        public EmployeesSortedByLastName()
        {
            var employeeList = WorkEmployees.GetEmployees();
            LastName = new SortLastName();
            LastName.SortEmployees(employeeList);
            foreach (var employee in employeeList)
            {
                
                Debug.WriteLine(employee.LastName);
               
            }
        }
    }
}
