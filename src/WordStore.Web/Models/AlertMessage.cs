﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordStore.Web.Models
{
    public class AlertMessage
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}