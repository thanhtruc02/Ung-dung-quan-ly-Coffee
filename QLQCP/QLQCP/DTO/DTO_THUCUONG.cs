using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_THUCUONG
    {
        public DTO_THUCUONG(int ma, string ten, int maloaiTU, float gia)
        {
            this.MA = ma;
            this.Ten = ten;
            this.MaLoaiTU = maloaiTU;
            this.Gia = gia;
        }

        public DTO_THUCUONG(DataRow row)
        {
            this.MA = (int)row["MaTU"] ;
            this.Ten = row["TenTU"].ToString();
            this.MaLoaiTU = (int)row["MaLoaiTU"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }

        private float gia;

        public float Gia
        { 
            get { return gia; } 
            set { gia = value; }
        }

        private int maloaiTU;

        public int MaLoaiTU
        {
            get { return maloaiTU; } 
            set { maloaiTU = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private int mA;

        public int MA
        {
            get { return mA; }
            set { mA = value; }
        }
    }
}
