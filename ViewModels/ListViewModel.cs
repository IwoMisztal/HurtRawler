using System.Collections.Generic;
using HurtRawler.Models;

namespace HurtRawler.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Item> List { get; set; }
    }
}