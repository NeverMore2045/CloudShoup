using CloudShoup.Models.Entity;

namespace CloudShoup.Service
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order AddOrder(Order order);
        void RemoveOrderById(int id);
        void UpdateOrder(Order order);
    }
}
