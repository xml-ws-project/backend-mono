using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.DbSettings
{
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }     
        
        public BsonCollectionAttribute(string name) 
        {
            CollectionName = name;  
        }
    }
}
