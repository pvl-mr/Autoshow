using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Автомобиль")]
        public string CarName { get; set; }
        [DisplayName("Работник")]
        public string EmployeeName { get; set; }
        [DisplayName("Покупатель")]
        public string CustomerName { get; set; }
        public int? EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
    }
}
