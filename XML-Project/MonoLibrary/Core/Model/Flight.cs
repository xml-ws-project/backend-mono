using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Model
{
    public class Flight : Entity
    {
        public DateTime TakeoffDate { get; set; }
        public DateTime LandingDate { get; set; }
        public double Price { get; set; }
    }
}
