﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.OrderResult
{
    public class ErrorOrderResult : ErrorResult
    {
        public string CustomerOrderNo { get; set; }
        public int SystemOrderNo { get; set; }
    }
}
