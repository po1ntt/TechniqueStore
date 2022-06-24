using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class CardsService
    {
        public static ObservableCollection<Cards> GetCardCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<Cards>();
            var items = context.Cards.ToList().Where(p => p.Users.Login == Base.LoginUser);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddCard(string numbercard)
        {
            string result = "Ошибка";

            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var user = context.Users.FirstOrDefault(p => p.Login == Base.LoginUser);
                var card = context.Cards.FirstOrDefault(p => p.NumberCard == numbercard && p.Users.Login == Base.LoginUser);
                if (card != null)
                {

                    result = "Адрус уже существует";
                }
                else
                {
                    context.Cards.Add(new Cards
                    {
                        id_card = context.Adress.Count() + 1,
                        NumberCard = numbercard,
                        id_user = user.id_user

                    });
                    result = "Новый адрес успешно добавлен";
                    context.SaveChanges();
                }
            }
            return result;
        }
    }
}
