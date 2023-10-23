using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_HOADON
    {
        public DTO_HOADON(int ma, DateTime? dateCheckIn, DateTime? dateCheckOut, int trangThai, int discount = 0)
        {
            this.Ma = ma;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.TrangThai = trangThai;
            this.Discount = discount;
        }

        public DTO_HOADON(DataRow row)
        {
            this.Ma = (int)row["MaHD"];
            this.DateCheckIn = (DateTime?)row["CheckIn"];

            var dateCheckOutTemp = row["CheckOut"];
            if (dateCheckOutTemp.ToString() != "" )
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.TrangThai = (int)row["TrangThai"];

            if (row["Discount"].ToString() != "")
                this.Discount = (int)row["Discount"];
        }
        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int trangThai;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        private int ma;

        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
    }
}
