using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Description
    {
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
