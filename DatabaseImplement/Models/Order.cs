using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}
