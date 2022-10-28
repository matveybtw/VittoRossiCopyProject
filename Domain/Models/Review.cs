using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        public Client Client { get; set; }
        public Product Product { get; set; }
        public string Content { get; set; }
    }
}
