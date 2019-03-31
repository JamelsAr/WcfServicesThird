using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BookMgr.Services;
using System.ServiceModel.Description;

namespace BookMgr.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BookService)))
            {
                ////指定绑定终结点的地址
                //host.AddServiceEndpoint(typeof(IBookService), new WSHttpBinding(), "http://127.0.0.1:3721/BookService");
                ////数据的发布
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    //创建信息的发布对象
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //    //是否发布元数据以便使用HTTPS/GET请求进行检索
                //    behavior.HttpGetEnabled = true;
                //    //使用HTTPS/GET请求的元数据发布的位置
                //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:3721/BookService/wcfapi");
                //    //添加到发布服务上
                //    host.Description.Behaviors.Add(behavior);

                //}
                host.Opened += delegate
                {
                    Console.WriteLine("CalculatorService已经启动,按任意键终止服务！");
                };
                //通讯状态转换到已打开
                host.Open();

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (ServiceEndpoint se in host.Description.Endpoints)
                {
                    Console.WriteLine("[终结点]: {0}\r\n\t[A-地址]: {1} \r\n\t [B-绑定]: {2} \r\n\t [C-协定]: {3}",

                 se.Name, se.Address, se.Binding.Name, se.Contract.Name);

                }

                Console.ReadLine();
            }
        }
    }
}
