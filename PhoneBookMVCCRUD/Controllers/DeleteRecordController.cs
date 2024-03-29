﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMVCCRUD.Domain;

namespace PhoneBookMVCCRUD.Controllers
{
    public class DeleteRecordController : Controller
    {
        private readonly DataManager _dataManager;

        public DeleteRecordController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpDelete]
        [HttpPatch]
        [HttpPost]
        [HttpGet]
        public IActionResult Index(int id)
        {
            _dataManager.PhoneBookRecords.DeletePhoneBookRecord(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
