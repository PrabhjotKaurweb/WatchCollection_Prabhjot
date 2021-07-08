using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchCollection_Prabhjot.Models
{
    public class Watch
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
