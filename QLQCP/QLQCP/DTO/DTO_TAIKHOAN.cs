using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class DTO_TAIKHOAN
    {
        public DTO_TAIKHOAN(string tenUser, string tenTK, int loaiTK, string matkhau = null)
        { 
            this.TenUser = tenUser;
            this.TenTK = tenTK;
            this.Matkhau = matkhau;
            this.LoaiTK = loaiTK;
        }

        public DTO_TAIKHOAN (DataRow row)
        {
            this.TenUser = row["TenUser"].ToString();
            this.TenTK = row["TenTK"].ToString();
            this.Matkhau = row["matkhau"].ToString();
            this.LoaiTK = (int)row["loaiTK"];
        }


        private int loaiTK;

        public int LoaiTK
        {
            get { return loaiTK; }
            set { loaiTK = value; }
        }

        private string matkhau;

        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        private string tenTK;

        public string TenTK
        {
            get { return tenTK; }
            set { tenTK = value; }
        }

        private string tenUser;

        public string TenUser
        {
            get { return tenUser; }
            set { tenUser = value; }
        }
    }
}
