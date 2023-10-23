using QLQCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DAO
{
    public class DAO_HOADON
    {
        public static DAO_HOADON instance;

        public static DAO_HOADON Instance 
        {
            get { if (instance == null) instance = new DAO_HOADON(); return DAO_HOADON.instance; }
            private set { DAO_HOADON.instance = value; }
        }

        private DAO_HOADON() { }

        /// <summary>
        /// Thành công: Ma HOADON
        /// Thất bại: -1
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public int DSHOADON_MABAN (int ma)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HOADON WHERE MaB = " + ma + " AND trangThai = 0");

            if (data.Rows.Count > 0)
            {
                DTO_HOADON hd = new DTO_HOADON(data.Rows[0]);
                return hd.Ma;
            }


            return -1;
        }

        public void CheckOut (int id, int discount, float TongTien)
        {
            string query = "UPDATE dbo.HOADON SET CheckOut = GETDATE(), Trangthai = 1 , " + " Discount = " + discount + " , TongTien = " + TongTien + " WHERE MaHD = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void ThemHoaDon(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("THEMHOADON @maB", new object[] {id});
        }
        public DataTable GetHoaDon_Ngay(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            return DataProvider.Instance.ExecuteQuery(" exec GetListBillByDate @checkIn , @checkOut ", new object[] { dateCheckIn, dateCheckOut });
        }
        
        public DataTable GetHoaDon_Ngay_Trang (DateTime dateCheckIn, DateTime dateCheckOut, int soTrang)
        {
            return DataProvider.Instance.ExecuteQuery(" exec GetListHD_Ngay_Trang @checkIn , @checkOut , @Trang ", new object[] { dateCheckIn, dateCheckOut, soTrang });
        }

        public int GetSoHoaDon_Ngay( DateTime dateCheckIn,  DateTime dateCheckOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec GetSoTrang_Ngay @checkIn , @checkOut ", new object[] { dateCheckIn, dateCheckOut });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(MaHD) FROM dbo.HOADON");
            }
            catch
            {
                return 1;
            }
           
        }
        public void XoaHD_MaB(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.HOADON WHERE MaB = " + id);
        }
    }
}
