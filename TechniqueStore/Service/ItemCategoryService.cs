using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class ItemCategoryService
    {
        public static ObservableCollection<ItemCategory> GetItemsCategoryCol(CategoryTech category)
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<ItemCategory>();
            var items = context.CategoryTech.ToList().Where(p => p.id_categorytech == category.id_categorytech);
            foreach (var item in items)
            {
                foreach (var itemOrderItemsCol in item.ItemCategory)
                {
                    Collection.Add(itemOrderItemsCol);

                }
            }
            return Collection;
        }
    }
}
