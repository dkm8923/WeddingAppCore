using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Models
{
    public class BaseGet
    {
        public bool DeleteCache { get; set; }
        public bool IncludeRelated { get; set; }
    }
}
