using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BranchId { get; set; }
        public int PostId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
