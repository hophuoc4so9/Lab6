using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUII
{
    public partial class frmNhap : Form
    {
        public frmNhap()
        {
            InitializeComponent();
        }

        private void frmNhap_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "HP");
            test.Add("2", "Dell");
         
            cboHang.DataSource = new BindingSource(test, null);
            cboHang.DisplayMember = "Value";
            cboHang.ValueMember = "Key";
            cboHang.SelectedItem = 0;
        }
    }
}
