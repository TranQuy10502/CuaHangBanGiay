﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IKhuyenMaiRepository
    {
        bool add(Voucher sale);
        bool remove(Voucher id);
        List<Voucher> getAll();

        bool update(Voucher sale);
    }
}
