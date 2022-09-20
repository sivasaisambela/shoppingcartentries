using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();

        ICollection<Item> GetItems(Func<Item, bool> filter, bool includeUsers);

        ICollection<User> GetUsers(int itemld);

        User AddUser(User user);

    }
}
