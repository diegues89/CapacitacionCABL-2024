﻿using FinalProject.Application.Models.DTOs;
using FinalProject.Applications.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProductsList
{
    public class GetProductsListResponse
    {
        public List<productsDTO>ProductsList { get; set; } = [];
    }
}
