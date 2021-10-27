using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookManager.Domain.Model;
using PhoneBookManager.Domain.Services;
using PhoneBookManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookManager.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly ILogger<PhoneBookController> _logger;
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(ILogger<PhoneBookController> logger, IPhoneBookService phoneBookService)
        {
            _logger = logger;
            _phoneBookService = phoneBookService;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var entries = _phoneBookService.GetEntries();
            return Json(new { recordsFiltered = entries.Count(), recordsTotal = entries.Count(), data = entries });
        }


        [HttpPost]
        public IActionResult CreatePhoneBookEntry(EntryViewModel model)
        {
            try
            {
                var entry = new Entry();
                entry.PhoneNumber = model.PhoneNumber;
                entry.PhoneBookId = 1;//default phone book
                entry.Name = model.Name;
                int entryId = _phoneBookService.CreatePhoneBookEntry(entry);
                if (entryId > 0)
                    return Json(new { success = true, data = entryId });
                else
                    return Json(new { success = false, data = "Error, name or phone number already added!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult DeletePhoneBookEntry(EntryViewModel model)
        {
            try
            {
                var result = _phoneBookService.DeletePhoneBookEntry(model.Id);
                return Json(new { success = result, data = string.Empty });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message });
            }
        }
    }
}
