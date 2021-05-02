using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название должности")]
        public string PostName { get; set; }
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }
    }
}
