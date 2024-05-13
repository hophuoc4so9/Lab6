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
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }
        private Form CurentFromChild;
        private void OpenChild(Form form)
        {
            if(CurentFromChild!=null)
            {
                CurentFromChild.Close();
            }
            CurentFromChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel5.Controls.Add(form);
            panel5.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void bai1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            OpenChild(new NhapXuatFileExcel());
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            OpenChild(new frmLop());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChild(new img());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
