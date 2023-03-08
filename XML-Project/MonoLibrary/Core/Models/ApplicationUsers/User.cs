using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Model.ApplicationUsers
{
    //Nasledice IdentityUser-a
    public class User
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
    }
}
