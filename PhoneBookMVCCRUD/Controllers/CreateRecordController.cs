using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMVCCRUD.Domain;
using PhoneBookMVCCRUD.Domain.Entities;

namespace PhoneBookMVCCRUD.Controllers
{
    public class CreateRecordController : Controller
    {
        private readonly DataManager _dataManager;

        public CreateRecordController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhoneBookRecord model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PhoneBookRecords.SavePhoneBookRecord(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
