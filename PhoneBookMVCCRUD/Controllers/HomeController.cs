﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMVCCRUD.Domain;
using PhoneBookMVCCRUD.Domain.Entities;
using System.Windows.Input;
using System.Drawing;

namespace PhoneBookMVCCRUD.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(_dataManager == null)
            {
                return RedirectToAction("NoData", "NotFound");
            }
            else
            {
                return View(_dataManager.PhoneBookRecords.GetPhoneBookRecords());
            }
        }
    }
}
