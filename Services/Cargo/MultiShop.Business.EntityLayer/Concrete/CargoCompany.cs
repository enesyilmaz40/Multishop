﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Business.EntityLayer.Concrete
{
    public class CargoCompany
    {
        [Key]
        public int CargoCompanyId { get; set; }
        public string CargoCompanyName { get; set; }
    }
}
