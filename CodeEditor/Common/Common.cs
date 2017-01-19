using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEditorInterface;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace CodeEditor.Common
{
    public class Common
    {
        /// <summary>
        /// 加载插件
        /// </summary>
        /// <returns></returns>
        public static List<IExcutable> GetPlugins()
        {
            List<IExcutable> implementObject = new List<IExcutable>();
            //获取项目根目录下的Plugins文件夹
            string dir = GetPluginsDir();
            //遍历目标文件夹中包含dll后缀的文件
            foreach (var file in Directory.GetFiles(dir + @"\", "*.dll"))
            {
                //加载程序集
                var asm = Assembly.LoadFrom(file);
                //遍历程序集中的类型
                foreach (var type in asm.GetTypes())
                {
                    //如果是IExcutable接口
                    if (type.GetInterfaces().Contains(typeof(IExcutable)))
                    {
                        //创建接口类型实例
                        var IExcutable = Activator.CreateInstance(type) as IExcutable;
                        if (IExcutable != null)
                        {
                            implementObject.Add(IExcutable);
                        }
                    }
                }
            }
            return implementObject;
        }

        /// <summary>
        /// 获取插件目录
        /// </summary>
        /// <returns></returns>
        static string GetPluginsDir()
        {
            string pluginDir = ConfigurationManager.AppSettings["pluginDir"];
            return pluginDir;
        }
    }
}
