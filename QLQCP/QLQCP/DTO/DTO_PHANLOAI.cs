using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_PHANLOAI
    {
        public DTO_PHANLOAI(int mA, string ten) 
        {
            this.MA = mA;
            this.Ten = ten;
        }

        public DTO_PHANLOAI( DataRow row)
        {
            this.MA = (int)row["MaLoaiTU"];
            this.Ten = row["TenLoaiTU"].ToString();
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
