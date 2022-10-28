using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Description> Descriptions { get; set; }
        public string Price { get; set; }
        public string Guarantee { get; set; }
        public string Image { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
