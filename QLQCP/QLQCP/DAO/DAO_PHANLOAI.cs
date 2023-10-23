using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCP.DAO
{
    public class DAO_PHANLOAI
    {
        private static DAO_PHANLOAI instance;

        public static DAO_PHANLOAI Instance
        {
            get { if(instance == null)instance = new DAO_PHANLOAI();return DAO_PHANLOAI.instance; }
            private set { DAO_PHANLOAI.instance = value; }
        }

        private DAO_PHANLOAI() { }

        public List<DTO_PHANLOAI> DANHSACHPHANLOAI()
        {
            List<DTO_PHANLOAI> ds = new List<DTO_PHANLOAI> ();

            string query = "SELECT * FROM LOAITHUCUONG";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_PHANLOAI phanloai = new DTO_PHANLOAI(item);
                ds.Add(phanloai);
            }

            return ds;
        }
        public DataTable GetDSPL()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM LOAITHUCUONG");
        }
        public DTO_PHANLOAI DSPhanLoai_Ma(int id)
        {
            DTO_PHANLOAI phanloai = null;

            string query = "SELECT * FROM LOAITHUCUONG WHERE MaLoaiTU = " + id ;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                phanloai = new DTO_PHANLOAI(item);
                return phanloai;
            }


            return phanloai;
        }

        public List<DTO_PHANLOAI> GetListPLoai()
        {
            List<DTO_PHANLOAI> list = new List<DTO_PHANLOAI>();
            string query = "SELECT * FROM LOAITHUCUONG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO_PHANLOAI loai = new DTO_PHANLOAI(item);
                list.Add(loai);
            }
            return list;
        }
        
        public bool ThemLoai(string tenLoai)
        {
            string query = string.Format("INSERT LOAITHUCUONG (TenLoaiTU) VALUES (N'{0}')", tenLoai);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool SuaLoai(int maLoai, string tenLoai)
        {
            string query = string.Format("UPDATE LOAITHUCUONG SET TenLoaiTU = N'{0}' WHERE MaLoaiTU = {1}", tenLoai, maLoai);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool XoaLoai(string tenLoai)
        {

            string query = string.Format("DELETE LOAITHUCUONG WHERE TenLoaiTU = N'{0}'", tenLoai);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

    }
}
