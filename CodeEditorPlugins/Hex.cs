using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEditorInterface;

namespace CodeEditorPlugins
{
    public class Hex : IExcutable
    {

        string IExcutable.Excute(string text)
        {
            text = text.ToUpper();
            return text;
        }

        string IExcutable.GetName()
        {
            return "Hex";
        }
    }
}
