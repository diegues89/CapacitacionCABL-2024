using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Entities
{
    public class products
    {
        [Key]
        public int idProduct { get; set; }
        public string descriptionProduct { get; set; } = null!;
        public int stockQuantity { get; set; }
        public int idCategory { get; set; }
        public int idSupplier { get; set; }

    }
}
