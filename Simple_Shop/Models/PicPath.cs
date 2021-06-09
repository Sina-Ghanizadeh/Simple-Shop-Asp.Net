using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models
{
    public class PicPath
    {

        public int Id { get; set; }

        
        public string Pic1Path { get; set; }
        public string Pic2Path { get; set; }
        public string Pic3Path { get; set; }
        public string Pic4Path { get; set; }
        public string Pic5Path { get; set; }
        public string Pic6Path { get; set; }

        public Product Product { get; set; }
    }
}
