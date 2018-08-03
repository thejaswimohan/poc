using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Models
{
    public class EmployeeModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string salary { get; set; }
    }
}