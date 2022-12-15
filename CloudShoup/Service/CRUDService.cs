using CloudShoup.Models;
using CloudShoup.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShoup.Service
{
    public class CRUDService : IOrderService
    {
        public DbSet<Order> Orders { get; set; }
        private ShoupDbContext context;

        public CRUDService(ShoupDbContext context)
        {
            this.context = context;
        }
        public List<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }
        public Order GetOrderById(int id)
        {
            return context.Orders.FirstOrDefault(order => order.Id == id);
        }
        public Order AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
        public void RemoveOrderById(int id)
        {
            context.Orders.Remove(GetOrderById(id));
            context.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            using(var db = new ShoupDbContext())
            {
                db.Orders.Update(order);
                context.SaveChanges();
            }
        }
    }
}
