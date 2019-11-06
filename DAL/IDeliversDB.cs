﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IDeliversDB
    {
        List<Deliver> GetDelivers();
        Deliver GetDeliver(int id);
    }
}
