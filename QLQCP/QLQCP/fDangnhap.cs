using QLQCP.DAO;
using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCP
{
    public partial class fDangnhap : Form
    {
        public fDangnhap()
        {
            InitializeComponent();
        }



        bool Login(string tenUser, string matkhau)
        {

            return DAO_TAIKHOAN.Instance.Login(tenUser, matkhau);
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tenUser = txtTenUser.Text;
            string matkhau = txtMatkhau.Text;
            if (Login(tenUser, matkhau))
            {
                DTO_TAIKHOAN dangnhapTK = DAO_TAIKHOAN.Instance.GetTK_TenUser(tenUser);
                fQLBan f = new fQLBan(dangnhapTK);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai ten tai khoan hoac mat khau!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fDangnhap_Load(object sender, EventArgs e)
        {

        }

    }

}
