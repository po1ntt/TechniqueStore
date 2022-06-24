
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class AdresService
    {
        public static ObservableCollection<Adress> GetAdresCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<Adress>();
            var items = context.Adress.ToList().Where(p=> p.Users.Login == Base.LoginUser);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddAdress(string adres)
        {
            string result = "Ошибка";

            using (TechniqueStoreEntities context = new TechniqueStoreEntities())
            {
                var user = context.Users.FirstOrDefault(p => p.Login == Base.LoginUser);
                var adress = context.Adress.FirstOrDefault(p => p.adress1 == adres && p.Users.Login == Base.LoginUser);
                if (adress != null)
                {

                    result = "Адрус уже существует";
                }
                else
                {
                    context.Adress.Add(new Adress
                    {
                        id_adress = context.Adress.Count() + 1,
                        adress1 = adres,
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
