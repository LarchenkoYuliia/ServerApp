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
            var helper = new RoomNameHelper();
            var ll = helper.Retrieve();
            var tt = helper.Retrieve("admin");

            foreach(var r in ll)
            {
                Console.WriteLine(r.RoomNameId);
                Console.WriteLine(r.RoomName);
            }
            

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach (var r in tt)
            {
                Console.WriteLine(r.RoomNameId);
                Console.WriteLine(r.RoomName);
            }

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
