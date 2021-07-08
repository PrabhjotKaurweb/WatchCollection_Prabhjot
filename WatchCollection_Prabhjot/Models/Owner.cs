using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchCollection_Prabhjot.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int WatchID { get; set; }
        public Watch Watch { get; set; }
    }
}
