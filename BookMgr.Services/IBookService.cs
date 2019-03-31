using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BookMgr.Common;

namespace BookMgr.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBookService”。
    [ServiceContract]
    public interface IBookService
    {
        /// <summary>
        /// 添加书籍信息
        /// </summary>
        /// <param name="mbook"></param>
        /// <returns></returns>
        [OperationContract]
        string Add(string mbook);

        /// <summary>
        /// 修改书籍信息
        /// </summary>
        /// <param name="mbook"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(SQLError))]
        string Edit(string mbook);


        /// <summary>
        /// 通过书籍Id进行查询
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [OperationContract]
        string Get(string bookId);

        /// <summary>
        /// 通过Id进行删除
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        [OperationContract]
        string Delete(string bookInfo);
    }
}
