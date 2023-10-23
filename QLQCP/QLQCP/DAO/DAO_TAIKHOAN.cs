using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography; //MD5
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QLQCP.DAO
{
    public class DAO_TAIKHOAN
    {
        private static DAO_TAIKHOAN instance;

        public static DAO_TAIKHOAN Instance
        {
            get { if (instance == null) instance = new DAO_TAIKHOAN(); return instance; }
            private set { instance = value; }
        }

        private DAO_TAIKHOAN() { }

        public bool Login(string tenUser, string matkhau)
        {
            byte[] tam = ASCIIEncoding.ASCII.GetBytes(matkhau);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(tam);


            string hasMK = "";

            /*var list = hasData.ToString();
            list.Reverse();
            */

            foreach (byte item in hasData)
            {
                hasMK += item;
            }

            string query = "DANGNHAP @ten , @mk";
            DataTable ketqua = DataProvider.Instance.ExecuteQuery(query, new object[] { tenUser, hasMK/*list* thay cho matkhau*/ });
            return ketqua.Rows.Count > 0;
        }

        public bool CapnhatTK(string tenUser, string tenTK, string matkhau, string matkhaumoi)
        {
            byte[] tam = ASCIIEncoding.ASCII.GetBytes(matkhau);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(tam);


            string hasMK = "";

            /*var list = hasData.ToString();
            list.Reverse();
            */

            foreach (byte item in hasData)
            {
                hasMK += item;
            }
            int kq = DataProvider.Instance.ExecuteNonQuery(
                "exec CapNhatTK @tenUser , @tenTK , @matkhau , @matkhaumoi ", new object[] {tenUser, tenTK, hasMK, matkhaumoi});
            return kq > 0;
        }

        public DataTable GetDSTK()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT TenUser, TenTK, LoaiTK FROM TAIKHOAN");
        }

        public DTO_TAIKHOAN GetTK_TenUser (string tenUser)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TAIKHOAN WHERE TenUser = N'" + tenUser + "'");

            foreach (DataRow item in data.Rows) 
            {
                return new DTO_TAIKHOAN(item);

            }
            return null;
        }

        public bool ThemTK(string tenUser, string tenTK, int loaiTK)
        {
            string query = string.Format("INSERT TAIKHOAN (TenUser, TenTK, LoaiTK, Matkhau) VALUES (N'{0}',N'{1}', {2}, N'{3}')", tenUser, tenTK, loaiTK, "1051418116115713818282291297315712311222104");

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool SuaTK(string tenUser, string tenTK, int loaiTK)
        {
            string query = string.Format("UPDATE TAIKHOAN SET TenTK =N'{0}', LoaiTK = {1} WHERE TenUser = N'{2}'", tenTK, loaiTK, tenUser);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool XoaTK(string tenUser)
        {

            string query = string.Format("DELETE TAIKHOAN WHERE TenUser = N'{0}'", tenUser);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool DatLaiMK (string tenUser)
        {
            string query = string.Format("UPDATE TAIKHOAN SET Matkhau = N'1051418116115713818282291297315712311222104' WHERE TenUser = N'{0}'", tenUser);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }
    }
}
