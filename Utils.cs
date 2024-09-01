using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepwokenChecklist
{
    internal static class Utils
    {
        // Partial Credit to TxCsharper @ StackOverflow
        // I didn't want to bother making this myself

        public static T Clone<T>(this T srcCtl)
            where T : Control
        {
            var cloned = Activator.CreateInstance(srcCtl.GetType()) as T;
            var binding = BindingFlags.Public | BindingFlags.Instance;
            foreach (PropertyInfo prop in srcCtl.GetType().GetProperties(binding))
            {
                if (IsClonable(prop))
                {
                    object val = prop.GetValue(srcCtl);
                    prop.SetValue(cloned, val, null);
                }
            }

            foreach (Control ctl in srcCtl.Controls)
            {
                cloned.Controls.Add(ctl.Clone());
            }

            return cloned;
        }

        public static bool IsClonable(PropertyInfo prop)
        {
            var browsableAttr = prop.GetCustomAttribute(typeof(BrowsableAttribute), true) as BrowsableAttribute;
            var editorBrowsableAttr = prop.GetCustomAttribute(typeof(EditorBrowsableAttribute), true) as EditorBrowsableAttribute;

            return prop.CanWrite
                && (browsableAttr == null || browsableAttr.Browsable == true)
                && (editorBrowsableAttr == null || editorBrowsableAttr.State != EditorBrowsableState.Advanced);
        }
    }
}
