using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeEditorInterface;
using System.Windows.Forms;

namespace CodeEditorPlugins
{
    public class Format : IExcutableExtension
    {
        public string Excute(string text)
        {
            text = text.ToUpper();
            return text;
        }

        public void Excute(System.Windows.Forms.Control ctrl)
        {
            TextBox box = ctrl as TextBox;
            box.Text = "IExcutableExtension";
        }

        public string GetName()
        {
            return "Format";
        }
    }
}
