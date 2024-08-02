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
        [Key]
        public int idProduct { get; set; }
        public string descriptionProduct { get; set; } = null!;
        public int stockQuantity { get; set; }
        public int idCategory { get; set; }
        public string Category { get; set; }
        public int idSupplier { get; set; }
        public string supplierName { get; set; }

    //[ForeignKey("idCategory")]
    //public productCategory productCategory { get; set; }

}
}
