using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BookMgr.Model;
using BookMgr.Common;
using System.Data.Entity;

namespace BookMgr.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BookService.svc 或 BookService.svc.cs，然后开始调试。
    public class BookService : IBookService
    {

        BookEntities db = new BookEntities();


        /// <summary>
        /// 添加书籍信息
        /// </summary>
        /// <param name="mbook"></param>
        /// <returns></returns>
        public string Add(string mbook)
        {
            try
            {
                Books book = XmlHelper.DeSerializer<Books>(mbook);

                db.Books.Add(book);
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                return ex.Message;

            }
            return "true";

        }


        /// <summary>
        /// 修改书籍
        /// </summary>
        /// <param name="mbook"></param>
        /// <returns></returns>
        public string Edit(string mbook)
        {
            try
            {
                Books book = XmlHelper.DeSerializer<Books>(mbook);

                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                //这里如果出现异常，则返回一个自定义的错误信息，用于进行调试，可以看到更详细的异常信息，方便定位问题。
                string reason = GetErrorMessage(ex);
                SQLError error = new SQLError("更新数据库操作", reason);
                throw new FaultException<SQLError>(error, new FaultReason(reason), new FaultCode("Edit"));
            }
            return "true";
        }


        /// <summary>
        /// 通过书籍Id得到书籍
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public string Get(string bookId)
        {
            try
            {
                 int id = Convert.ToInt32(bookId);
                Books book = db.Books.Find(id);
                string xml = XmlHelper.ToXML<Books>(book);
                return xml;
            }
            catch (Exception ex)
            {
                //这里如果出现异常，则返回一个自定义的错误信息，用于进行调试，可以看到更详细的异常信息，方便定位问题。
                string reason = GetErrorMessage(ex);
                SQLError error = new SQLError("查询数据库操作", reason);
                throw new FaultException<SQLError>(error, new FaultReason(reason), new FaultCode("Get"));
            }
        }


        /// <summary>
        /// 通过id删除书籍
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        public string Delete(string bookInfo)
        {
            try
            {
                Books book = XmlHelper.DeSerializer<Books>(bookInfo);
                db.Entry(book).State = EntityState.Deleted;
                db.SaveChanges();
            }

            catch (Exception ex)
            {

                return ex.Message;
            }

            return "true";
        }


        StringBuilder sb = new StringBuilder();
        /// <summary>
        /// 递归获取错误信息的内部错误信息，直到InnerException为null
        /// </summary>
        /// <param name="ex"></param>
        private string GetErrorMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                sb.Append("InnerException：" + ex.Message + ",");
                GetErrorMessage(ex.InnerException);
            }
            else
            {
                sb.Append(ex.Message + ",");
            }
            return sb.ToString();
        }

    }
}
