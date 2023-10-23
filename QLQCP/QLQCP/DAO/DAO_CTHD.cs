using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DAO
{
    public class DAO_CTHD
    {
        private static DAO_CTHD instance;

        public static DAO_CTHD Instance
        {
            get { if (instance == null) instance = new DAO_CTHD(); return DAO_CTHD.instance; }
            private set { DAO_CTHD.instance = value; }
        }
        public DAO_CTHD() { }

        public void XoaCTHD_MaTU(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.CHITIETHOADON WHERE MaTU = " + id);
        }
        public void XoaCTHD_MaB(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM CHITIETHOADON WHERE MaHD IN (SELECT MaHD FROM HOADON  WHERE MaB = " + id  + ")");
        }
        public List<DTO_CTHD> DANHSACHCTHD_MAHD(int ma)
        {
            List<DTO_CTHD> dsCTHD = new List<DTO_CTHD> ();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CHITIETHOADON WHERE MaHD = " + ma);
            foreach (DataRow item in data.Rows) 
            {
                DTO_CTHD tt = new DTO_CTHD(item);
                dsCTHD.Add(tt);
            }
            return dsCTHD;
        }

        public void ThemCTHD(int idHD, int idTU, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("THEMCTHD @maHD , @maTU , @soluong", new object[] { idHD, idTU, soluong });
        }
    }
}
