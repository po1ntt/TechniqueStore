using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;


namespace TechniqueStore.Service
{
    class BasketService
    {
        public static ObservableCollection<BasketUser> GetBasketCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<BasketUser>();
            var items = context.BasketUser.ToList().Where(p => p.Users.Login == Base.LoginUser);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddBasketItem(ItemCategory item)
        {
            string result = "Ошибка";

            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var itemcat = context.ItemCategory.FirstOrDefault(p => p.id_itemCategory == item.id_itemCategory);
                var user = context.Users.FirstOrDefault(p => p.Login == Base.LoginUser);
                var basket = context.BasketUser.FirstOrDefault(p => p.ItemCategory.nameItem == item.nameItem && p.id_user == user.id_user);
                if (basket != null)
                {
                    basket.count++;
                    context.SaveChanges();
                    result = "Товар добавлен в корзину +1";
                    
                }
                else
                {
                    context.BasketUser.Add(new BasketUser
                    {
                        id_basket = context.BasketUser.Count() + 1,
                        id_itemcategory = item.id_itemCategory,
                        id_user = user.id_user,
                        count = 1
                        

                    });
                    result = "Товар добавлен в корзину";
                    context.SaveChanges();
                }
            }
            return result;
        }
        public static string DeleteBasket(BasketUser basketitem)
        {
            string result = "Ошибка";
            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var basketodelete = context.BasketUser.FirstOrDefault(p => p.id_basket == basketitem.id_basket);
                if (basketodelete != null)
                {
                    context.BasketUser.Remove(basketodelete);
                    context.SaveChanges();
                    result = "Все отлично";
                }
                else
                {
                    result = "Передан null";
                }
            }
            return result;
        }
        public static string EditBasket(BasketUser basketUser, string action)
        {
            string result = "Ошибка";
            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var basket = context.BasketUser.FirstOrDefault(p => p.id_basket == basketUser.id_basket);
                if (basket != null)
                {
                    if(action == "plus")
                    {
                        basket.count++;
                        context.SaveChanges();

                    }
                    else
                    {
                        basket.count--;
                        context.SaveChanges();

                        if (basket.count == 0)
                        {
                            DeleteBasket(basket);
                            context.SaveChanges();

                        }
                    }
                    result = "Кол-во обновлено";
                }
                else
                {
                    result = "Null";
                }
            }
            return result;
        }
        public static string DeleteBasketAll()
        {
            string result = "Ошибка";
            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var basketlist = context.BasketUser.ToList();
                foreach(var item in basketlist)
                {
                    DeleteBasket(item);
                }
            }
            return result;
        }
    }
}
