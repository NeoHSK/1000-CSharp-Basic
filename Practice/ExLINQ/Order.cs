﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExLINQ
{
    public class Order
    {
        public long ID { get; set; }
        public string UserID { get; set; }
        public List<OrderItem> OrderItems{ get; set;}
    }
}
