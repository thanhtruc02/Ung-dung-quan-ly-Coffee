using Microsoft.Reporting.WinForms;
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
    public partial class fAdmin : Form
    {
        BindingSource dsMon = new BindingSource();

        BindingSource dsTK = new BindingSource();

        BindingSource dsLoai = new BindingSource();

        BindingSource dsBan =  new BindingSource();

        public DTO_TAIKHOAN dangnhapTK;
        public fAdmin()
        {
            InitializeComponent();

            dtgvMonan.DataSource = dsMon;
            dtgvTaikhoan.DataSource = dsTK;
            dtgvPhanLoai.DataSource = dsLoai;
            dtgvBan.DataSource = dsBan;

            LoadDateTimePickerBill();
            LoadDSHoaDon_Ngay(dtTungay.Value, dtDenngay.Value);
            LoadDSTU();
            LoadTK();
            AddTU();
            AddTK();
            LoadDanhSachMon(cbDanhmucMonan);
            LoadListBan();
            LoadListLoai();
            AddPLoai();
            AddBan();
            LoadDSL();
            LoadLoai();
            LoadBan();

            //LoadTaiKhoanList();
        }

        /*void LoadFoodList()
        {
            string query = "SELECT * FROM THUCAN";

            dtgvMonan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }*/
        /*void LoadTaiKhoanList()
        {
            string query = "EXEC dbo.TAIKHOAN_TenUser @ten";

            dtgvTaikhoan.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "chuppa" });
        }*/
        #region methods

        void AddTK()
        {
            txtTentaikhoan.DataBindings.Add(new Binding("Text", dtgvTaikhoan.DataSource, "TenUser", true, DataSourceUpdateMode.Never));
            txtTenhienthi.DataBindings.Add(new Binding("Text", dtgvTaikhoan.DataSource, "TenTK", true, DataSourceUpdateMode.Never));
            nmLoaiTK.DataBindings.Add(new Binding("Value", dtgvTaikhoan.DataSource, "LoaiTK", true, DataSourceUpdateMode.Never));

        }

        void LoadTK()
        {
            dsTK.DataSource = DAO_TAIKHOAN.Instance.GetDSTK();
        }
        void LoadLoai()
        {
            dsLoai.DataSource =DAO_PHANLOAI.Instance.GetDSPL();
        }
        void LoadBan()
        {
            dsBan.DataSource = DAO_BAN.Instance.GetDSB();
        }
        void LoadDSHoaDon_Ngay(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            dtgvDoanhthu.DataSource = DAO_HOADON.Instance.GetHoaDon_Ngay(dateCheckIn, dateCheckOut);

        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtTungay.Value = new DateTime(today.Year, today.Month, 1);
            dtDenngay.Value = dtTungay.Value.AddMonths(1).AddDays(-1);
        }
        void AddTU()
        {
            txtTenmon.DataBindings.Add(new Binding("Text", dtgvMonan.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            txtMaMonan.DataBindings.Add(new Binding("Text", dtgvMonan.DataSource, "MA", true, DataSourceUpdateMode.Never));
            nmGiamon.DataBindings.Add(new Binding("Value", dtgvMonan.DataSource, "Gia", true, DataSourceUpdateMode.Never));
        }

        void LoadDanhSachMon(ComboBox cb)
        {
            cb.DataSource = DAO_PHANLOAI.Instance.DANHSACHPHANLOAI();
            cb.DisplayMember = "Ten";
        }
        void LoadDSTU()
        {
            dsMon.DataSource = DAO_THUCUONG.Instance.GetDSTU();
        }
        void LoadDSL()
        {
            dsLoai.DataSource = DAO_PHANLOAI.Instance.GetListPLoai();
        }
        void LoadDSB()
        {
            dsBan.DataSource = DAO_BAN.Instance.GetListBan();
        }
        void AddPLoai()
        {
            txtTenLoai.DataBindings.Add(new Binding("Text", dtgvPhanLoai.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            txtMaLoai.DataBindings.Add(new Binding("Text", dtgvPhanLoai.DataSource, "MA", true, DataSourceUpdateMode.Never));
        }
        void AddBan()
        {
            txtMaBan.DataBindings.Add(new Binding("Text", dtgvBan.DataSource, "MaB", true, DataSourceUpdateMode.Never));
            txtTenban.DataBindings.Add(new Binding("Text", dtgvBan.DataSource, "TenB", true, DataSourceUpdateMode.Never));
            //cbTinhtrangBan.DataSource = DAO_BAN.Instance.LoadBanList();
            // cbTinhtrangBan.DisplayMember = "Trangthai";
           
        }
        void ThemTK(string tenUser, string tenTK, int loaiTK)
        {
           if( DAO_TAIKHOAN.Instance.ThemTK(tenUser, tenTK, loaiTK))
            {
                MessageBox.Show("Them tai khoan thanh cong");
            }
            else
            {
                MessageBox.Show("Them tai khoan that bai");
            }
            LoadTK();
        }
        void ThemBan(string tenB, string trangthai)
        {
            if(DAO_BAN.Instance.ThemBan(tenB, trangthai))
            {
                MessageBox.Show("Thanh cong");
            }
            else
            {
                MessageBox.Show("that bai");
            }
            LoadBan();
        }
        void SuaTK(string tenUser, string tenTK, int loaiTK)
        {
            if (DAO_TAIKHOAN.Instance.SuaTK(tenUser, tenTK, loaiTK))
            {
                MessageBox.Show("Sua tai khoan thanh cong");
            }
            else
            {
                MessageBox.Show("Sua tai khoan that bai");
            }
            LoadTK();
        }

        void XoaTK(string tenUser)
        {
            if (dangnhapTK.TenUser.Equals(tenUser))
            {
                MessageBox.Show("Vui long khong xoa chinh chu");
                return;
            }
            else
            {
                MessageBox.Show("Xoa tai khoan that bai");
            }
            LoadTK();
        }

        void XoaLoai(string tenLoai)
        {
            if (DAO_PHANLOAI.Instance.XoaLoai(tenLoai))
            {
                MessageBox.Show("Xoa loai thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa loai that bai");
            }
            LoadLoai();
        }

        /*void XoaBan(string tenB)
        {
            if (DAO_BAN.Instance.XoaBan(tenB))
            {
                MessageBox.Show("Xoa ban thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa ban that bai");
            }
            LoadBan();
        }*/
        void DatLaiMK (string tenUser)
        {
            if (DAO_TAIKHOAN.Instance.DatLaiMK(tenUser))
            {
                MessageBox.Show("Dat lai mat khau thanh cong");
            }
            else
            {
                MessageBox.Show("Dat lai mat  khau that bai");
            }
            
        }

        void LoadListLoai()
        {
            dtgvPhanLoai.DataSource = DAO_PHANLOAI.Instance.GetListPLoai();
        }
        void LoadListBan()
        {
            dtgvBan.DataSource = DAO_BAN.Instance.LoadBanList();
        }
        #endregion

        #region events

        List<DTO_THUCUONG> TimTU_TenTU(string ten)
        {
            List<DTO_THUCUONG> dsTU = DAO_THUCUONG.Instance.TimTU_TenTU(ten);

            return dsTU;
        }
        private void txtMaMonan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvMonan.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvMonan.SelectedCells[0].OwningRow.Cells["MaLoaiTU"].Value;

                    DTO_PHANLOAI phanloai = DAO_PHANLOAI.Instance.DSPhanLoai_Ma(id);

                    cbDanhmucMonan.SelectedItem = phanloai;

                    int index = -1;
                    int i = 0;
                    foreach (DTO_PHANLOAI item in cbDanhmucMonan.Items)
                    {
                        if (item.MA == phanloai.MA)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbDanhmucMonan.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        {
            string tenTU = txtTenmon.Text;
            int maLoaiTU = (cbDanhmucMonan.SelectedItem as DTO_PHANLOAI).MA;
            float gia = (float)nmGiamon.Value;

            if (DAO_THUCUONG.Instance.ThemMon(tenTU, maLoaiTU, gia))
            {
                MessageBox.Show("Them mon thanh cong!");
                LoadDSTU();
                if (themMon != null)
                    themMon(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Co loi khi them mon");
            }
        }
        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvBan.Rows[dtgvBan.CurrentCell.RowIndex];
            txtMaBan.Text = row.Cells[2].Value.ToString();
            txtTenban.Text = row.Cells[1].Value.ToString();
            cbTinhtrangBan.Text = row.Cells[0].Value.ToString();
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLoai.Text;

            if (DAO_PHANLOAI.Instance.ThemLoai(tenLoai))
            {
                MessageBox.Show("Them loai thanh cong!");
                LoadDSL();
            }
            else
            {
                MessageBox.Show("Co loi khi them loai");
            }
        }
        private void btnSuamon_Click(object sender, EventArgs e)
        {
            string tenTU = txtTenmon.Text;
            int maLoaiTU = (cbDanhmucMonan.SelectedItem as DTO_PHANLOAI).MA;
            float gia = (float)nmGiamon.Value;
            int id = Convert.ToInt32(txtMaMonan.Text);

            if (DAO_THUCUONG.Instance.SuaMon(id, tenTU, maLoaiTU, gia))
            {
                MessageBox.Show("Sua mon thanh cong!");
                LoadDSTU();
                if(suaMon != null)
                    suaMon(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Co loi khi sua mon");
            }
        }
        private void dtgvPhanLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvPhanLoai.Rows[dtgvPhanLoai.CurrentCell.RowIndex];
            txtMaLoai.Text = row.Cells[1].Value.ToString();
            txtTenLoai.Text = row.Cells[0].Value.ToString();
        }

        private void btnSualoai_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLoai.Text;
            int id = Convert.ToInt32(txtMaLoai.Text);

            if (DAO_PHANLOAI.Instance.SuaLoai(id, tenLoai))
            {
                MessageBox.Show("Sua loai thanh cong!");
                LoadDSL();
            }
            else
            {
                MessageBox.Show("Co loi khi sua loai");
            }
        }
        private void btnXoamon_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMaMonan.Text);

            if (DAO_THUCUONG.Instance.XoaMon(id))
            {
                MessageBox.Show("Xoa mon thanh cong");
                LoadDSTU();
                if (xoaMon != null)
                    xoaMon(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Loi khi xoa mon");
            }
        }
        private void btnXemmon_Click(object sender, EventArgs e)
        {
            LoadDSTU();
        }
        private void btnXemthongke_Click(object sender, EventArgs e)
        {
            LoadDSHoaDon_Ngay(dtTungay.Value, dtDenngay.Value);
        }
        private event EventHandler themMon;
        public event EventHandler ThemMon
        {
            add { themMon += value; }
            remove { themMon -= value; }
        }

        private event EventHandler xoaMon;
        public event EventHandler XoaMon
        {
            add { xoaMon += value; }
            remove { xoaMon -= value; }
        }

        private event EventHandler suaMon;
        public event EventHandler SuaMon
        {
            add { suaMon += value; }
            remove { suaMon -= value; }
        }
        /*
        private event EventHandler themB;
        public event EventHandler ThemB
        {
            add { themB += value; }
            remove { themB -= value; }
        }

        private event EventHandler xoaBan;
        public event EventHandler XoaBan
        {
            add { xoaBan += value; }
            remove { xoaBan -= value; }
        }

        private event EventHandler suaBan;
        public event EventHandler SuaBan
        {
            add { suaBan += value; }
            remove { suaBan -= value; }
        }
        */
        private void btnTimmon_Click(object sender, EventArgs e)
        {
           dsMon.DataSource =  TimTU_TenTU(txtTimtenmon.Text);
        }

        private void btnXemtaikhoan_Click(object sender, EventArgs e)
        {
            LoadTK();
        }
        private void btnDatlaiMK_Click(object sender, EventArgs e)
        {
            string tenUser = txtTentaikhoan.Text;

            DatLaiMK(tenUser);
        }
        private void btnThemtaikhoan_Click(object sender, EventArgs e)
        {
            string user = txtTentaikhoan.Text;
            string display = txtTenhienthi.Text;
            int type = (int)nmLoaiTK.Value;

            ThemTK(user, display, type);
        }

        private void btnXoataikhoan_Click(object sender, EventArgs e)
        {
            string user = txtTentaikhoan.Text;

            XoaTK(user);
        }
        private void btnXoaloai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac chan muon xoa?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               string loai = txtTenLoai.Text;
                XoaLoai(loai);
            }
        }
        private void btnSuataikhoan_Click(object sender, EventArgs e)
        {
            string user = txtTentaikhoan.Text;
            string display = txtTenhienthi.Text;
            int type = (int)nmLoaiTK.Value;

           SuaTK(user, display, type);
        }

        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            txtSoTrang.Text = "1";

        }

        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            int Tong = DAO_HOADON.Instance.GetSoHoaDon_Ngay(dtTungay.Value, dtDenngay.Value);

            int TrangCuoi = Tong / 10;

            if (Tong % 10 != 0)
                TrangCuoi++;
            txtSoTrang.Text = TrangCuoi.ToString();
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            dtgvDoanhthu.DataSource = DAO_HOADON.Instance.GetHoaDon_Ngay_Trang(dtTungay.Value, dtDenngay.Value, Convert.ToInt32(txtSoTrang.Text));
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            int trang = Convert.ToInt32(txtSoTrang.Text);

            if (trang > 1)
                trang--;

            txtSoTrang.Text = trang.ToString();
        }

        private void btnTrangTiep_Click(object sender, EventArgs e)
        {
            int trang = Convert.ToInt32(txtSoTrang.Text);
            int Tong = DAO_HOADON.Instance.GetSoHoaDon_Ngay(dtTungay.Value, dtDenngay.Value);

            if (trang < Tong)
                trang++;

            txtSoTrang.Text = trang.ToString();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            HDContext context = new HDContext();
            List<HOADON> dsHD = context.HOADONs.ToList();
            List<RpHD> dsRP = new List<RpHD>();
            foreach (HOADON hd in dsHD)
            {
                RpHD tam = new RpHD();
                tam.MaHD = hd.MaHD.ToString();
                tam.MaB = hd.MaB.ToString();
                tam.CheckIn = hd.CheckIn;
                //tam.CheckOut = hd.CheckOut.Value;
                tam.Discount = (int)hd.Discount;
                //tam.TongTien = (float)hd.TongTien;

                dsRP.Add(tam);

            }
            reportViewer1.LocalReport.ReportPath = "RpHD.rdlc";
            var source = new ReportDataSource("DataSet1", dsRP);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);

            this.reportViewer1.RefreshReport();
        }

        private void btnXemloai_Click(object sender, EventArgs e)
        {
            LoadListLoai();
        }

        private void btnXemban_Click(object sender, EventArgs e)
        {
            LoadListBan();
        }





        #endregion

        private void btnThemban_Click(object sender, EventArgs e)
        {
            string ten = txtTenban.Text;
            string trangthai = cbTinhtrangBan.Text;

            ThemBan(ten, trangthai);
        }

        private void btnXoaban_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac chan muon xoa?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtMaBan.Text);

                if (DAO_BAN.Instance.XoaBan(id))
                {
                    MessageBox.Show("Xoa ban thanh cong");
                    LoadDSB();
                }
                else
                {
                    MessageBox.Show("Loi khi xoa ban");
                }
            }
        }

        private void btnSuaban_Click(object sender, EventArgs e)
        {
            string tenB = txtTenban.Text;
            int id = Convert.ToInt32(txtMaBan.Text);
            string trangthai = cbTinhtrangBan.Text;


            if (DAO_BAN.Instance.SuaBan(id, tenB, trangthai))
            {
                MessageBox.Show("Sua ban thanh cong!");
                LoadDSB();
            }
            else
            {
                MessageBox.Show("Co loi khi sua ban");
            }
        }
    }
}
