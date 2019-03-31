using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace BookMgr.Common
{
    public class XmlHelper
    {
        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filename">XML文件路径</param>
        /// <returns></returns>
        public static T ParseXML<T>(string filename)
        {
            T obj = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            /* If the XML document has been altered with unknown
                                nodes or attributes, handle them with the
                                UnknownNode and UnknownAttribute events.*/


            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filename, FileMode.Open);

            try
            {
                obj = (T)serializer.Deserialize(fs);
            }
            catch (System.Exception ex)
            {
                string s = ex.Message;
                throw ex;
            }
            finally
            {
                fs.Close();
            }

            return obj;

        }

        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <param name="filename">XML文件路径</param>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        public static object ToObject(string filename, Type type)
        {
            object obj;
            XmlSerializer serializer = new XmlSerializer(type);
            FileStream fs = new FileStream(filename, FileMode.Open);
            try
            {
                obj = serializer.Deserialize(fs);
            }

            catch (System.Exception ex)
            {
                string s = ex.Message;
                throw ex;

            }
            finally
            {

                fs.Close();
            }
            return obj;
        }



        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">XML数据对象字符串</param>
        /// <returns></returns>
        public static T DeSerializer<T>(string data)
        {

            T obj = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                using (StringReader sr = new StringReader(data))
                {
                    XmlSerializer xz = new XmlSerializer(typeof(T));
                    obj = (T)serializer.Deserialize(sr);

                }

            }

            catch (System.Exception ex)
            {
                string s = ex.Message;
                throw ex;

            }
            return obj;

        }

        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="fullFileName">XML文件名</param>
        /// <param name="data">XML字符串</param>
        public static void CreateXML(string fullFileName, string data)
        {

            using (StreamWriter sw = new StreamWriter(fullFileName, false, Encoding.UTF8))
            {
                sw.Write(data);
            }

        }

        /// <summary>
        /// 把对象转换成字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象实体</param>
        /// <returns></returns>

        public static string ToXML<T>(T t)
        {

            using (StringWriter sw = new StringWriter())
            {

                XmlSerializer xz = new XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }
        }
    }
}
