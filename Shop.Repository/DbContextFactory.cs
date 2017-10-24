using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using System.Runtime.Remoting.Messaging;

namespace Shop.Repository
{
   public class DbContextFactory
    {
        public static WeShop GenInstance()
        {
            WeShop dbcontext = CallContext.GetData("DbContext") as WeShop;
            if (dbcontext == null)
            {
                dbcontext = new WeShop();
                CallContext.SetData("DbContext", dbcontext);
            }
            return dbcontext;
        }
    }
}
