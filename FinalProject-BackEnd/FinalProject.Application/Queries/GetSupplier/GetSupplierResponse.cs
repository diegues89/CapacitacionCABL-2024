﻿using FinalProject.Application.Models.DTOs;
using FinalProject.Applications.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetSupplier
{
    public class GetSupplierResponse
    {
        public SuppliersDTO? Supplier { get; set; }
    }
}
