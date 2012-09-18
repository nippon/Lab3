﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Entities;

namespace SportsStore.Model.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}