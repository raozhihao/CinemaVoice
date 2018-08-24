using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 语音播报.Model
{
    class FormFactory<T> where T : Form, new()
    {
        private static T TForm = null;
        public static T GetForm()
        {
            if (TForm == null || TForm.IsDisposed)
            {
                TForm = new T();
            }
            return TForm;
        }
    }
}
