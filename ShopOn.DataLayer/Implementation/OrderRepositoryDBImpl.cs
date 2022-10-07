using Shopon.DataLayer.Contracts;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using ShopOn.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopon.DataLayer.Implementation
{
    public class OrderRepositoryDBImpl : IOrderRepository
    {
        private readonly string connectionString = null;
        public OrderRepositoryDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            this.connectionString = connectionUtil.GetConnectionString();
                }
        public Order AddOrder(Order order)
        {
            // 1. insert to order 
            // 2. get the new orderid and insert all the orderitem with this new order id
            // 3. if any exception ocures then cancal insert to order and orderitem(transaction)
            // 4. return the order with order id
            //string sqlSt = $"INSERT INTO dbo.orderd (OrderStatus , OrderDate , CustomerId , TotalAmount)" +
            //               $" VALUES (@orderStatus , @orderDate , @customerId , @totalAmount )";
            string sqlSt = "sp_InsertOrder";
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // starting transaction
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection, transaction))
                    {
                        // comand type stored procedure 
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        //@orderDate
                        SqlParameter orderDate = command.Parameters.Add("@orderDate", System.Data.SqlDbType.Date);
                        orderDate.Value = order.OrderDate;
                        orderDate.Direction = System.Data.ParameterDirection.Input;
                        //@customerId
                        SqlParameter customerId = command.Parameters.Add("@customerId", System.Data.SqlDbType.Int);
                        customerId.Value = order.CustomerId == 0? null : order.CustomerId;
                        customerId.Direction = System.Data.ParameterDirection.Input;
                        //@
                        SqlParameter aspNetCustomerId = command.Parameters.Add("@aspNetCustomerId", System.Data.SqlDbType.NVarChar, 450);
                        aspNetCustomerId.Value = order.AspCustomerId;
                        aspNetCustomerId.Direction = System.Data.ParameterDirection.Input;
                        //@TotalAmount
                        SqlParameter totalAmount = command.Parameters.Add("@totalAmount", System.Data.SqlDbType.Float);
                        totalAmount.Value = order.OrderTotal;
                        totalAmount.Direction = System.Data.ParameterDirection.Input;
                        //@orderId
                        SqlParameter orderId = command.Parameters.Add("@orderId", System.Data.SqlDbType.Int);
                        orderId.Direction = System.Data.ParameterDirection.Output;

                        var racNo = command.ExecuteNonQuery();
                        if (racNo > 0)
                        {
                            var newOrderId = Convert.ToInt32(command.Parameters["@orderId"].Value);
                            order.OrderId = newOrderId;


                           var isOrderItemInserted = InsertOrderItem(connection, transaction, newOrderId, order.GetOrderItem());
                            if (isOrderItemInserted)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }

                        }

                    }
                }
                return order; 
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrderByCustomerId(int CustomerId)
        {
            throw new NotImplementedException();
        }
        private bool InsertOrderItem(SqlConnection connection, SqlTransaction transaction, int newOrderId, IEnumerable<OrderItem> orderItems)
        {
            bool isInserted = false;
            string sqlSt = "sp_InsertOrderItem";
            try
            {
                foreach (var orderItem in orderItems)
                {
                    using (SqlCommand command = new SqlCommand(sqlSt, connection, transaction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        //@pid
                        SqlParameter pid = command.Parameters.Add("@pid", System.Data.SqlDbType.Int);
                        pid.Value = orderItem.PId;
                        pid.Direction = System.Data.ParameterDirection.Input;
                        //@qty
                        SqlParameter qty = command.Parameters.Add("@qty", System.Data.SqlDbType.Int);
                        qty.Value = orderItem.Qty;
                        qty.Direction = System.Data.ParameterDirection.Input;
                        //@orderId
                        SqlParameter orderId = command.Parameters.Add("@orderId", System.Data.SqlDbType.Int);
                        orderId.Value = newOrderId;
                        orderId.Direction = System.Data.ParameterDirection.Input;

                        var noRac = command.ExecuteNonQuery();

                        if (noRac > 0)
                        {
                            isInserted = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return isInserted;
        }

    }
}
