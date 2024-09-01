using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepwokenChecklist
{
    public partial class URLDialog : Form
    {
        public URLDialog()
        {
            InitializeComponent();
        }

        private void CancelDialog_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadFromUrl_Click(object sender, EventArgs e)
        {
            Program.mainWindow.LoadFromUrl(URLBox.Text);
            Close();
        }
    }
}
