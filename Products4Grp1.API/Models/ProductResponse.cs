using System;
namespace Products4Grp1.API.Models
{
    public class ProductResponse
    {
        public int ProductsId { get; set; }

        public String Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastPurchas { get; set; }

        public double Stock { get; set; }

        public string Remarks { get; set; }
    }
}