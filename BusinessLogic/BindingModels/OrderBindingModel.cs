using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int? EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
    }
}
