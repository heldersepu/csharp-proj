using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserialize
{

    public class BaseAccount
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Account : BaseAccount
    {
        public List<string> Roles { get; set; }
        public Dictionary<int, string> Locations { get; set; }
    }

    public class CoEmployee
    {
        public string Photo;
        public string FirstName;
        public string LastName;
        public string Title;
        public string Department;
        public string Type;
        public DateTime? HireDate;
        public string Email;
        public string Status;
    }

    public class CompanyInfo
    {
        public int Id;
        public string Name;
        public Dictionary<int, string> Departments;
        public Dictionary<int, string> Locations;
        public List<CoEmployee> EmployeeDirectory;

        public CompanyInfo()
        {
            Departments = new Dictionary<int, string>();
            Locations = new Dictionary<int, string>();
            EmployeeDirectory = new List<CoEmployee>();
        }
    }
}
