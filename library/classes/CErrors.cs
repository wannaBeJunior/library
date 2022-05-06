using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library.classes
{
    class CErrors
    {
        public static void showErrors(Label label, Form form, List<string> errors)
        {
            label.Text = "";
            int height = label.Height;
            form.Height += errors.Count * height;
            for (int i = 0; i < errors.Count; i++)
            {
                label.Text += errors[i] + '\n';
            }
        }
    }
}
