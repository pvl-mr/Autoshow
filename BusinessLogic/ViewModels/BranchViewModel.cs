using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Название филиала")]
        public string BranchName { get; set; }
    }
}
