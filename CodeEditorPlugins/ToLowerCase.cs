using CodeEditorInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorPlugins
{
    public class ToLowerCase : IExcutable
    {
        public string Excute(string text)
        {
            text=text.ToLower();
            return text;
        }

        public string GetName()
        {
            return "ToLower";
        }
    }
}
