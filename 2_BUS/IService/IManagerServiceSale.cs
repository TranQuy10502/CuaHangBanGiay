﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IManagerServiceSale
    {
        bool add(Voucher sale);
        bool remove(Voucher id);
        List<Voucher> getAll();
        bool update(Voucher sale);
    }
}
