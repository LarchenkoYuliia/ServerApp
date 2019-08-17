using ServerApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var helper = new DeviceHelper();
            var ll =  helper.Retrieve(1);
            var kk = helper.RetrieveInfo(1);

            foreach(var r in ll)
            {
                Console.WriteLine(r.DeviceId);
                Console.WriteLine(r.DeviceName);
                Console.WriteLine(r.DeviceTypeId);
            }

            Console.WriteLine();
            Console.WriteLine(kk.DeviceId);
            Console.WriteLine(kk.DeviceName);
            Console.WriteLine(kk.DeviceTypeId);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //var helper2 = new DeviceTypeHelper();
            //var ttt = helper2.Retrieve();
            //foreach(var t in ttt)
            //{
            //    Console.WriteLine(t.DeviceTypeId);
            //    Console.WriteLine(t.DeviceTypeName);
            //}
        }
    }
}
