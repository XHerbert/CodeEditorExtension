using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xhb.UserControlEx.LineContorl
{
    public partial class LineRichTextBox : UserControl
    {
        public LineRichTextBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint, true);
        }

        private Color _lineNumColor;
        [Browsable(true),Category("行号编辑器设置"),DefaultValue("Green"),Description("设置行号颜色")]
        public Color LineNumColor
        {
            get { return _lineNumColor; }
            set { _lineNumColor = value; 
            
            }
        }
        private Color _lineColor;
        [Browsable(true), Category("行号编辑器设置"), Description("设置中线颜色")]
        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value;
            this.BackColor = _lineColor;
            }
        }
        private Color _textColor;
        [Browsable(true), Category("行号编辑器设置"),Description("设置文本颜色")]
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; this.textBox1.ForeColor = _textColor; }
        }
        private Font _textFont;
        [Browsable(true), Category("行号编辑器设置"), DefaultValue("微软雅黑"), Description("设置文本字体")]
        public Font TextFont
        {
            get { return _textFont; }
            set { _textFont = value; this.textBox1.Font = _textFont; }
        }

        private string _richText;

        [Browsable(true), Category("行号编辑器设置"), DefaultValue("微软雅黑"),Description("设置文本内容")]
        public string RichText
        {
            get { return _richText; }
            set { _richText = value;
            this.textBox1.Text = _richText;
            }
        }


        [Browsable(true), Category("行号编辑器设置"), DefaultValue("Red"), Description("设置文本域背景色")]
        public Color TextBackColor
        {
            get
            {
                return _textBackColor;
            }

            set
            {
                _textBackColor = value;
                this.textBox1.BackColor = _textBackColor;
            }
        }

        private Color _textBackColor;

        private void BuildLineNo()
        {
            //获得当前坐标信息
            Point p = new Point(0, 0);
            int crntFirstIndex = this.textBox1.GetCharIndexFromPosition(p);
            int crntFirstLine = this.textBox1.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.textBox1.GetPositionFromCharIndex(crntFirstIndex);
            p.Y += this.textBox1.Height;
            int crntLastIndex = this.textBox1.GetCharIndexFromPosition(p);
            int crntLastLine = this.textBox1.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = this.textBox1.GetPositionFromCharIndex(crntLastIndex);

            //准备画图
            Graphics g = this.panel1.CreateGraphics();
            Font font = new Font(this.textBox1.Font, this.textBox1.Font.Style);
            SolidBrush brush = new SolidBrush(Color.FromArgb(848200));
            //画图开始
            //刷新画布
            Rectangle rect = this.panel1.ClientRectangle;
            brush.Color = this.panel1.BackColor;
            g.FillRectangle(brush, 0, 0, this.panel1.ClientRectangle.Width, this.panel1.ClientRectangle.Height);
            //brush.Color = ColorTranslator.FromHtml("#6CE26C");//重置画笔颜色
            brush.Color = this._lineNumColor;
            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }

            else
            {
                lineSpace = Convert.ToInt32(this.textBox1.Font.Size);
            }

            int brushX = this.panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 3);

            int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);//惊人的算法啊！！
            for (int i = crntLastLine; i >= crntFirstLine; i--)
            {
                g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuildLineNo();
        }

        private void textBox1_VScroll(object sender, EventArgs e)
        {
            BuildLineNo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            BuildLineNo();
        }

        private void LineRichTextBox_Resize(object sender, EventArgs e)
        {
            this.textBox1.Height = this.Height;
            this.panel1.Height = Height;
            this.textBox1.Width = this.Width - 51;
        }
    }
}
