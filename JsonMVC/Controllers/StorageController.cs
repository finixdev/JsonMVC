using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JsonMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JsonMVC.Controllers
{
    public class StorageController : Controller
    {
        string baseUrl = "http://localhost:49619/";
        HttpClient client = new HttpClient();

        public StorageController()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult Index(long? id)
        {
            if (id == null)
                return View("Index");
            else
                return View("");
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(NewJsonItem newJsonItem)
        //{
        //    //TODO json control

        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/json", newJsonItem);
        //    response.EnsureSuccessStatusCode();

        //    var savedJson = new SavedJsonViewModel
        //    {
        //        Item = newJsonItem,
        //        Link = response.Headers.Location.ToString()
        //    };

        //    return View("Json", savedJson);
        //}
    }
}