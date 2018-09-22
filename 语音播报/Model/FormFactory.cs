using System.Windows.Forms;

namespace 语音播报.Model
{
    /// <summary>
    /// 单例模式(暂无使用)
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
