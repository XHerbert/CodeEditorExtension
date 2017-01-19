using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorInterface
{
    public interface IExcutable
    {
        //用于主程序动态创建菜单
        string GetName();
        //执行具体的文本操作
        string Excute(string text);
    }
}
