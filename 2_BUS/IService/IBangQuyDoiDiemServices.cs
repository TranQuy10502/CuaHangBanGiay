﻿using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IBangQuyDoiDiemServices
    {
        bool add(BangQuyDoiDiemViewModels vi);
        bool remove(Guid vi);
        public List<BangQuyDoiDiemViewModels> GetDiemQuyDoi();
        bool update(BangQuyDoiDiemViewModels vi);
        public List<BangQuyDoiDiemViewModels> Get();
        List<BangQuyDoiDiemViewModels> GetDiem();
    }
}
