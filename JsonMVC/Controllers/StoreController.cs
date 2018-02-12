using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JsonMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JsonMVC.Controllers
{
    public class StoreController : Controller
    {
        string baseUrl = "http://localhost:49619/";
        HttpClient client = new HttpClient();

        public StoreController()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index(long? id)
        {
            if(id==null)
                return View("Index");
            else
            {
                HttpResponseMessage response = await client.GetAsync("api/json/"+id);
                response.EnsureSuccessStatusCode();

                var model = new JsonItem()
                {
                    Id = (long)id,
                    Data = response.Content.ReadAsStringAsync().Result
                };
                return View("Json", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewJsonItem newJsonItem)
        {
            //TODO json control

            HttpResponseMessage response = await client.PostAsJsonAsync("api/json", newJsonItem.Data);
            response.EnsureSuccessStatusCode();

            var dataId = long.Parse(response.Content.ReadAsStringAsync().Result);
            return RedirectToAction("Index", new { id = dataId });

            //return View("Json", data);
        }

        
        public IActionResult Usage()
        {
            return View();
        }
    }
}