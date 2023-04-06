using System;
using System.Windows.Forms;

namespace USB_Sanitizer
{
    static class Helpers
    {
        static public void ControlInvokeRequired(Control control, Action action)
        {
            control.Invoke(new MethodInvoker(delegate () { action(); }));
        }

        static public void Enable(this Control con, bool enable)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    c.Enable(enable);
                }

                try
                {
                    con.Invoke((MethodInvoker)(() => con.Enabled = enable));
                }
                catch
                {
                    //INTENTIONALLY LEFT EMPTY
                }
            }
        }

        static public string Truncate(this string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }

            return source;
        }
    }
}
