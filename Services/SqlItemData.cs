using System.Collections.Generic;
using System.Linq;
using HurtRawler.Models;

namespace HurtRawler.Services
{
    public class SqlItemData : IItemData
    {
        private HurtRawlerDbContext _context;
        public SqlItemData(HurtRawlerDbContext context) 
        {
            _context = context;
        }
        public Item Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            _context.Items.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Item> GetAll()
        {
            return _context.Items.OrderBy(i => i.Id);
        }
    }
}