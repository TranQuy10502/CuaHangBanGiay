﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SaleChiTietUpdateView
    {
        public Guid IdSale { get; set; }
        public Guid IdHoaDon { get; set; }
        public decimal? GiamTheoPhanTram { get; set; }
        public decimal? GiamTheoKhoangTien { get; set; }
    }
}
