﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Inlamning_2.Services;

namespace MVC_Inlamning_2.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileManager _profileManager;

        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        [HttpGet("{id}")]
        [Route("profile/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var profile = await _profileManager.ReadAsync(id);
            return View(profile);
        }
    }
}
