using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class OrderService
    {
        public static ObservableCollection<Order> GetOrderCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<Order>();
            var items = context.Order.ToList().Where(p => p.Users.Login == Base.LoginUser);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static ObservableCollection<OrderItems> GetOrderItemsCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<OrderItems>();
            var items = context.Order.ToList().Where(p => p.Users.Login == Base.LoginUser);
            foreach (var item in items)
            {
                foreach(var itemOrderItemsCol in item.OrderItems)
                {
                    Collection.Add(itemOrderItemsCol);

                }
            }
            return Collection;
        }
        public static string AddOrder(int price, Adress adress, Cards cards)
        {
            string result = "Ошибка";

            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var user = context.Users.FirstOrDefault(p => p.Login == Base.LoginUser);
                var orders = context.Order.ToList();
               
                    context.Order.Add(new Order
                    {
                       id_order = orders.Count + 1,
                       id_status = 1,
                       id_user = user.id_user,
                       numberorder = new Random().Next(0, int.MaxValue),
                       DateOrder = DateTime.Now,
                       price = price,
                       id_adresDostavki = adress.id_adress,
                       id_CardPurchapse = cards.id_card

                    });
                context.SaveChanges();

                var basketitems = BasketService.GetBasketCol();
                foreach(var items in basketitems)
                {
                    var OrderItems = context.OrderItems.ToList();

                    context.OrderItems.Add(new OrderItems
                    {
                        id_order = orders.Count,
                        id_orderItems = OrderItems.Count + 1,
                        id_item = items.id_itemcategory,
                        count = items.count
                        

                    });
                    context.SaveChanges();

                }

                result = "Новый адрес успешно добавлен";
                
            }
            return result;
        }
    }
}
