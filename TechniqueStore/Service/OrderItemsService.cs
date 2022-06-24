using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class OrderItemsService
    {
        public static ObservableCollection<OrderItems> GetOrderCol(Order order)
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<OrderItems>();
            var items = context.OrderItems.ToList().Where(p => p.Order.id_order == order.id_order);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddOrderItems(BasketUser basket)
        {
            string result = "Ошибка";

            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var user = context.Users.FirstOrDefault(p => p.Login == Base.LoginUser);
                var orders = context.Order.ToList();
                var OrderItems = context.OrderItems.ToList();

                context.OrderItems.Add(new OrderItems
                {
                    id_order = orders.Count,
                    id_orderItems = OrderItems.Count + 1,
                    id_item = basket.id_itemcategory

                });
                result = "Новый адрес успешно добавлен";
                context.SaveChanges();

            }
            return result;
        }
    }
}
