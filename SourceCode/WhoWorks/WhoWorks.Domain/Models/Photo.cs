﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Domain.Models
{
    public class Photo : BaseModel
    {
        public byte[] ImageData { get; set; }
        public Person Person { get; set; }
    }
}
