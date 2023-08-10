using XMLAspNetCore.Models;

namespace XMLAspNetCore.Data
{
    public class MyComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            if (x == null && y == null)
            {
                if (x.LastName == y.LastName)
                {
                    return 1;
                }
                return -1;
            }
            return 0;
        }
    }
}
