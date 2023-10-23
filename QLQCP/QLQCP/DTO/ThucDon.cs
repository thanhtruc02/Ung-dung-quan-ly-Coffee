using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCP.DTO
{
    public class ThucDon
    {
        public ThucDon(string tenTU, int count, float gia, float thanhTien = 0)
        {
            this.TenTU = tenTU;
            this.Count = count;
            this.Gia = gia;
            this.ThanhTien = thanhTien;
        }

        public ThucDon(DataRow row)
        {
            this.TenTU = row["TenTU"].ToString();
            this.Count = (int)row["Soluong"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["Tongtien"].ToString());
        }
        private float thanhTien;

        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value;}
        }

        private float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private int count;

        public int Count 
        {
            get { return count; } 
            set { count = value; }
        }

        private string tenTU;

        public string TenTU
        {
            get { return tenTU; } 
            set { tenTU = value; }
        }
    }
}
