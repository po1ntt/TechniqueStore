using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechniqueStore.Model;
using TechniqueStore.Service;

namespace TechniqueStore.Service
{
    class UserService
    {
        public static bool LoginUser(string Login, string Passoword)
        {
            TechniqueStoreEntities context = new TechniqueStoreEntities();
            var user = context.Users.FirstOrDefault(p => p.Login == Login && p.Password == Passoword);
            return (user != null);
        } 
    }
}
