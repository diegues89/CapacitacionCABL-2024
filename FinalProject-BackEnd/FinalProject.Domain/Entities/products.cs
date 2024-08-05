using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Entities
{
    public class products
    {
        
        public int idProduct { get; set; }
        public string descriptionProduct { get; set; } = null!;
        public int stockQuantity { get; set; }
        public int idCategory { get; set; }
        public productCategory category { get; set; } = null!;
        public int idSupplier { get; set; } 
        public Suppliers suppliers { get; set; } = null!;

        

    }
}
