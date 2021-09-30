
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BookReadingEventsDBEntities())
            {
                var events = ctx.Events.ToList();
                System.Diagnostics.Debug.WriteLine(ctx);



                try
                {
                    var user = new User();
                    user.FullName = "Raju";
                    user.Email = "vysyakh@gmil.com";
                    user.Password = "Vkgathira@1997";
                    user.Id = 34;
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    foreach (var i in events)
                    {
                        System.Diagnostics.Debug.WriteLine("hi");
                    }

                }
                catch( Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                System.Diagnostics.Debug.WriteLine("WTF!");

            }
            
        }
    }
}
