﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;

namespace DAL
{
    public interface IDAL
    {
        string getLine(string username);
        string getPassword(int line);
    }
}
