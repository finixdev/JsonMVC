using JsonMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonMVC.Services
{
    public interface IJsonItemService
    {
        Task<IEnumerable<JsonItem>> GetItemsAsync(ApplicationUser user);
        Task<bool> AddItemAsync(NewJsonItem item, ApplicationUser user);
    }
}
