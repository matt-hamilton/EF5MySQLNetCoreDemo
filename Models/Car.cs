using System;
using System.Collections.Generic;

#nullable disable

namespace EF5MySQLNetCoreDemo.Models
{
    public partial class Car
    {
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public short? Year { get; set; }
    }
}
