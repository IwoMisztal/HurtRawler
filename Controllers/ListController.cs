using HurtRawler.Models;
using HurtRawler.Services;
using HurtRawler.ViewModels;
using Microsoft.AspNetCore.Mvc;

using System;

namespace HurtRawler.Controllers
{
    public class ListController : Controller
    {
        private IItemData _itemData;

        public ListController(IItemData itemData) 
        {
            _itemData = itemData;
        }
        public IActionResult List() 
        {
            var model = new ListViewModel();
            var toCheck = _itemData.GetAll();
            CheckAvailability checker = new CheckAvailability(_itemData);
            model.List = _itemData.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            var newItem = new Item();
            newItem.Link = item.Link;

            newItem = _itemData.Add(newItem);

            return View();
        }

        public IActionResult ClearDb()
        {
            foreach (Item i in _itemData.GetAll())
            {
                _itemData.Remove(i);
            }
            _itemData.Save();
            return RedirectToAction(nameof(List));
        }
    }
}