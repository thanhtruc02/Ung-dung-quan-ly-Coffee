using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_BAN
    {
        public DTO_BAN(int maB, string tenB, string trangthai)
        {
            this.MaB = maB;
            this.TenB = tenB;
            this.Trangthai = trangthai;
        }

        public DTO_BAN(DataRow row)
        {
            this.MaB = (int)row["MaB"];
            this.TenB = row["TenB"].ToString();
            this.Trangthai = row["Trangthai"].ToString();
        }
        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private string tenB;

        public string TenB
        {
            get { return tenB; }
            set { tenB = value; }
        }

        private int maB;

        public int MaB
        {
            get { return maB; }
            set { maB = value; }
        }
    }
}
