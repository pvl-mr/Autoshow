using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class PostBindingModel
    {
        public int? Id { get; set; }
        public string PostName { get; set; }
        public decimal Salary { get; set; }
    }
}
