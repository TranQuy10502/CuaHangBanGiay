﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IBangQuyDoiDiem
    {
        bool add(QuyDoiDiem diem);
        bool remove(Guid id);
        List<QuyDoiDiem> getAll();

        bool update(QuyDoiDiem diem);
    }
}
