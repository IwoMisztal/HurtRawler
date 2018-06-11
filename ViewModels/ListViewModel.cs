using System.Collections.Generic;
using System.Linq;
using HurtRawler.Models;

namespace HurtRawler.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Item> List { get; set; }
        public IQueryable<Item> AvailableItems { get; set; }
        public IQueryable<Item> UnAvailableItems { get; set; }
    }
}