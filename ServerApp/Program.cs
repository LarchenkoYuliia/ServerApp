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
            ManageHelper helper = new ManageHelper();
            var res = helper.CheckUser("admin", "123");
            var rr = helper.Retrieve(1);
            var ll = helper.Retrieve();
            var kk = helper.Retrieve("admin");
            var pp = helper.RetrieveName("admin");
            var oo = helper.Create(new User
            {
                UserID = 2,
                UserLogin = "ya",
                UserPassword = "321",
                UserName = "juli",
                UserSurname = "chumaklove"
            });
            for(int i = 0; i<15;i++)
            {
                Console.WriteLine(res);
                Console.Write(rr.UserSurname);
                Console.Write(rr.UserName);
                Console.Write(rr.UserID);
                Console.Write(rr.UserLogin);
                Console.WriteLine(rr.UserPassword);
                Console.WriteLine(ll);
                Console.Write(kk.UserID.ToString());
                Console.Write(kk.UserName);
                Console.Write(kk.UserSurname);
                Console.Write(kk.UserLogin);
                Console.WriteLine(kk.UserPassword);
                Console.WriteLine(pp);
                Console.WriteLine(oo);
            }
           
        }
    }
}
