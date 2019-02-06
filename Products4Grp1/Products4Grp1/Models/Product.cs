using System;
using System.Collections.Generic;
using System.Text;

namespace Products4Grp1.Models
{
    public class Product
    {
        public int ProductsId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastPurchas { get; set; }
        public double Stock { get; set; }
        public string Remarks { get; set; }
        public string ImageFullPath
        {
            get
            {
                return string.Format("https://products4grp1backend100593.azurewebsites.net/{0}", Image.Substring(1));
            }
        }


    }
}
