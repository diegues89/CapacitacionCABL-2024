using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Models.DTOs
{
    public class productsDTO
    {
        public int idProduct { get; set; }
        public string descriptionProduct { get; set; } = null!;
        public int stockQuantity { get; set; }
        //public int idCategory { get; set; }
        public string Category { get; set; }
        public int idSupplier { get; set; }
    }
}
