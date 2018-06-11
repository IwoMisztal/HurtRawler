using System.Collections.Generic;
using System.Linq;
using HurtRawler.Models;

namespace HurtRawler.Services
{
    public interface IItemData
    {
        
         IQueryable<Item> GetAll();
         Item Add(Item item);
        void Remove(int id);
        void Save();
    }
}