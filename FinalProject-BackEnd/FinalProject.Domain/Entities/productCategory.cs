using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Entities
{
    public class productCategory
    {
        
        public int idCategory { get; set; }
        public string descriptionCategory { get; set; } = null!;

       // public ICollection<products> products { get; set; }
    }
}
