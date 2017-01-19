using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin.SkinControl;
using System.Windows.Forms;
using Xhb.UserControlEx.LineContorl;
using System.Configuration;
using CodeEditorInterface;

namespace CodeEditor
{
    public partial class MainEdit : CCWin.Skin_Color
    {
        public MainEdit()
        {
            InitializeComponent();
            LoadPlugins();
        }
   
        private void lineRichTextBox1_Load(object sender, EventArgs e)
        {
            this.CodeContent.Width = this.ClientSize.Width;
            this.CodeContent.Height = this.ClientSize.Height;
        }

        private void lineRichTextBox1_Resize(object sender, EventArgs e)
        {
            this.CodeContent.Width = this.Width; 
            this.CodeContent.Height = this.Height;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.CodeContent.Width = this.Width;
            this.CodeContent.Height = this.Height;
        }

        private void New_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 创建插件公共事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plugin_Click(object sender, EventArgs e)
        {
            ToolStripItem item= sender as ToolStripItem;
            if (null != item)
            {

                if (null != item.Tag)
                {
                    IExcutable plugin = item.Tag as IExcutable;
                    if (null != plugin)
                    {
                        CodeContent.RichText=plugin.Excute(CodeContent.RichText);
                    }
                }
            }
        }
       
        /// <summary>
        /// 主程序加载插件
        /// </summary>
        private void LoadPlugins()
        {
            List<IExcutable> list = Common.Common.GetPlugins();
            foreach (var Iplugins in list)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(Iplugins.GetName());
                item.Name = Iplugins.GetName();
                item.Click += new EventHandler(Plugin_Click);
                item.Tag = Iplugins;
                this.Plugins.DropDownItems.Add(item);
            }
        }
    }
}
