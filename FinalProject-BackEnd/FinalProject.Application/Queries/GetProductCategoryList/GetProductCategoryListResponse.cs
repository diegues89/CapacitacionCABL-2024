using FinalProject.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProductCategoryList
{
    public class GetProductCategoryListResponse 
    {
        public List<productCategoryDTO> productCategoryList { get; set; } = [];
    }
}
