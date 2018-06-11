using HurtRawler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HurtRawler.Models
{
    public class LoadCsv
    {
        public LoadCsv(CsvRecord[] itemsToAdd, IItemData itemData)
        {
          foreach (var i in itemsToAdd)
            {
                Item newItem = new Item();
                newItem.Link = i.Link;
                itemData.Add(newItem);
            }
            itemData.Save();
        }
    }
}
