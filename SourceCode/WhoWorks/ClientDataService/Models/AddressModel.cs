﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Models
{
    public class AddressModel
    {
        public string ShortAddress { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
    }
}
