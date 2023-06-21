﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IChatLieuRepository
    {
        bool add(ChatLieu producter);
        bool remove(ChatLieu producter);
        List<ChatLieu> getAll();
        bool update(ChatLieu producter);
    }
}
