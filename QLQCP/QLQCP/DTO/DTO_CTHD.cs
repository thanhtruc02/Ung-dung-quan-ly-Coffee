using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_CTHD
    {
        public DTO_CTHD(int ma, int maHD, int maTU, int count)
        {
            this.Ma = ma;
            this.MaHD = maHD;
            this.maTU = maTU;
            this.count = count;
        }

        public DTO_CTHD (DataRow row)
        {
            this.Ma = (int)row["MaCTHD"];
            this.MaHD = (int)row["MaHD"]; ;
            this.maTU = (int)row["MaTU"]; ;
            this.count = (int)row["Soluong"]; ;
        }

        private int maTU;
        private int maHD;
        private int ma;
        private int count;

        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        public int Ma
        {
            get { return maHD; }
            set { maHD = value; }
        }

        public int MaTU
        {
            get { return maTU; }
            set { maTU = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

    }
}
