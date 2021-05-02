using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
