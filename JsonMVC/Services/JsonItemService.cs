using JsonMVC.Data;
using JsonMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonMVC.Services
{
    public class JsonItemService : IJsonItemService
    {
        private readonly ApplicationDbContext _context;

        public JsonItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JsonItem>> GetItemsAsync(ApplicationUser user)
        {
            return await _context.JsonItems
                //.Where(x=>x.OwnerId == user.Id)
                .ToArrayAsync();
        }
        
        public async Task<bool> AddItemAsync(NewJsonItem item, ApplicationUser user)
        {
            var entity = new JsonItem
            {
                //OwnerId = user.Id,
                Data = item.Data
            };

            _context.JsonItems.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}
