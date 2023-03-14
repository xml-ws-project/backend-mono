using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models
{
    public class FlightLayout
    {
        public string[]? Layout { get; set; }
        public int NumOfBusiness { get; set; }
        public int NumOfEconomy { get; set; }

        public FlightLayout()
        {

        }

        public FlightLayout(string[] layout, int numOfBusiness, int numOfEconomy)
        {
            Layout = layout;
            NumOfBusiness = numOfBusiness;
            NumOfEconomy = numOfEconomy;
        }
    }
}
