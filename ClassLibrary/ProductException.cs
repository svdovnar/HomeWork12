﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProductException : SystemException
    {
        public ProductException(string message) : base(message) { }

    }
}
