using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace CustomFormTools
{
    public class RoundButton : Button
    {
        readonly Pen _pen = new Pen(Color.Red);

        public int BorderWidth
        {
            get { return (int)_pen.Width; }
            set
            {
                _pen.Width = value;
                Invalidate();                
            }
        }

        public Color BorderColor
        {
            get { return _pen.Color; }
            set
            {
                _pen.Color = value;
                Invalidate();
            }
        }

        protected override void InitLayout()
        {
            Paint += Pintar;
            base.InitLayout();
        }

        private void Pintar(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath  = new GraphicsPath();
            Rectangle rectangle = ClientRectangle;

            rectangle.Inflate(-2, -2);
            _pen.DashStyle = DashStyle.Solid;

            e.Graphics.DrawEllipse(_pen, rectangle);
            //rectangle.Inflate(0, 0);
            buttonPath.AddEllipse(rectangle);
            Region = new Region(buttonPath);

        }
    }
}
