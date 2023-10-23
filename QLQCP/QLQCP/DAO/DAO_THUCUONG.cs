using QLQCP.DTO;
using System.Collections.Generic;
using System.Data;

namespace QLQCP.DAO
{
    public class DAO_THUCUONG
    {
        private static DAO_THUCUONG instance;

        public static DAO_THUCUONG Instance
        {
            get { if (instance == null) instance = new DAO_THUCUONG(); return DAO_THUCUONG.instance; }
            private set { DAO_THUCUONG.instance = value; }
        }

        private DAO_THUCUONG() { }

        public List<DTO_THUCUONG> DSTHUCUONG_MALOAITU(int id)
        {
            List<DTO_THUCUONG> ds = new List<DTO_THUCUONG>();

            string query = "SELECT * FROM THUCUONG WHERE MaLoaiTU = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO_THUCUONG thucuong = new DTO_THUCUONG(item);
                ds.Add(thucuong);
            }

            return ds;
        }
        public List<DTO_THUCUONG> GetDSTU()
        {
            List<DTO_THUCUONG> ds = new List<DTO_THUCUONG>();

            string query = "SELECT * FROM THUCUONG";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO_THUCUONG thucuong = new DTO_THUCUONG(item);
                ds.Add(thucuong);
            }

            return ds;
        }

        public  List<DTO_THUCUONG> TimTU_TenTU(string ten)
        {
            List<DTO_THUCUONG> ds = new List<DTO_THUCUONG>();

            string query = string.Format("SELECT * FROM THUCUONG WHERE dbo.fuConvertToUnsign1(TenTU) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'",ten);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO_THUCUONG thucuong = new DTO_THUCUONG(item);
                ds.Add(thucuong);
            }

            return ds;
        }
        public bool ThemMon(string tenTU, int maLoaiTU, float gia)
        {
            string query = string.Format("INSERT THUCUONG (TenTU, MaLoaiTU, Gia) VALUES (N'{0}',{1}, {2})", tenTU, maLoaiTU, gia);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool SuaMon(int maTU, string tenTU, int maLoaiTU, float gia)
        {
            string query = string.Format("UPDATE THUCUONG SET TenTU = N'{0}',  MaLoaiTU ={1}, Gia = {2} WHERE MaTU = {3}", tenTU, maLoaiTU, gia, maTU);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool XoaMon(int maTU)
        {
            DAO_CTHD.Instance.XoaCTHD_MaTU(maTU);

            string query = string.Format("DELETE THUCUONG WHERE MaTU = {0}", maTU);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }
    }
}
