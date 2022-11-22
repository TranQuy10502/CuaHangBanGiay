﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class GioHangViewModel
    {
        public Guid IdCTSP { get; set; }
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }
    }
}
