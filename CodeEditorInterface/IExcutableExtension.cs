using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditorInterface
{
    public interface IExcutableExtension:IExcutable
    {
        void Excute(Control ctrl);
    }
}
