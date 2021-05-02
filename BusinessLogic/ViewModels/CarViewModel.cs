using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [DisplayName("Модель")]
        public string Model { get; set; }
        [DisplayName("Цвет")]
        public string Color { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Название филиала")]
        public int BranchId { get; set; }
    }
}
