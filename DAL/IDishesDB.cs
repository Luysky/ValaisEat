﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDishesDB
    {
        List<Dish> GetDishes(int id);
        Dish GetDish(int id);
    }
}
