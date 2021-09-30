using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.EntityDataModel
{
    public static class ContextClass
    {
        
        public static List<Sample> Samples { get; set; }
        public static List<UserModels> Users { get; set; }

        static ContextClass()
        {
            
            Samples = new List<Sample>();
            Users = new List<UserModels>();

        }
    }
}
