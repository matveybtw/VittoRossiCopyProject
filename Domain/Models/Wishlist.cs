using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Wishlist
    {
        public List<Product> Products { get; set; }
        public Client Client { get; set; }
    }
}
