﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Application
{
    public class ApiResponse
    {
        public int Id { get; set; }
        public bool isStatus { get; set; }
        public string Message { get; set; }
    }
}
