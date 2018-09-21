using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomFormTools
{
    public class TransparentRichTextBox : RichTextBox
    {
        public TransparentRichTextBox()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            //TextChanged += TransparentLabel_TextChanged;
            VScroll += TransparentLabel_TextChanged;
        }

        void TransparentLabel_TextChanged(object sender, System.EventArgs e)
        {
            ForceRefresh();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return parms;
            }
        }
        public void ForceRefresh()
        {
            UpdateStyles();
        }
    }
}
