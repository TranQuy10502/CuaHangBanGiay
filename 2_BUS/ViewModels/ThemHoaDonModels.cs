﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ThemHoaDonModels
    {
     

        public Guid? IdKh { get; set; }

        public Guid? IdNv { get; set; }

        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        public DateTime? NgayShip { get; set; }

        public DateTime? NgayNhan { get; set; }

        public int? TinhTrang { get; set; }

        public decimal Thue { get; set; }
    }
}
