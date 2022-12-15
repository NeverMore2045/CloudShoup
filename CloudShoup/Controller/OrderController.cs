using CloudShoup.Models.Entity;
using CloudShoup.Service;
using System.Collections.Concurrent;

namespace CloudShoup.Controller
{
    public class OrderController
    {
        private CRUDService crudservice;
        public OrderController(CRUDService crudservice)
        {
            this.crudservice = crudservice;
        }
        public async Task GetOrdersList(HttpContext context)
        {
            List<Order> orders = crudservice.GetAllOrders();
            await context.Response.WriteAsJsonAsync(orders);
        }
        public async void AddOrder(HttpContext context)
        {
            Order neworder = await context.Request.ReadFromJsonAsync<Order>();
            neworder = crudservice.AddOrder(neworder);
            await context.Response.WriteAsJsonAsync(neworder);
        }
        public async void RemoveOrder(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["id"]);
            crudservice.RemoveOrderById(id);
            await context.Response.WriteAsync("Order deleted");
        }
        public async void UpdateOrder(HttpContext context)
        {
            Order neworder = await context.Request.ReadFromJsonAsync<Order>();
            crudservice.UpdateOrder(neworder);
            await context.Response.WriteAsync("Order updated");
        }
    }
}
