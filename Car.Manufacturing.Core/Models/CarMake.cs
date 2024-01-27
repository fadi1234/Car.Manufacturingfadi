using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Manufacturing.Core.Models
{
    public class CarMake
    {
        public long make_id { get; set; }
        public string make_name { get; set; }
    }
}
