using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DAO
{
    public class DAO_BAN
    {
        private static DAO_BAN instance;

        public static DAO_BAN Instance
        {
            get { if (instance == null) instance = new DAO_BAN(); return DAO_BAN.instance; }
            private set { DAO_BAN.instance = value; }
        }

        public static int WidthBan = 100;
        public static int HeightBan = 100;

        private DAO_BAN() { }

        public void CHUYENBAN (int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("CHUYENBAN @maB1 , @maB2 ", new object[] { id1, id2 });
        }
        public DataTable GetDSB()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM BAN");
        }
        public List<DTO_BAN> LoadBanList()
        {
            List<DTO_BAN> banList = new List<DTO_BAN>();

            DataTable data = DataProvider.Instance.ExecuteQuery("DANHSACHBAN");

            foreach (DataRow item in data.Rows)
            {
                DTO_BAN ban = new DTO_BAN(item);
                banList.Add(ban);
            }
            return banList;
        }
        public List<DTO_BAN> GetListBan()
        {
            List<DTO_BAN> list = new List<DTO_BAN>();
            string query = "SELECT * FROM BAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO_BAN ban = new DTO_BAN(item);
                list.Add(ban);
            }
            return list;
        }

        public bool ThemBan(string tenB, string trangthai)
        {
            string query = string.Format("INSERT BAN (TenB, Trangthai) VALUES (N'{0}' , N'{1}')", tenB, trangthai);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool SuaBan(int maB, string tenB, string trangthai)
        {
            string query = string.Format("UPDATE BAN SET TenB = N'{0}',  Trangthai =N'{1}' WHERE MaB = {2}", tenB, trangthai,  maB);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }

        public bool XoaBan(int maB)
        {
            DAO_CTHD.Instance.XoaCTHD_MaB(maB);
            DAO_HOADON.Instance.XoaHD_MaB(maB);
            string query = string.Format("DELETE BAN WHERE MaB = {0}", maB);

            int kq = DataProvider.Instance.ExecuteNonQuery(query);

            return kq > 0;
        }
    }
}
