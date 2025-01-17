﻿#define USE_WHERE

using System;
using System.Collections.Generic;
using System.Linq;

namespace ExLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = getOrders();

            Order peterFirstOrder;


#if USE_WHERE
            peterFirstOrder = orders.Where(o=> o.UserID == "Peter").FirstOrDefault();
#else
            peterFirstOrder = orders.FirstOrDefault(o => o.UserID == "Peter");
#endif
            Console.WriteLine($"Peter is first order: {peterFirstOrder.ID}");

            List<Order> petersOrders = orders.Where(o => o.UserID == "Peter").ToList();
            
            if(petersOrders.Any())
            {
                Console.WriteLine($"Peter has {petersOrders.Count} orders!");
            }

            List<OrderItem> petersOrderItems = petersOrders.SelectMany(o => o.OrderItems).ToList();

            printOrderItems(petersOrderItems);

            List<OrderItem> petersOrderItemsorderedByIdDesc = petersOrderItems.OrderByDescending(o => o.ID).ToList();

            printOrderItems(petersOrderItemsorderedByIdDesc);

            List<OrderItem> orderdByPrice = petersOrderItems.OrderBy(o => o.Price).ToList();

            printOrderItems(orderdByPrice);

            List<string> productList = petersOrderItems.Select(oi => oi.Name).ToList();

            Console.WriteLine($"Peter bought: {string.Join(", ", productList)}");

            List<OrderItem> allOrderItems = orders.SelectMany(o => o.OrderItems).ToList();

            List<List<OrderItem>> Listitems = orders.Select(o => o.OrderItems).ToList();

           
            decimal totalPrice = allOrderItems.Sum(oi => oi.Price * oi.Quantity);

            Console.WriteLine($"Total Price of all order items: {totalPrice}");
        }

        #region HELPLER_METHODS
        private static List<Order> getOrders()
        {
            List<Order> orders = new List<Order>
        {
            new Order
            {
                ID = 1,
                UserID = "Peter",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ID = 1,
                        Name = "GTX1080",
                        Price = 809.99m,
                        Quantity = 1
                    },
                    new OrderItem
                    {
                        ID = 2,
                        Name = "Mechanical Keyboard",
                        Price = 99.99m,
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        ID = 3,
                        Name = "Standing Desk",
                        Price = 607.89m,
                        Quantity = 1
                    }
                }
            },
            new Order
            {
                ID = 2,
                UserID = "Peter",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ID = 4,
                        Name = "Pen",
                        Price = 1.99m,
                        Quantity = 10
                    },
                    new OrderItem
                    {
                        ID = 5,
                        Name = "NoteBook",
                        Price = 10.99m,
                        Quantity = 5
                    }
                }
            },
            new Order
            {
                ID = 3,
                UserID = "Jane",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ID = 6,
                        Name = "GTX1080",
                        Price = 809.99m,
                        Quantity = 2
                    }
                }
            },
            new Order
            {
                ID = 4,
                UserID = "John",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ID = 7,
                        Name = "GTX1080",
                        Price = 809.99m,
                        Quantity = 1
                    },
                    new OrderItem
                    {
                        ID = 8,
                        Name = "Pen",
                        Price = 1.99m,
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        ID = 9,
                        Name = "Hairspray",
                        Price = 15.99m,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        ID = 10,
                        Name = "Mechanical Keyboard",
                        Price = 99.99m,
                        Quantity = 1
                    }
                }
            }
        };

            return orders;
        }
        private static void printOrderItems(List<OrderItem> orderItems)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("{0,-10} {1,-25} {2, -10} {3, -10}", "ID", "Name", "Price", "Quantity");

            foreach (OrderItem oi in orderItems)
            {
                Console.WriteLine("{0,-10} {1,-25} {2, -10} {3, -10}", oi.ID, oi.Name, oi.Price, oi.Quantity);
            }
            Console.WriteLine("---------------------------------");
        }
        #endregion
    }
}
