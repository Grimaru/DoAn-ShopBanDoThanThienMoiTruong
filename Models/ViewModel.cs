using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDoAn__Demo1_.Models
{
    public class ViewModel
    {
        public string NamePro { get; set; }
        public string ImgPro { get; set; }
        public decimal pricePro { get; set; }
        public string NameCate { get; set; }
        public string DesPro { get; set; }
        [System.ComponentModel.DataAnnotations.Key]

        public int? IDPro { get; set; }
        public decimal Total_Money { get; set; }
        public EcoFriendlyProduct product { get; set; }
        public EcoFriendlyCategory category { get; set; }
        public EcoFriendlyOrderDetail orderDetail { get; set; }
        public IEnumerable<EcoFriendlyProduct> ListProduct { get; set; }
        public int? Top5_Quantity { get; set; }
        public int? Sum_Quantity { get; set; }
    }
}