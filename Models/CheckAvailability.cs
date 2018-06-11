using HurtRawler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HurtRawler.Models
{
    public class CheckAvailability
    {
        private static WebClient client = new WebClient();
        string str;
        private IQueryable<Item> _itemData;
        private ReadSite _siteReader = new ReadSite();
        public CheckAvailability(IItemData itemData)
        {
            _itemData = itemData.GetAll();
            foreach (var i in _itemData)
            {
                    string toCheck = _siteReader.Read(i.Link);
                    if (toCheck == null)
                    {
                        throw new Exception("Link is Empty");
                    }
                    else if (toCheck.IndexOf("title=\"Produkt dostępny") != -1)
                    {
                        i.IsAvailable = true;
                    }
                    else if (toCheck.IndexOf("batterylow") != -1)
                    {
                        i.IsAvailable = false;
                    }
             }
            itemData.Save();
        }
    }
}
