using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
