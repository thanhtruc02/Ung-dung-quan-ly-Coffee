using QLQCP.DAO;
using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QLQCP
{
    public partial class fQLBan : Form
    {

        private DTO_TAIKHOAN dangnhapTK;

        public DTO_TAIKHOAN DangnhapTK
        {
            get { return dangnhapTK; }
            set { dangnhapTK = value; DoiTK(dangnhapTK.LoaiTK); }
        }
        public fQLBan(DTO_TAIKHOAN acc)
        {
            InitializeComponent();

            this.DangnhapTK = acc;

            LoadBan();
            LoadPhanLloai();
            LoadComboBoxBan(cbChuyenban);
        }

        #region Method

        void DoiTK(int loaiTK)
        {
            adminToolStripMenuItem.Enabled = loaiTK == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + DangnhapTK.TenTK + ")";
        }
        void LoadPhanLloai()
        {
            List<DTO_PHANLOAI> dsPhanLoai = DAO_PHANLOAI.Instance.DANHSACHPHANLOAI();
            cbPhanLoai.DataSource = dsPhanLoai;
            cbPhanLoai.DisplayMember = "Ten";
        }

        void LoadDSMon_MaLoaiTU(int id)
        {
            List<DTO_THUCUONG> dsMon = DAO_THUCUONG.Instance.DSTHUCUONG_MALOAITU(id);
            cbMon.DataSource = dsMon;
            cbMon.DisplayMember = "Ten";
        }
        void LoadBan()
        {
            flpBan.Controls.Clear();
            List<DTO_BAN> banList = DAO_BAN.Instance.LoadBanList();

            foreach (DTO_BAN item in banList)
            {
                Button btn = new Button()
                {
                    Width = DAO_BAN.WidthBan,
                    Height = DAO_BAN.HeightBan
                };
                btn.Text = item.TenB + Environment.NewLine + item.Trangthai;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Trangthai)
                {
                    case "Trong":
                        btn.BackColor = Color.PaleTurquoise;
                        break;
                    default:
                        btn.BackColor = Color.BlanchedAlmond;
                        break;
                }
                flpBan.Controls.Add(btn);
            }
        }

        void HienthiHoaDon(int Ma)
        {
            lsvHoaDon.Items.Clear();
            List<ThucDon> dsCTHD = DAO_THUCDON.Instance.DANHSACHTHUCDON_MAB(Ma);
            float ThanhTien = 0;

            foreach (ThucDon item in dsCTHD)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenTU.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                ThanhTien += item.ThanhTien;

                lsvHoaDon.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTongtien.Text = ThanhTien.ToString("c", culture);

        }

        void LoadComboBoxBan(ComboBox cb)
        {
            cb.DataSource = DAO_BAN.Instance.LoadBanList();
            cb.DisplayMember = "TenB";
        }
        #endregion

        #region Events

        private void fQLBan_Load(object sender, EventArgs e)
        {

        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThanhtoan_Click(this, new EventArgs());
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btThemMon_Click(this, new EventArgs());
        }

        void btn_Click(object sender, EventArgs e)
        {
            int maB = ((sender as Button).Tag as DTO_BAN).MaB;
            lsvHoaDon.Tag = (sender as Button).Tag;
            HienthiHoaDon(maB);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongtinTK f = new fThongtinTK(DangnhapTK);
            f.CapnhatTaiKhoan += f_CapnhatTaiKhoan;
            f.ShowDialog();
        }

        private void f_CapnhatTaiKhoan(object sender, TAIKHOANEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.TenTK + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.dangnhapTK = DangnhapTK;
            f.ThemMon += f_ThemMon;
            f.XoaMon += f_XoaMon;
            f.SuaMon += f_SuaMon;
            f.ShowDialog();
        }


        void f_SuaMon(object sender, EventArgs e)
        {
            LoadDSMon_MaLoaiTU((cbPhanLoai.SelectedItem as DTO_PHANLOAI).MA);
            if (lsvHoaDon.Tag != null)
                HienthiHoaDon((lsvHoaDon.Tag as DTO_BAN).MaB);
        }

        void f_XoaMon(object sender, EventArgs e)
        {
            LoadDSMon_MaLoaiTU((cbPhanLoai.SelectedItem as DTO_PHANLOAI).MA);
            if (lsvHoaDon.Tag != null)
                HienthiHoaDon((lsvHoaDon.Tag as DTO_BAN).MaB);
            LoadBan();
        }

        void f_ThemMon(object sender, EventArgs e)
        {
            LoadDSMon_MaLoaiTU((cbPhanLoai.SelectedItem as DTO_PHANLOAI).MA);
            if (lsvHoaDon.Tag != null)
                HienthiHoaDon((lsvHoaDon.Tag as DTO_BAN).MaB);
        }

        private void cbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
            DTO_PHANLOAI selected = cb.SelectedItem as DTO_PHANLOAI;
            id = selected.MA;
            LoadDSMon_MaLoaiTU(id);
        }

        private void btThemMon_Click(object sender, EventArgs e)
        {
            DTO_BAN table = lsvHoaDon.Tag as DTO_BAN;

            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }

            int idHD = DAO_HOADON.Instance.DSHOADON_MABAN(table.MaB);
            int idTU = (cbMon.SelectedItem as DTO_THUCUONG).MA;
            int soluong = (int)nmSLMon.Value;

            if (idHD == -1)
            {
                DAO_HOADON.Instance.ThemHoaDon(table.MaB);
                DAO_CTHD.Instance.ThemCTHD(DAO_HOADON.Instance.GetMaxIDBill(), idTU, soluong);
            }
            else
            {
                DAO_CTHD.Instance.ThemCTHD(idHD, idTU, soluong);

            }

            HienthiHoaDon(table.MaB);
            LoadBan();

        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            DTO_BAN table = lsvHoaDon.Tag as DTO_BAN;

            int idHD = DAO_HOADON.Instance.DSHOADON_MABAN(table.MaB);
            int discount = (int)nmGiamgia.Value;
            double TongTien = Convert.ToDouble(txtTongtien.Text.Split(',')[0]);
            double GiaTongCuoi = TongTien - (TongTien / 100) * discount;

            if (idHD != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho {0}\n Tổng tiền -(Tổng tiền / 100) x  Giảm giá \n= {1} - ({1} / 100) x {2} = {3}", table.TenB, TongTien, discount, GiaTongCuoi), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) 
                {
                    DAO_HOADON.Instance.CheckOut(idHD, discount, (float)GiaTongCuoi);
                    HienthiHoaDon(table.MaB);
                    LoadBan();

                }
            }
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {

            int id1 = (lsvHoaDon.Tag as DTO_BAN).MaB;

            int id2 = (cbChuyenban.SelectedItem as DTO_BAN).MaB;

            if (MessageBox.Show(string.Format("Bạn có chắc muốn chuyển từ bàn {0} qua bàn {1}", (lsvHoaDon.Tag as DTO_BAN).TenB, (cbChuyenban.SelectedItem as DTO_BAN).TenB), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {

                DAO_BAN.Instance.CHUYENBAN(id1, id2);
                LoadBan();

            }

        }

        #endregion

    }

}
