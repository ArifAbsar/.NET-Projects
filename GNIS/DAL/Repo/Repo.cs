﻿using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Repo
    {
        protected MeetingContext db;
        internal Repo()
        {
            db = new MeetingContext();
        }
    }
}
