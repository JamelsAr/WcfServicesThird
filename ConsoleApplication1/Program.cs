using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMgr.Common;
using BookMgr.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookServiceRef.BookServiceClient book = new BookServiceRef.BookServiceClient();
            Books b = XmlHelper.DeSerializer<Books>(book.Get("4939"));
           // string s = book.Delete("4939");
            //Console.WriteLine(b.Author);
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
