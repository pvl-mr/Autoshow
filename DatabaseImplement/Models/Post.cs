using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
