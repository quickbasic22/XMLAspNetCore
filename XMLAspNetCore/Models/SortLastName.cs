using XMLAspNetCore.Data;

namespace XMLAspNetCore.Models
{
    public class SortLastName
    {
        public List<Employee> SortEmployees(List<Employee> sorted)
        {
            MyComparer myComparer = new MyComparer();
            
            sorted.Sort(myComparer);
            return sorted;
        }
    }
}
