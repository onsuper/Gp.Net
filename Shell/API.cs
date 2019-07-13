
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GPApi;

namespace GPShell
{
    public class API
    {

        static void Main()
        {
            GPApi.API gp = new GPApi.API("42215", "e381e8360778f4fc395a7f927fc787f2684ec9ca");
            gp.DoOrder += doit();
        }

        private static GPApi.API.doOrderEventHandler doit(GPModels.Order.Order order)
        {
            //throw new NotImplementedException();
            Console.WriteLine("doit");
            return  new GPApi.API.doOrderEventHandler (this);
        }

    }
}
