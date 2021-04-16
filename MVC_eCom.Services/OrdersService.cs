using MVC_eCom.Database;
using MVC_eCom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_eCom.Services
{
    public class OrdersService
    {
        #region Singleton

        public static OrdersService Instance
        {
            get
            {
                if (instance == null) instance = new OrdersService();
                return instance;
            }

        }
        private static OrdersService instance { get; set; }



        private OrdersService()
        {
            
        }


        #endregion

        public List<Order> SearchOrders(string userID, string status, int pageNo, int pageSize)
        {
            using (var context = new CBContext())
            {
                var orders = context.Orders.ToList();
                

                if (!string.IsNullOrEmpty(userID))
                {
                    orders = orders.Where(x => x.UserID.ToLower().Contains(userID.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(status))
                {
                    orders = orders.Where(x => x.Status.ToLower().Contains(userID.ToLower())).ToList();
                }
                return orders.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            }
        }

        public int SearchOrdersCount(string userID,string status)
        {
            using (var context = new CBContext())
            {
                var orders = context.Orders.ToList();


                if (!string.IsNullOrEmpty(userID))
                {
                    orders = orders.Where(x => x.UserID.ToLower().Contains(userID.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(status))
                {
                    orders = orders.Where(x => x.Status.ToLower().Contains(userID.ToLower())).ToList();
                }
                return orders.Count;

            }
        }
    }
}
