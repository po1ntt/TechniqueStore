using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;

namespace TechniqueStore.Service
{
    class CategoryService
    {
        public static ObservableCollection<CategoryTech> GetСategoryCol()
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var Collection = new ObservableCollection<CategoryTech>();
            var items = context.CategoryTech.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}
