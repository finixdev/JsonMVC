using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonMVC.Models;
using JsonMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JsonMVC.Controllers
{
    public class JsonController : Controller
    {
        private readonly IJsonItemService _jsonItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public JsonController(IJsonItemService jsonItemService, UserManager<ApplicationUser> userManager)
        {
            _jsonItemService = jsonItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();
            
            var jsonItems = await _jsonItemService.GetItemsAsync(currentUser);

            var model = new JsonViewModel()
            {
                Items = jsonItems
            };

            return View(model);
        }

        public async Task<IActionResult> AddItem(NewJsonItem item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var successfull = await _jsonItemService.AddItemAsync(item, currentUser);

            if(!successfull)
            {
                return BadRequest(new { error = "ERROR" });
            }

            return Ok();
        }
    }
}