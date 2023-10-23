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
    public class DAO_THUCDON
    {
        private static DAO_THUCDON instance;

        public static DAO_THUCDON Instance
        {
            get { if (instance == null) instance = new DAO_THUCDON(); return DAO_THUCDON.instance; }
            private set { DAO_THUCDON.instance = value; }
        }

        private DAO_THUCDON() { }

        public List<ThucDon> DANHSACHTHUCDON_MAB(int ma)
        {
            List<ThucDon> listMenu = new List<ThucDon> ();

            string query = "SELECT t.TenTU, c.Soluong, t.Gia, t.Gia*c.Soluong AS Tongtien\r\n" +
                "FROM dbo.CHITIETHOADON c, dbo.HOADON h, dbo.THUCUONG t\r\n" +
                "WHERE c.MaHD = h.MaHD\r\nAND c.MaTU = t.MaTU\r\nAND h.Trangthai = 0 AND h.MaB = " + ma;
            DataTable dt =  DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                ThucDon menu = new ThucDon(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
