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
    public partial class fThongtinTK : Form
    {
        private DTO_TAIKHOAN dangnhapTK;

        public DTO_TAIKHOAN DangnhapTK
        {
            get { return dangnhapTK; }
            set { dangnhapTK = value; DoiTK(dangnhapTK); }
        }
        public fThongtinTK(DTO_TAIKHOAN acc)
        {
            InitializeComponent();

            DangnhapTK = acc;
        }

        void DoiTK(DTO_TAIKHOAN acc)
        {
            txtTenUser.Text = DangnhapTK.TenUser;
            txtTenTaikhoan.Text = DangnhapTK.TenTK;
        }
        void CapnhatTK()
        {
            string tenTK = txtTenTaikhoan.Text;
            string matkhau = txtMatkhau.Text;
            string matkhaumoi = txtMatkhaumoi.Text;
            string nhaplaiMK = txtNhaplai.Text;
            string tenUser = txtTenUser.Text;

            if(!matkhaumoi.Equals(nhaplaiMK)) 
            {
                MessageBox.Show("Vui long nhap lai mat khau dung voi mat khau moi!");
            }
            else
            {
                if(DAO_TAIKHOAN.Instance.CapnhatTK(tenUser, tenTK, matkhau, matkhaumoi))
                {
                    MessageBox.Show("Cap nhat thanh cong!");
                    if (capnhatTaiKhoan != null)
                        capnhatTaiKhoan(this, new TAIKHOANEvent( DAO_TAIKHOAN.Instance.GetTK_TenUser(tenUser)));
                }
                else
                {
                    MessageBox.Show("Vui long nhap dung mat khau!");
                }
            }
        }

        private event EventHandler<TAIKHOANEvent> capnhatTaiKhoan;

        public event EventHandler<TAIKHOANEvent> CapnhatTaiKhoan
        {
            add { capnhatTaiKhoan += value; }
            remove { capnhatTaiKhoan -= value; }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            CapnhatTK();
        }

    }

    public class TAIKHOANEvent:EventArgs
    {
        private DTO_TAIKHOAN acc;

        public DTO_TAIKHOAN Acc
        {
            get { return acc; }
            set { acc = value;}
        }

        public TAIKHOANEvent(DTO_TAIKHOAN acc)
        {
            this.Acc = acc;
        }
    }
}
