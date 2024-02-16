using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMVCCRUD.Domain;
using PhoneBookMVCCRUD.Domain.Entities;

namespace PhoneBookMVCCRUD.Controllers
{
    public class EditRecordController : Controller
    {
        private readonly DataManager _dataManager;

        public EditRecordController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Edit(int id)
        {
            PhoneBookRecord phoneBookRecord = _dataManager.PhoneBookRecords.GetPhoneBookRecordById(id);
            return View(phoneBookRecord);
        }

        [HttpPost]
        public IActionResult Edit(PhoneBookRecord model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PhoneBookRecords.EditPhoneBookRecord(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
