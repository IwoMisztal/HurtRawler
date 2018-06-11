using HurtRawler.Models;
using HurtRawler.Services;
using HurtRawler.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;

using System.IO;

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
            CheckAvailability checker = new CheckAvailability(_itemData);
            _itemData.Save();
            var allItems = _itemData.GetAll();
            model.List = allItems;
            var unAvailableItems = allItems.Where(l => l.IsAvailable == false);
            var availableItems = allItems.Where(l => l.IsAvailable == true);
            
            model.AvailableItems = availableItems;
            model.UnAvailableItems = unAvailableItems;
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

            return RedirectToAction(nameof(List));
        }

        public IActionResult ClearDb()
        {
            foreach (Item i in _itemData.GetAll())
            {
                _itemData.Remove(i.Id);
            }
            _itemData.Save();
            return RedirectToAction(nameof(List));
        }

        public IActionResult RemoveItem(Item item)
        {
            int itemId = item.Id;
            _itemData.Remove(itemId);
            _itemData.Save();
            return RedirectToAction(nameof(List));
        }

        public IActionResult UploadFromCsv()
        {
            ReadCsv csvReader = new ReadCsv();
            var allLinks = csvReader.result;
            LoadCsv csvLoader = new LoadCsv(allLinks, _itemData);
            return RedirectToAction(nameof(List));
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //   var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot", 
        //                file.GetFilename());
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return RedirectToAction("List");

        //}

        //public async Task<IActionResult> Download(string filename)
        //{
        //    if (filename == null)
        //        return Content("filename not present");

        //    var path = Path.Combine(
        //                   Directory.GetCurrentDirectory(),
        //                   "wwwroot", filename);

        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, GetContentType(path), Path.GetFileName(path));
        //}
    }
}