using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<Item> dbSet;
        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Item>();
        }
        public User AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public ICollection<Item> GetItems()
        {
            IQueryable<Item> query = dbSet;

            return query.ToList();
            

        }
        public ICollection<Item> GetItems(Func<Item, bool> filter, bool includeUsers)
        {
            IQueryable<Item> query = dbSet;
            //query = (IQueryable<Item>)query.Where(filter);

            return query.Where(filter).ToList();
        }

        public ICollection<User> GetUsers(int itemld)
        {
           return  _db.Users.Where(x => x.ItemId == itemld).ToList(); ;
        }
    }
}
