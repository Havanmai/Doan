﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class HomeDao
    {
        DoanDbContext db = null;
        public HomeDao()
        {
            db = new DoanDbContext();

        }
         
    }
}
