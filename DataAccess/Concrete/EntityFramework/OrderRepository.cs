using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderRepository : EfEntityRepositoryBase<Order, ProjectDbContext>, IOrderRepository
    {
        public OrderRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<List<OrderDto>> GetOrderDto()
        {
            var list=await(from ord in Context.Orders
                           join prd in Context.Products on ord.ProductId equals prd.ProductId
                           join cst in Context.Customers on ord.CustomerId equals cst.customerId
                           select new OrderDto()
                           {
                               orderId=ord.OrderId,
                               productName=prd.ProductName,
                               customerName=cst.CustomerName,
                               piece=ord.Piece,
                               isDeleted=ord.isDeleted

                           }).ToListAsync();

            return list;
                           
        }
    }
}
